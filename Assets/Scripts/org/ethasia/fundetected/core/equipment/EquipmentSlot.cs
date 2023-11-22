namespace Org.Ethasia.Fundetected.Core.Equipment
{
    public class EquipmentSlot
    {
        private Equipment equipment;
        private EquipmentSlotTypes slotType;

        public EquipmentSlot(EquipmentSlotTypes slotType)
        {
            this.slotType = slotType;
        }

        public Equipment InsertEquipment(Equipment inserted)
        {
            if (!CanEquip(inserted.ItemClass))
            {
                return inserted;
            }

            Equipment oldEquipment = null;

            if (null != equipment)
            {
                oldEquipment = equipment;
            }

            equipment = inserted;
            return oldEquipment;
        }

        public Equipment RemoveEquipment()
        {
            Equipment result = equipment;
            equipment = null;

            return result;
        }

        public bool IsEmpty()
        {
            return equipment == null;
        }

        public bool CanEquip(ItemClass itemClass)
        {
            return slotType.CanEquip(itemClass);
        }

        public ItemClass GetEquipmentItemClass()
        {
            if (null != equipment)
            {
                return equipment.ItemClass;
            }

            return ItemClass.NONE;
        }
    }
}