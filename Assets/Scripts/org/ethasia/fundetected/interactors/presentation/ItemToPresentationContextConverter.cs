using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Items.Potions;

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

        public static InventoryWeaponPresentationContext ConvertWeaponToInventoryContext(ItemInventoryExtractionVisitor.ItemWithShape<Weapon> weapon)
        {
            InventoryItemPresentationContext inventoryItemPresentationContext = ConvertItemAndShapeToPresentationContext(weapon.Item, weapon.ItemInInventoryShape);
            WeaponPresentationContext weaponPresentationContext = ConvertWeaponToPresentationContext(weapon.Item);

            return new InventoryWeaponPresentationContext.Builder()
                .WithWeaponContext(weaponPresentationContext)
                .WithItemContext(inventoryItemPresentationContext)
                .Build();
        }

        public static InventoryArmorPresentationContext ConvertArmorToInventoryContext(ItemInventoryExtractionVisitor.ItemWithShape<Armor> armor)
        {
            InventoryItemPresentationContext inventoryItemPresentationContext = ConvertItemAndShapeToPresentationContext(armor.Item, armor.ItemInInventoryShape);
            ArmorPresentationContext armorPresentationContext = ConvertArmorToPresentationContext(armor.Item);

            return new InventoryArmorPresentationContext.Builder()
                .WithArmorContext(armorPresentationContext)
                .WithItemContext(inventoryItemPresentationContext)
                .Build();
        }

        public static InventoryRecoveryPotionPresentationContext ConvertRecoveryPotionToInventoryContext(ItemInventoryExtractionVisitor.ItemWithShape<RecoveryPotion> recoveryPotion)
        {
            InventoryItemPresentationContext inventoryItemPresentationContext = ItemToPresentationContextConverter.ConvertNoAffixItemAndShapeToPresentationContext(recoveryPotion.Item, recoveryPotion.ItemInInventoryShape);
            RecoveryPotionPresentationContext recoveryPotionPresentationContext = ConvertRecoveryPotionToPresentationContext(recoveryPotion.Item);

            return new InventoryRecoveryPotionPresentationContext.Builder()
                .WithRecoveryPotionContext(recoveryPotionPresentationContext)
                .WithItemContext(inventoryItemPresentationContext)
                .Build();
        }

        public static InventoryItemPresentationContext ConvertItemAndShapeToPresentationContext(Equipment item, ItemInInventoryShape itemInInventoryShape)
        {
            InventoryItemPresentationContext.Builder itemPresentationContextBuilder = ConvertItemToPresentationContext(item, true);
            itemPresentationContextBuilder.WithAffixes(ConvertItemAffixesToPresentationContext(item));
            ConvertShapeAndPositionToPresentationContext(itemInInventoryShape, itemPresentationContextBuilder);  

            return itemPresentationContextBuilder.Build();          
        }

        public static void ConvertShapeAndPositionToPresentationContext(ItemInInventoryShape itemInInventoryShape, InventoryItemPresentationContext.Builder contextBuilder)
        {
            contextBuilder
                .WithTopLeftCornerX(itemInInventoryShape.TopLeftCornerPosInItemGrid.Value.X)
                .WithTopLeftCornerY(itemInInventoryShape.TopLeftCornerPosInItemGrid.Value.Y)
                .WithDimensionX(itemInInventoryShape.Width)
                .WithDimensionY(itemInInventoryShape.Height);
        }

        private static InventoryItemPresentationContext ConvertNoAffixItemAndShapeToPresentationContext(Item item, ItemInInventoryShape itemInInventoryShape)
        {
            InventoryItemPresentationContext.Builder itemPresentationContextBuilder = ConvertItemToPresentationContext(item, false);
            itemPresentationContextBuilder.WithAffixes(ConvertItemAffixesToPresentationContext(null));
            ConvertShapeAndPositionToPresentationContext(itemInInventoryShape, itemPresentationContextBuilder);  

            return itemPresentationContextBuilder.Build();          
        }

        private static InventoryItemPresentationContext.Builder ConvertItemToPresentationContext(Item item, bool canBeEquipped)
        {
            return new InventoryItemPresentationContext.Builder()
                .WithItemId(item.Name)
                .WithItemClass(item.ItemClass)
                .WithCanBeEquipped(canBeEquipped);
        }

        private static AffixesPresentationContext ConvertItemAffixesToPresentationContext(Equipment item)
        {
            if (null == item)
            {
                return new AffixesPresentationContext(new IAffixPresentationContext[] { }, new IAffixPresentationContext[] { });
            }

            AffixToPresentationContextConversionVisitor converter = new AffixToPresentationContextConversionVisitor();
            converter.ConvertAffixesToPresentationContexts(item.FirstImplicit, item.Prefixes, item.Suffixes);

            return new AffixesPresentationContext(converter.Implicits, converter.Explicits);
        }

        private static WeaponPresentationContext ConvertWeaponToPresentationContext(Weapon weapon)
        {
            return new WeaponPresentationContext.Builder()
                .WithMinToMaxPhysicalDamage(weapon.MinToMaxPhysicalDamage)
                .WithMinToMaxSpellDamage(weapon.MinToMaxSpellDamage)
                .WithSkillsPerSecond(weapon.SkillsPerSecond)
                .WithCriticalStrikeChance(weapon.CriticalStrikeChance)
                .Build();            
        }

        private static ArmorPresentationContext ConvertArmorToPresentationContext(Armor armor)
        {
            return new ArmorPresentationContext.Builder()
                .WithArmorValue(armor.ArmorValue)
                .WithMovementSpeedAddend(armor.MovementSpeedAddend)
                .Build();
        }

        private static RecoveryPotionPresentationContext ConvertRecoveryPotionToPresentationContext(RecoveryPotion recoveryPotion)
        {
            return new RecoveryPotionPresentationContext.Builder()
                .WithUses(recoveryPotion.Uses)
                .WithRecoveryAmount(recoveryPotion.RecoveryAmount)
                .Build();
        }
    }
}