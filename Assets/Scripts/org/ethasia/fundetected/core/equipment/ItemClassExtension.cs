namespace Org.Ethasia.Fundetected.Core.Equipment
{
    public static class ItemClassExtension
    {
        public static bool IsOneHandedWeapon(this ItemClass itemClass)
        {
            return itemClass == ItemClass.ONE_HANDED_SWORD 
                || itemClass == ItemClass.ONE_HANDED_STABBING_SWORD
                || itemClass == ItemClass.DAGGER
                || itemClass == ItemClass.SPELL_DAGGER
                || itemClass == ItemClass.ONE_HANDED_AXE
                || itemClass == ItemClass.FIST_WEAPON
                || itemClass == ItemClass.ONE_HANDED_MACE
                || itemClass == ItemClass.WAND;
        }

        public static bool IsTwoHandedWeapon(this ItemClass itemClass)
        {
            return itemClass == ItemClass.TWO_HANDED_SWORD 
                || itemClass == ItemClass.TWO_HANDED_AXE
                || itemClass == ItemClass.WIZARD_STAFF
                || itemClass == ItemClass.MARTIAL_STAFF
                || itemClass == ItemClass.TWO_HANDED_MACE
                || itemClass == ItemClass.BOW;
        } 

        public static bool IsOffHand(this ItemClass itemClass)
        {
            return false;
        }           
    }
}