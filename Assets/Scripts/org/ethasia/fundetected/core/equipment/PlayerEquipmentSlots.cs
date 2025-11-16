using Org.Ethasia.Fundetected.Core.Items;

namespace Org.Ethasia.Fundetected.Core.Equipment
{
    public class PlayerEquipmentSlots
    {
        public StatsFromEquipment EquipmentStats
        {
            get;
            private set;
        }

        private EquipmentSlot mainHandSlot;
        private EquipmentSlot offHandSlot;
        private EquipmentSlot leftRingSlot;
        private EquipmentSlot rightRingSlot;
        private EquipmentSlot beltSlot;

        public PlayerEquipmentSlots()
        {
            EquipmentStats = new StatsFromEquipment();
            mainHandSlot = new EquipmentSlot(EquipmentSlotTypes.MAIN_HAND);
            offHandSlot = new EquipmentSlot(EquipmentSlotTypes.OFF_HAND);
            leftRingSlot = new EquipmentSlot(EquipmentSlotTypes.RINGS);
            rightRingSlot = new EquipmentSlot(EquipmentSlotTypes.RINGS);
            beltSlot = new EquipmentSlot(EquipmentSlotTypes.BELT);
        }

        public Equipment EquipInMainHand(Equipment toEquip)
        {
            if (!CanEquipInMainHand(toEquip))
            {
                return toEquip;
            }

            return SwapEquipedEquipment(mainHandSlot, toEquip);
        }

        public Equipment EquipInOffHand(Equipment toEquip)
        {
            if (!CanEquipInOffHand(toEquip))
            {
                return toEquip;
            }

            return SwapEquipedEquipment(offHandSlot, toEquip);
        }

        public Equipment EquipInLeftRing(Equipment toEquip)
        {
            if (!leftRingSlot.CanEquip(toEquip.ItemClass))
            {
                return toEquip;
            }

            return SwapEquipedEquipment(leftRingSlot, toEquip);
        }

        public Equipment EquipInRightRing(Equipment toEquip)
        {
            if (!rightRingSlot.CanEquip(toEquip.ItemClass))
            {
                return toEquip;
            }

            return SwapEquipedEquipment(rightRingSlot, toEquip);
        }

        public Equipment EquipInBelt(Equipment toEquip)
        {
            if (!beltSlot.CanEquip(toEquip.ItemClass))
            {
                return toEquip;
            }

            return SwapEquipedEquipment(beltSlot, toEquip);
        }

        public void EquipIntoFreeSlotBasedOnItemClass(Equipment toEquip)
        {
            switch (toEquip.ItemClass)
            {
                case ItemClass.RING:
                    if (leftRingSlot.IsEmpty())
                    {
                        EquipInLeftRing(toEquip);
                    }
                    else if (rightRingSlot.IsEmpty())
                    {
                        EquipInRightRing(toEquip);
                    }
                    
                    break;
                case ItemClass.BELT:
                    if (beltSlot.IsEmpty())
                    {
                        EquipInBelt(toEquip);
                    }

                    break;
            }
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

        private Equipment SwapEquipedEquipment(EquipmentSlot slot, Equipment toEquip)
        {
            toEquip.OnEquip(EquipmentStats);

            Equipment oldEquipment = slot.InsertEquipment(toEquip);

            if (null != oldEquipment)
            {
                oldEquipment.OnUnequip(EquipmentStats);
            }

            return oldEquipment;
        }        
    }
}