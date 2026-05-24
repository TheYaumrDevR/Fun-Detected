using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items;

namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public class ItemToPresentationContextConverter
    {
        public static EquippedWeaponPresentationContext? ConvertWeaponToEquipmentContext(Weapon weapon, EquipmentSlotPositions slotPosition)
        {
            if (null != weapon)
            {
                InventoryItemPresentationContext itemContext = ConvertItemToPresentationContext(weapon, true)
                    .WithAffixes(ConvertItemAffixesToPresentationContext(weapon))
                    .Build();
                WeaponPresentationContext weaponContext = ConvertWeaponToPresentationContext(weapon);

                return new EquippedWeaponPresentationContext.Builder()
                    .WithSlotPosition(slotPosition)
                    .WithItemPresentationContext(itemContext)
                    .WithWeaponPresentationContext(weaponContext)
                    .Build();
            }

            return null;
        }

        public static EquippedJewelryPresentationContext? ConvertJewelryToEquipmentContext(Jewelry jewelry, EquipmentSlotPositions slotPosition)
        {
            if (null != jewelry)
            {
                InventoryItemPresentationContext itemContext = ConvertItemToPresentationContext(jewelry, true)
                    .WithAffixes(ConvertItemAffixesToPresentationContext(jewelry))
                    .Build();

                return new EquippedJewelryPresentationContext.Builder()
                    .WithSlotPosition(slotPosition)
                    .WithItemPresentationContext(itemContext)
                    .Build();
            }

            return null;
        }

        public static InventoryItemPresentationContext ConvertItemAndShapeToPresentationContext(Equipment item, ItemInInventoryShape itemInInventoryShape)
        {
            InventoryItemPresentationContext.Builder itemPresentationContextBuilder = ConvertItemToPresentationContext(item, true);
            itemPresentationContextBuilder.WithAffixes(ConvertItemAffixesToPresentationContext(item));
            ConvertShapeAndPositionToPresentationContext(itemInInventoryShape, itemPresentationContextBuilder);  

            return itemPresentationContextBuilder.Build();          
        }

        public static InventoryItemPresentationContext ConvertNoAffixItemAndShapeToPresentationContext(Item item, ItemInInventoryShape itemInInventoryShape)
        {
            InventoryItemPresentationContext.Builder itemPresentationContextBuilder = ConvertItemToPresentationContext(item, true);
            itemPresentationContextBuilder.WithAffixes(ConvertItemAffixesToPresentationContext(null));
            ConvertShapeAndPositionToPresentationContext(itemInInventoryShape, itemPresentationContextBuilder);  

            return itemPresentationContextBuilder.Build();          
        }

        public static InventoryItemPresentationContext.Builder ConvertItemToPresentationContext(Item item, bool canBeEquipped)
        {
            return new InventoryItemPresentationContext.Builder()
                .WithItemId(item.Name)
                .WithItemClass(item.ItemClass)
                .WithCanBeEquipped(canBeEquipped);
        }

        public static AffixesPresentationContext ConvertItemAffixesToPresentationContext(Equipment item)
        {
            if (null == item)
            {
                return new AffixesPresentationContext(new IAffixPresentationContext[] { }, new IAffixPresentationContext[] { });
            }

            AffixToPresentationContextConversionVisitor converter = new AffixToPresentationContextConversionVisitor();
            converter.ConvertAffixesToPresentationContexts(item.FirstImplicit, item.Prefixes, item.Suffixes);

            return new AffixesPresentationContext(converter.Implicits, converter.Explicits);
        }

        public static WeaponPresentationContext ConvertWeaponToPresentationContext(Weapon weapon)
        {
            return new WeaponPresentationContext.Builder()
                .WithMinToMaxPhysicalDamage(weapon.MinToMaxPhysicalDamage)
                .WithMinToMaxSpellDamage(weapon.MinToMaxSpellDamage)
                .WithSkillsPerSecond(weapon.SkillsPerSecond)
                .WithCriticalStrikeChance(weapon.CriticalStrikeChance)
                .Build();            
        }

        private static void ConvertShapeAndPositionToPresentationContext(ItemInInventoryShape itemInInventoryShape, InventoryItemPresentationContext.Builder contextBuilder)
        {
            contextBuilder
                .WithTopLeftCornerX(itemInInventoryShape.TopLeftCornerPosInItemGrid.Value.X)
                .WithTopLeftCornerY(itemInInventoryShape.TopLeftCornerPosInItemGrid.Value.Y)
                .WithDimensionX(itemInInventoryShape.Width)
                .WithDimensionY(itemInInventoryShape.Height);
        }
    }
}