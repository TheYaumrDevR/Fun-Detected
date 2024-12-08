using Org.Ethasia.Fundetected.Core.Items;

namespace Org.Ethasia.Fundetected.Core.Equipment
{
    public static class EquipmentSlotTypesExtension
    {
        public static bool CanEquip(this EquipmentSlotTypes slotType, ItemClass itemClass)
        {
            switch (slotType)
            {
                case EquipmentSlotTypes.MAIN_HAND:
                    return itemClass.IsOneHandedWeapon() || itemClass.IsTwoHandedWeapon();
                case EquipmentSlotTypes.OFF_HAND:
                    return itemClass.IsOneHandedWeapon() || itemClass.IsOffHand();
                case EquipmentSlotTypes.HEAD:
                    return false;
                case EquipmentSlotTypes.CHEST:
                    return false;
                case EquipmentSlotTypes.HANDS:
                    return false;   
                case EquipmentSlotTypes.FEET:
                    return false;  
                case EquipmentSlotTypes.BELT:
                    return false;       
                case EquipmentSlotTypes.RINGS:
                    return false;       
                case EquipmentSlotTypes.AMULET:
                    return false;  
                default:
                    return false;                                                                                                                                                                    
            }
        }
    }
}