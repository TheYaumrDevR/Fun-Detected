namespace Org.Ethasia.Fundetected.Core.Items
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
                || itemClass == ItemClass.MAGIC_MACE
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
            return itemClass == ItemClass.SHIELD
                || itemClass == ItemClass.QUIVER
                || itemClass == ItemClass.MAGIC_SOURCE;
        }

        public static ItemInInventoryShape CreateInventoryShape(this ItemClass itemClass, Item item)
        {
            switch (itemClass)
            {
                case ItemClass.ONE_HANDED_SWORD:
                case ItemClass.ONE_HANDED_AXE:
                case ItemClass.ONE_HANDED_MACE:
                case ItemClass.MAGIC_MACE:
                case ItemClass.SHIELD:
                case ItemClass.QUIVER:
                case ItemClass.BODY_ARMOR:
                    return ItemInInventoryShape.CreateTwoByThree(item);

                case ItemClass.TWO_HANDED_SWORD:
                case ItemClass.TWO_HANDED_AXE:
                case ItemClass.WIZARD_STAFF:
                case ItemClass.MARTIAL_STAFF:
                case ItemClass.TWO_HANDED_MACE:
                case ItemClass.BOW:
                    return ItemInInventoryShape.CreateTwoByFour(item);

                case ItemClass.DAGGER:
                case ItemClass.SPELL_DAGGER:
                case ItemClass.WAND:
                    return ItemInInventoryShape.CreateOneByThree(item);

                case ItemClass.FIST_WEAPON:
                case ItemClass.MAGIC_SOURCE:
                case ItemClass.HEAD_GEAR:
                case ItemClass.SHOES:
                case ItemClass.GLOVES:
                    return ItemInInventoryShape.CreateTwoByTwo(item);

                case ItemClass.ONE_HANDED_STABBING_SWORD:
                    return ItemInInventoryShape.CreateOneByFour(item);

                case ItemClass.RING:
                case ItemClass.AMULET:
                case ItemClass.GLYPH:
                    return ItemInInventoryShape.CreateOneByOne(item);

                case ItemClass.BELT:
                    return ItemInInventoryShape.CreateTwoByOne(item);

                case ItemClass.LIFE_POTION:
                case ItemClass.MANA_POTION:
                case ItemClass.ENHANCING_POTION:
                    return ItemInInventoryShape.CreateOneByTwo(item);

                case ItemClass.NONE:
                default:
                    return null;
            }
        }
    }
}