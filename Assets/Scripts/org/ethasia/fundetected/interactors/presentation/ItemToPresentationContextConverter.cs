using System;

using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Items.Potions;
using Org.Ethasia.Fundetected.Core.Map;

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
                    .WithItemPotential(weapon.Potential)
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
                    .WithItemPotential(jewelry.Potential)
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
            itemPresentationContextBuilder.WithItemPotential(item.Potential);
            ConvertShapeAndPositionToPresentationContext(itemInInventoryShape, itemPresentationContextBuilder);  

            return itemPresentationContextBuilder.Build();          
        }

        public static void ConvertShapeAndPositionToPresentationContext(ItemInInventoryShape itemInInventoryShape, InventoryItemPresentationContext.Builder contextBuilder)
        {
            contextBuilder
                .WithTopLeftCornerX(itemInInventoryShape.LastTopLeftCornerPosInItemGrid.Value.X)
                .WithTopLeftCornerY(itemInInventoryShape.LastTopLeftCornerPosInItemGrid.Value.Y)
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
            DamageRange minToMaxSpellDamage = weapon.TotalStats.SpellDamage.MinDamage != 0 && weapon.TotalStats.SpellDamage.MaxDamage != 0
                ? weapon.TotalStats.SpellDamage
                : null;

            return new WeaponPresentationContext.Builder()
                .WithMinToMaxPhysicalDamage(weapon.TotalStats.PhysicalDamage)
                .WithMinToMaxSpellDamage(minToMaxSpellDamage)
                .WithSkillsPerSecond(weapon.TotalStats.SkillsPerSecond)
                .WithCriticalStrikeChance(weapon.TotalStats.CriticalStrikeChance)
                .WithIsPhysicalDamageModified(IsWeaponPhysicalDamageModified(weapon))
                .WithIsSpellDamageModified(IsWeaponSpellDamageModified(weapon))
                .WithIsSkillsPerSecondModified(Math.Abs(weapon.TotalStats.SkillsPerSecond - weapon.SkillsPerSecond) > 0.0001)
                .WithIsCriticalStrikeChanceModified(weapon.TotalStats.CriticalStrikeChance != weapon.CriticalStrikeChance)
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

        private static bool IsWeaponPhysicalDamageModified(Weapon weapon)
        {
            return IsDamageRangeModified(weapon.MinToMaxPhysicalDamage, weapon.TotalStats.PhysicalDamage);
        }

        private static bool IsWeaponSpellDamageModified(Weapon weapon)
        {
            return IsDamageRangeModified(weapon.MinToMaxSpellDamage, weapon.TotalStats.SpellDamage);
        }

        private static bool IsDamageRangeModified(DamageRange baseDamage, DamageRange totalDamage)
        {
            int baseMin = baseDamage != null ? baseDamage.MinDamage : 0;
            int baseMax = baseDamage != null ? baseDamage.MaxDamage : 0;

            return totalDamage.MinDamage != baseMin
                || totalDamage.MaxDamage != baseMax;
        }
    }
}