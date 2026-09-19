using System;

using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Items.Potions;
using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors.Map;
using Org.Ethasia.Fundetected.Interactors.Presentation;

namespace Org.Ethasia.Fundetected.Interactors.Items
{
    public class PlayerInventoryInteractor
    {
        private IInventoryPresenter inventoryPresenter;
        private InventorySlotPresentationItemVisitor presentationVisitor;
        private DropItemInteractor dropItemInteractor;

        public PlayerInventoryInteractor()
        {
            inventoryPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetInventoryPresenterInstance();
            dropItemInteractor = new DropItemInteractor();

            presentationVisitor = new InventorySlotPresentationItemVisitor.Builder()
                .SetItemInventory(Area.ActiveArea.Player.ItemInventory)
                .SetWeaponPresentationMethod(PresentSwappedEquippedWeapon)
                .SetArmorPresentationMethod(PresentSwappedEquippedArmor)
                .SetJewelryPresentationMethod(PresentSwappedEquippedJewelry)
                .SetRecoveryPotionPresentationMethod(PresentSwappedEquippedRecoveryPotion)
                .SetEmptyItemPresentationMethod(PresentEmptySlotAfterSwap)
                .Build();
        }

        public void SwapCursorItemWithMainHandEquipment()
        {
            SwapCursorItemWithEquipmentSlot(
                () => Area.ActiveArea.Player.ItemInventory.SwapCursorItemWithMainHandEquipment(),
                (itemName) => presentationVisitor.PresentMainHand(itemName));
        }

        public void SwapCursorItemWithOffHandEquipment()
        {
            SwapCursorItemWithEquipmentSlot(
                () => Area.ActiveArea.Player.ItemInventory.SwapCursorItemWithOffHandEquipment(),
                (itemName) => presentationVisitor.PresentOffHand(itemName));
        }

        public void SwapCursorItemWithLeftRingEquipment()
        {
            SwapCursorItemWithEquipmentSlot(
                () => Area.ActiveArea.Player.ItemInventory.SwapCursorItemWithLeftRingEquipment(),
                (itemName) => presentationVisitor.PresentLeftRing(itemName));
        }

        public void SwapCursorItemWithRightRingEquipment()
        {
            SwapCursorItemWithEquipmentSlot(
                () => Area.ActiveArea.Player.ItemInventory.SwapCursorItemWithRightRingEquipment(),
                (itemName) => presentationVisitor.PresentRightRing(itemName));
        }

        public void SwapCursorItemWithBeltEquipment()
        {
            SwapCursorItemWithEquipmentSlot(
                () => Area.ActiveArea.Player.ItemInventory.SwapCursorItemWithBeltEquipment(),
                (itemName) => presentationVisitor.PresentBelt(itemName));
        }

        public void DropCursorItem()
        {
            Item droppedItem = Area.ActiveArea.Player.DropPickedInventoryItem();

            if (droppedItem != null)
            {
                inventoryPresenter.HideItemOnCursor();
                dropItemInteractor.DropItemFromPlayer(droppedItem);
            }
        }

        public void PickItemFromGridAtPosition(int posX, int posY)
        {
            if (Area.ActiveArea.Player.ItemInventory.ItemOnCursor == null)
            {
                ItemInInventoryShape pickedItem = Area.ActiveArea.Player.ItemInventory.RemoveItemAtFromGrid(new PositionImmutable(posX, posY));

                if (pickedItem != null)
                {
                    InventoryItemPresentationContext.Builder contextBuilder = new InventoryItemPresentationContext.Builder();

                    ItemToPresentationContextConverter.ConvertShapeAndPositionToPresentationContext(pickedItem, contextBuilder);
                    contextBuilder.WithItemId(pickedItem.Item.Name);
                    inventoryPresenter.ShowSwappedInventoryGridItems(contextBuilder.Build(), null);

                    ISoundPresenter soundPresenter = IoAdaptersFactoryForCore.GetInstance().GetSoundPresenterInstance();
                    soundPresenter.PlayInventoryGrabItemSound();
                }
            }
        }

        public void TryDropItemOnCursorIntoGridAt(int x, int y)
        {
            ItemInventory playerInventory = Area.ActiveArea.Player.ItemInventory;
            Item oldItemOnCursor = playerInventory.ItemOnCursor;

            if (null == oldItemOnCursor)
            {
                return;
            }

            PositionImmutable targetPosition = new PositionImmutable(x, y);
            bool itemWasPlaced = Area.ActiveArea.Player.ItemInventory.PlaceCursorItemIntoGrid(targetPosition);
            
            if (itemWasPlaced)
            {
                Item newItemOnCursor = playerInventory.ItemOnCursor;

                InventoryItemPresentationContext.Builder placedItemContextBuilder = new InventoryItemPresentationContext.Builder();
                ItemInInventoryShape placedItemShape = playerInventory.InventoryGrid.GetItemAt(targetPosition);
                ItemToPresentationContextConverter.ConvertShapeAndPositionToPresentationContext(placedItemShape, placedItemContextBuilder);
                placedItemContextBuilder.WithItemId(oldItemOnCursor.Name);

                InventoryItemPresentationContext swappedItemContext = new InventoryItemPresentationContext.Builder()
                        .WithItemId(newItemOnCursor != null ? newItemOnCursor.Name : null)
                        .Build();

                ISoundPresenter soundPresenter = IoAdaptersFactoryForCore.GetInstance().GetSoundPresenterInstance();
                soundPresenter.PlayItemMaterialSound(oldItemOnCursor.Material);

                inventoryPresenter.ShowSwappedInventoryGridItems(swappedItemContext, placedItemContextBuilder.Build());
            }
        }

        public (int Width, int Height) GetItemOnCursorDimensions()
        {
            Item itemOnCursor = GetCurrentItemOnCursor();

            if (null == itemOnCursor)
            {
                return (0, 0);
            }

            ItemInInventoryShape shape = itemOnCursor.CreateInventoryShape();

            return (shape.Width, shape.Height);
        }

        private Item GetCurrentItemOnCursor()
        {
            return Area.ActiveArea.Player.ItemInventory.ItemOnCursor;
        }

        private void SwapCursorItemWithEquipmentSlot(Action swapAction, Action<string> presentAction)
        {
            PlayerCharacter player = Area.ActiveArea.Player;
            ItemInventory playerInventory = Area.ActiveArea.Player.ItemInventory;

            Item oldItemOnCursor = playerInventory.ItemOnCursor;
            swapAction();
            Item newItemOnCursor = playerInventory.ItemOnCursor;

            player.RecalculateTotalStats();

            if (oldItemOnCursor != newItemOnCursor)
            {
                string cursorItemId = newItemOnCursor != null ? newItemOnCursor.Name : "";
                presentAction(cursorItemId);

                if (newItemOnCursor != null)
                {
                    ISoundPresenter soundPresenter = IoAdaptersFactoryForCore.GetInstance().GetSoundPresenterInstance();
                    soundPresenter.PlayInventoryGrabItemSound();
                }

                if (oldItemOnCursor != null)
                {
                    ISoundPresenter soundPresenter = IoAdaptersFactoryForCore.GetInstance().GetSoundPresenterInstance();
                    soundPresenter.PlayItemMaterialSound(oldItemOnCursor.Material);
                }
            }
        }

        private void PresentSwappedEquippedWeapon(InventorySlotPresentationItemVisitor presentationVisitor, Weapon weapon)
        {
            EquippedWeaponPresentationContext? presentationContext = ItemToPresentationContextConverter.ConvertWeaponToEquipmentContext(weapon, presentationVisitor.SlotPosition);

            if (presentationContext != null)
            {
                inventoryPresenter.ShowSwappedEquippedWeapon(presentationVisitor.ItemIdOnCursor, presentationContext.Value);    
            }
        }

        private void PresentSwappedEquippedArmor(InventorySlotPresentationItemVisitor presentationVisitor, Armor armor)
        {
        }

        private void PresentSwappedEquippedJewelry(InventorySlotPresentationItemVisitor presentationVisitor, Jewelry jewelry)
        {
            EquippedJewelryPresentationContext? presentationContext = ItemToPresentationContextConverter.ConvertJewelryToEquipmentContext(jewelry, presentationVisitor.SlotPosition);

            if (presentationContext != null)
            {
                inventoryPresenter.ShowSwappedEquippedJewelry(presentationVisitor.ItemIdOnCursor, presentationContext.Value);
            }
        }

        private void PresentSwappedEquippedRecoveryPotion(InventorySlotPresentationItemVisitor presentationVisitor, RecoveryPotion recoveryPotion)
        {
        }

        private void PresentEmptySlotAfterSwap(InventorySlotPresentationItemVisitor presentationVisitor)
        {
            inventoryPresenter.ShowEmptySlotAfterSwap(presentationVisitor.ItemIdOnCursor, presentationVisitor.SlotPosition);
        }
    }
}