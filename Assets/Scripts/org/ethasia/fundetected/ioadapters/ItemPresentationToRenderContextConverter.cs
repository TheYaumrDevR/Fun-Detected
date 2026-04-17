using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Interactors.Presentation;
using Org.Ethasia.Fundetected.Ioadapters.Presentation;
using Org.Ethasia.Fundetected.Ioadapters.Presentation.UI;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class ItemPresentationToRenderContextConverter
    {
        private static ILocalizationGateway localizationGateway = TechnicalFactory.GetInstance().CreateLocalizationGateway();
        private static IEnumLocalizationGateway enumLocalizationGateway = TechnicalFactory.GetInstance().CreateEnumLocalizationGateway();

        public static EquipmentSlotRenderContext ConvertWeaponEquipmentSlotPresentationContext(InventoryItemPresentationContext context, WeaponPresentationContext weaponContext)
        {
            return new EquipmentSlotRenderContext.Builder()
                .SetItemImagePath(context.ItemId)
                .SetIsEquipped(context.CanBeEquipped)
                .SetToolTipRenderContext(ConvertWeaponPresentationContext(weaponContext, context))
                .Build();
        }

        public static EquipmentSlotRenderContext ConvertArmorEquipmentSlotPresentationContext(InventoryItemPresentationContext context, ArmorPresentationContext armorContext)
        {
            return new EquipmentSlotRenderContext.Builder()
                .SetItemImagePath(context.ItemId)
                .SetIsEquipped(context.CanBeEquipped)
                .SetToolTipRenderContext(ConvertArmorPresentationContext(armorContext, context))
                .Build();
        }

        public static EquipmentSlotRenderContext ConvertEquipmentSlotPresentationContext(InventoryItemPresentationContext context)
        {
            return new EquipmentSlotRenderContext.Builder()
                .SetItemImagePath(context.ItemId)
                .SetIsEquipped(context.CanBeEquipped)
                .SetToolTipRenderContext(ConvertPlainItemPresentationContextToTooltipContext(context))
                .Build();
        }

        public static EquipmentSlotRenderContext ConvertRecoveryPotionEquipmentSlotPresentationContext(InventoryItemPresentationContext context, RecoveryPotionPresentationContext recoveryPotionContext)
        {
            return new EquipmentSlotRenderContext.Builder()
                .SetItemImagePath(context.ItemId)
                .SetIsEquipped(context.CanBeEquipped)
                .SetToolTipRenderContext(ConvertRecoveryPotionPresentationContext(recoveryPotionContext, context))
                .Build();
        }    

        private static ItemTooltipRenderContext ConvertWeaponPresentationContext(WeaponPresentationContext weaponContext, InventoryItemPresentationContext itemContext)
        {
            return new ItemTooltipRenderContext.Builder()
                .WithItemName(itemContext.ItemId)
                .WithItemBaseTypeName(itemContext.ItemId)
                .WithItemPotential(itemContext.ItemPotential)
                .WithItemHeaderLines(ConvertWeaponPresentationContextBaseStatsToTooltipTextSegments(weaponContext, itemContext.ItemClass))
                .WithItemImplicitLines(ConvertItemImplicitsToTextSegments(itemContext))
                .Build();
        }

        private static ItemTooltipRenderContext ConvertArmorPresentationContext(ArmorPresentationContext armorContext, InventoryItemPresentationContext itemContext)
        {
            return new ItemTooltipRenderContext.Builder()
                .WithItemName(itemContext.ItemId)
                .WithItemBaseTypeName(itemContext.ItemId)
                .WithItemPotential(itemContext.ItemPotential)
                .WithItemHeaderLines(ConvertArmorPresentationContextBaseStatsToTooltipTextSegments(armorContext, itemContext.ItemClass))
                .WithItemImplicitLines(ConvertItemImplicitsToTextSegments(itemContext))
                .Build();
        }

        private static ItemTooltipRenderContext ConvertPlainItemPresentationContextToTooltipContext(InventoryItemPresentationContext itemContext)
        {
            return new ItemTooltipRenderContext.Builder()
                .WithItemName(itemContext.ItemId)
                .WithItemBaseTypeName(itemContext.ItemId)
                .WithItemPotential(itemContext.ItemPotential)
                .WithItemHeaderLines(ConvertItemClassToTooltipForJewelry(itemContext.ItemClass))
                .WithItemImplicitLines(ConvertItemImplicitsToTextSegments(itemContext))
                .Build();
        }

        private static ItemTooltipRenderContext ConvertRecoveryPotionPresentationContext(RecoveryPotionPresentationContext recoveryPotionContext, InventoryItemPresentationContext itemContext)
        {
            return new ItemTooltipRenderContext.Builder()
                .WithItemName(itemContext.ItemId)
                .WithItemBaseTypeName(itemContext.ItemId)
                .WithItemPotential(itemContext.ItemPotential)
                .WithItemHeaderLines(ConvertRecoveryPotionPresentationContextBaseStatsToTooltipTextSegments(recoveryPotionContext, itemContext.ItemClass))
                .WithItemImplicitLines(ConvertItemImplicitsToTextSegments(itemContext))
                .Build();
        }   

        private static List<List<UiTextSegment>> ConvertWeaponPresentationContextBaseStatsToTooltipTextSegments(WeaponPresentationContext weaponContext, ItemClass itemClass)
        {
            List<List<UiTextSegment>> result = new List<List<UiTextSegment>>();

            result.Add(ConvertItemClassToTextSegment(itemClass));

            if (weaponContext.MinToMaxPhysicalDamage != null)
            {
                result.Add(ConvertWeaponPhysDamageToTextSegments(weaponContext.MinToMaxPhysicalDamage));
            }
            
            if (weaponContext.MinToMaxSpellDamage != null)
            {
                result.Add(ConvertWeaponSpellDamageToTextSegments(weaponContext.MinToMaxSpellDamage));
            }

            result.Add(ConvertWeaponCritChanceToTextSegments(weaponContext.CriticalStrikeChance));
            result.Add(ConvertWeaponSkillsPerSecondToTextSegments(weaponContext.SkillsPerSecond));

            return result;
        }

        private static List<UiTextSegment> ConvertWeaponPhysDamageToTextSegments(DamageRange physMinMaxDam)
        {
            return ConvertDamageRangeToTextSegments("weapon-tooltip-phys-dam", physMinMaxDam);
        }

        private static List<UiTextSegment> ConvertWeaponSpellDamageToTextSegments(DamageRange spellMinMaxDam)
        {
            return ConvertDamageRangeToTextSegments("weapon-tooltip-spell-dam", spellMinMaxDam);
        }

        private static List<UiTextSegment> ConvertDamageRangeToTextSegments(string localizationKey, DamageRange damageRange)
        {
            string localizedString = localizationGateway.GetLocalizedString(localizationKey);
            string formattedString = string.Format(localizedString, damageRange.MinDamage, damageRange.MaxDamage);
            return MarkupTextParser.Parse(formattedString);
        }

        private static List<UiTextSegment> ConvertWeaponCritChanceToTextSegments(int critChanceCents)
        {
            string localizedString = localizationGateway.GetLocalizedString("weapon-tooltip-crit-chance");
            string formattedString = string.Format(localizedString, critChanceCents / 100.0);
            return MarkupTextParser.Parse(formattedString);
        }

        private static List<UiTextSegment> ConvertWeaponSkillsPerSecondToTextSegments(double skillsPerSecond)
        {
            string skillsPerSecondTwoDecimal = skillsPerSecond.ToString("F2");
            string localizedString = localizationGateway.GetLocalizedString("weapon-tooltip-skills-per-second");
            string formattedString = string.Format(localizedString, skillsPerSecondTwoDecimal);
            return MarkupTextParser.Parse(formattedString);
        }

        private static List<List<UiTextSegment>> ConvertItemImplicitsToTextSegments(InventoryItemPresentationContext itemContext)
        {
            List<List<UiTextSegment>> result = new List<List<UiTextSegment>>();
            AffixesPresentationContext affixes = itemContext.Affixes;

            for (int i = 0; i < affixes.Implicits.Length; i++)
            {
                IAffixPresentationContext affix = affixes.Implicits[i];
                result.Add(ConvertAffixToTextSegments(affix));
            }

            return result;
        }

        private static List<List<UiTextSegment>> ConvertArmorPresentationContextBaseStatsToTooltipTextSegments(ArmorPresentationContext armorContext, ItemClass itemClass)
        {
            List<List<UiTextSegment>> result = new List<List<UiTextSegment>>();

            result.Add(ConvertItemClassToTextSegment(itemClass));
            result.Add(ConvertArmorValueToTextSegments(armorContext.ArmorValue));
            result.Add(ConvertArmorMovementSpeedAddendToTextSegments(armorContext.MovementSpeedAddend));

            return result;
        }

        private static List<List<UiTextSegment>> ConvertRecoveryPotionPresentationContextBaseStatsToTooltipTextSegments(RecoveryPotionPresentationContext recoveryPotionContext, ItemClass itemClass)
        {
            List<List<UiTextSegment>> result = new List<List<UiTextSegment>>();

            result.Add(ConvertItemClassToTextSegment(itemClass));
            result.Add(ConvertRecoveryPotionRecoveryAmountToTextSegments(recoveryPotionContext.RecoveryAmount));
            result.Add(ConvertRecoveryPotionUsesToTextSegments(recoveryPotionContext.Uses));

            return result;
        }

        private static List<List<UiTextSegment>> ConvertItemClassToTooltipForJewelry(ItemClass itemClass)
        {
            List<List<UiTextSegment>> result = new List<List<UiTextSegment>>();

            result.Add(ConvertItemClassToTextSegment(itemClass));

            return result;
        }

        private static List<UiTextSegment> ConvertItemClassToTextSegment(ItemClass itemClass)
        {
            List<UiTextSegment> result = new List<UiTextSegment>();
            string localizedClassName = enumLocalizationGateway.GetLocalizedEnumString<ItemClass>(itemClass);

            result.Add(new UiTextSegment(localizedClassName, false));

            return result;
        }

        private static List<UiTextSegment> ConvertArmorValueToTextSegments(int armorValue)
        {
            return ConvertIntegerToTextSegments("armor-tooltip-armor", armorValue);
        }

        private static List<UiTextSegment> ConvertArmorMovementSpeedAddendToTextSegments(int movementSpeedAddend)
        {
            return ConvertIntegerToTextSegments("armor-tooltip-movement-speed", movementSpeedAddend);
        }

        private static List<UiTextSegment> ConvertRecoveryPotionUsesToTextSegments(int uses)
        {
            return ConvertIntegerToTextSegments("life-potion-tooltip-usages", uses);
        }

        private static List<UiTextSegment> ConvertRecoveryPotionRecoveryAmountToTextSegments(int recoveryAmount)
        {
            return ConvertIntegerToTextSegments("life-potion-tooltip-heal-value", recoveryAmount);
        }

        private static List<UiTextSegment> ConvertIntegerToTextSegments(string localizationKey, int value)
        {
            string localizedString = localizationGateway.GetLocalizedString(localizationKey);
            string formattedString = string.Format(localizedString, value);
            return MarkupTextParser.Parse(formattedString);
        }

        private static List<UiTextSegment> ConvertAffixToTextSegments(IAffixPresentationContext affix)
        {
            List<UiTextSegment> result = new List<UiTextSegment>();
            string affixUiText = localizationGateway.GetLocalizedString(affix.Name);

            string formattedAffixText = string.Format(affixUiText, affix.GetValues());

            result.Add(new UiTextSegment(formattedAffixText, false));

            return result;
        }
    }
}