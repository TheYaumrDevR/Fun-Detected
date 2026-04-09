using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors.Presentation;

namespace Org.Ethasia.Fundetected.Interactors.Items
{
    public class PlayerInventoryInteractor
    {
        private IInventoryPresenter inventoryPresenter;

        private string cursorItemTypeId;
        private EquipmentSlotPositions swappedEquipmentSlot;

        public void SwapCursorItemWithMainHandEquipment()
        {
            ItemInventory playerInventory = Area.ActiveArea.Player.ItemInventory;

            Item oldItemOnCursor = playerInventory.ItemOnCursor;
            playerInventory.SwapCursorItemWithMainHandEquipment();
            Item newItemOnCursor = playerInventory.ItemOnCursor;

            if (oldItemOnCursor != newItemOnCursor)
            {
                cursorItemTypeId = newItemOnCursor.Name;
                swappedEquipmentSlot = EquipmentSlotPositions.MAIN_HAND;
                // Create a visitor to visit the item on the equipment slot which then calls PresentSwappedEquippedWeapon
            }
        }

        public void SwapCursorItemWithOffHandEquipment()
        {
            ItemInventory playerInventory = Area.ActiveArea.Player.ItemInventory;
            playerInventory.SwapCursorItemWithOffHandEquipment();
        }

        public void SwapCursorItemWithLeftRingEquipment()
        {
            ItemInventory playerInventory = Area.ActiveArea.Player.ItemInventory;
            playerInventory.SwapCursorItemWithLeftRingEquipment();
        }

        public void SwapCursorItemWithRightRingEquipment()
        {
            ItemInventory playerInventory = Area.ActiveArea.Player.ItemInventory;
            playerInventory.SwapCursorItemWithRightRingEquipment();
        }

        public void SwapCursorItemWithBeltEquipment()
        {
            ItemInventory playerInventory = Area.ActiveArea.Player.ItemInventory;
            playerInventory.SwapCursorItemWithBeltEquipment();
        }

        private void PresentSwappedEquippedWeapon()
        {
            // call IInventoryPresenter.ShowSwappedEquippedWeapon
        }
    }
}