namespace Org.Ethasia.Fundetected.Core.Equipment
{
    public class PlayerEquipmentSlots
    {
        private EquipmentSlot mainHandSlot;
        private EquipmentSlot offHandSlot;

        public PlayerEquipmentSlots()
        {
            mainHandSlot = new EquipmentSlot(EquipmentSlotTypes.MAIN_HAND);
            offHandSlot = new EquipmentSlot(EquipmentSlotTypes.OFF_HAND);
        }

        public bool CanEquipInMainHand(Equipment equipment)
        {
            if (mainHandSlot.CanEquip(equipment.ItemClass))
            {
                if (equipment.ItemClass.IsTwoHandedWeapon())
                {
                    return offHandSlot.IsEmpty();
                }
                else if (equipment.ItemClass.IsOneHandedWeapon())
                {
                    if (!offHandSlot.IsEmpty())
                    {
                        return equipment.ItemClass == offHandSlot.GetEquipmentItemClass();
                    }

                    return true;
                }
            }

            return false;
        }

        public bool CanEquipInOffHand(Equipment equipment)
        {
            if (offHandSlot.CanEquip(equipment.ItemClass))
            {
                if (equipment.ItemClass.IsOneHandedWeapon())
                {
                    if (!mainHandSlot.IsEmpty())
                    {
                        return equipment.ItemClass == mainHandSlot.GetEquipmentItemClass();
                    }

                    return true;
                }
            }

            return false;
        }
    }
}