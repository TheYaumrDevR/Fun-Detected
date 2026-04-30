using System;

using EquipmentItem = Org.Ethasia.Fundetected.Core.Equipment.Equipment;
using Org.Ethasia.Fundetected.Core.Equipment;

namespace Org.Ethasia.Fundetected.Core.Items
{
    public class ItemInventory
    {
        private DropItemIntoSlotVisitor slotDropper;

        public Item ItemOnCursor
        {
            get;
            private set;
        }

        public PlayerEquipmentSlots EquippedItems
        {
            get;
            private set;
        }

        public ItemInventoryGrid InventoryGrid
        {
            get;
            private set;
        }

        public ItemInventory()
        {
            EquippedItems = new PlayerEquipmentSlots();
            InventoryGrid = new ItemInventoryGrid();
            slotDropper = new DropItemIntoSlotVisitor(EquippedItems);
        }

        public void SwapCursorItemWithMainHandEquipment()
        {
            SwapCursorItemWithEquipmentSlot(EquippedItems.PickUpMainHandEquipment, EquipmentSlotPositions.MAIN_HAND);
        }

        public void SwapCursorItemWithOffHandEquipment()
        {
            SwapCursorItemWithEquipmentSlot(EquippedItems.PickUpOffHandEquipment, EquipmentSlotPositions.OFF_HAND);
        }

        public void SwapCursorItemWithLeftRingEquipment()
        {
            SwapCursorItemWithEquipmentSlot(EquippedItems.PickUpLeftRingEquipment, EquipmentSlotPositions.LEFT_RING);
        }

        public void SwapCursorItemWithRightRingEquipment()
        {
            SwapCursorItemWithEquipmentSlot(EquippedItems.PickUpRightRingEquipment, EquipmentSlotPositions.RIGHT_RING);
        }

        public void SwapCursorItemWithBeltEquipment()
        {
            SwapCursorItemWithEquipmentSlot(EquippedItems.PickUpBeltEquipment, EquipmentSlotPositions.BELT);
        }

        public Item DropPickedItem()
        {
            Item result = ItemOnCursor;
            ItemOnCursor = null;

            return result;
        }

        private void SwapCursorItemWithEquipmentSlot(
            Func<EquipmentItem, EquipmentItem> pickupFunction, 
            EquipmentSlotPositions slotPosition)
        {
            if (ItemOnCursor == null)
            {
                ItemOnCursor = pickupFunction(null);
            }
            else
            {
                slotDropper.DropItemIntoSlot(ItemOnCursor, slotPosition);
                ItemOnCursor = slotDropper.SwappedItem;
            }
        }
    }
}