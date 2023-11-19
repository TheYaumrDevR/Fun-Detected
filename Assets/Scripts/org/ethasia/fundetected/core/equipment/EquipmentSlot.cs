namespace Org.Ethasia.Fundetected.Core.Equipment
{
    public class EquipmentSlot
    {
        private Equipment equipment;

        public Equipment InsertEquipment(Equipment inserted)
        {
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
    }
}