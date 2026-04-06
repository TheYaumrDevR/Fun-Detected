using System;

using EquipmentItem = Org.Ethasia.Fundetected.Core.Equipment.Equipment;
using Org.Ethasia.Fundetected.Core.Equipment;

namespace Org.Ethasia.Fundetected.Core.Items
{
    public class ItemInventory
    {
        private Item itemOnCursor;

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
        }

        public void SwapCursorItemWithMainHandEquipment()
        {
            PickUpEquipmentIfCursorEmpty(EquippedItems.PickUpMainHandEquipment);
        }

        public void SwapCursorItemWithOffHandEquipment()
        {
            PickUpEquipmentIfCursorEmpty(EquippedItems.PickUpOffHandEquipment);
        }

        public void SwapCursorItemWithLeftRingEquipment()
        {
            PickUpEquipmentIfCursorEmpty(EquippedItems.PickUpLeftRingEquipment);
        }

        public void SwapCursorItemWithRightRingEquipment()
        {
            PickUpEquipmentIfCursorEmpty(EquippedItems.PickUpRightRingEquipment);
        }

        public void SwapCursorItemWithBeltEquipment()
        {
            PickUpEquipmentIfCursorEmpty(EquippedItems.PickUpBeltEquipment);
        }

        private void PickUpEquipmentIfCursorEmpty(Func<EquipmentItem, EquipmentItem> pickupFunction)
        {
            if (itemOnCursor == null)
            {
                itemOnCursor = pickupFunction(null);
            }
        }
    }
}