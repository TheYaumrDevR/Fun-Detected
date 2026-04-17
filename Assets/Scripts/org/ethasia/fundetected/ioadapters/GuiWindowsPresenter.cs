using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Interactors.Presentation;
using Org.Ethasia.Fundetected.Ioadapters.Presentation;
using Org.Ethasia.Fundetected.Ioadapters.Presentation.UI;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class GuiWindowsPresenter : IGuiWindowsPresenter
    {
        private ILocalizationGateway localizationGateway = TechnicalFactory.GetInstance().CreateLocalizationGateway();
        private IEnumLocalizationGateway enumLocalizationGateway = TechnicalFactory.GetInstance().CreateEnumLocalizationGateway();

        public void ShowMapSelectionWindowForSingletonMap(string mapName, string destinationPortalId, string mapInstanceId)
        {
            IGuiWindowsController guiWindowsController = TechnicalFactory.GetInstance().GetGuiWindowsControllerInstance();

            MapSelectionWindowContext mapSelectionWindowContent = new MapSelectionWindowContext.Builder()
                .SetMapName(mapName)
                .SetMapIds(new List<string> { mapInstanceId })
                .SetDestinationPortalId(destinationPortalId)
                .SetShowNewInstanceButton(false)
                .Build();
            
            guiWindowsController.OpenMapSelectionWindow(mapSelectionWindowContent);
        }

        public void ShowMapSelectionWindow(string mapName, string destinationPortalId, List<string> mapInstanceIds)
        {
            IGuiWindowsController guiWindowsController = TechnicalFactory.GetInstance().GetGuiWindowsControllerInstance();

            MapSelectionWindowContext mapSelectionWindowContent = new MapSelectionWindowContext.Builder()
                .SetMapName(mapName)
                .SetMapIds(mapInstanceIds)
                .SetDestinationPortalId(destinationPortalId)
                .SetShowNewInstanceButton(true)
                .Build();
            
            guiWindowsController.OpenMapSelectionWindow(mapSelectionWindowContent);
        }

        public void OpenInventoryWindow(InventoryPresentationContext context)
        {
            IGuiWindowsController guiWindowsController = TechnicalFactory.GetInstance().GetGuiWindowsControllerInstance();

            InventoryRenderContext inventoryRenderContext = ConvertInventoryPresentationContext(context);
            guiWindowsController.OpenInventoryWindow(inventoryRenderContext);
        }

        private InventoryRenderContext ConvertInventoryPresentationContext(InventoryPresentationContext context)
        {
            EquipmentSlotsRenderContext equipmentSlotsRenderContext = ConvertEquipmentSlotsPresentationContext(context.EquipmentSlotsPresentationContext);
            InventoryGridRenderContext inventoryGridRenderContext = ConvertInventoryGridPresentationContext(context.InventoryGridPresentationContext);

            return new InventoryRenderContext(equipmentSlotsRenderContext, inventoryGridRenderContext);
        }

        private EquipmentSlotsRenderContext ConvertEquipmentSlotsPresentationContext(EquipmentSlotsPresentationContext context)
        {
            EquipmentSlotsRenderContext.Builder builder = new EquipmentSlotsRenderContext.Builder();

            ConvertEquippedWeaponsContexts(context, builder);
            ConvertEquippedArmorsContexts(context, builder);
            ConvertEquippedJewelryContexts(context, builder);
            ConvertEquippedRecoveryPotionsContexts(context, builder);

            return builder.Build();
        }

        private void ConvertEquippedWeaponsContexts(EquipmentSlotsPresentationContext context, EquipmentSlotsRenderContext.Builder builder)
        {
            foreach (var weapon in context.EquippedWeapons)
            {
                if (weapon.SlotPosition == EquipmentSlotPositions.MAIN_HAND)
                {
                    builder.SetMainHand(ItemPresentationToRenderContextConverter.ConvertWeaponEquipmentSlotPresentationContext(weapon.ItemPresentationContext, weapon.WeaponPresentationContext));
                }
                else if (weapon.SlotPosition == EquipmentSlotPositions.OFF_HAND)
                {
                    builder.SetOffHand(ItemPresentationToRenderContextConverter.ConvertWeaponEquipmentSlotPresentationContext(weapon.ItemPresentationContext, weapon.WeaponPresentationContext));
                }
            }
        }

        private void ConvertEquippedArmorsContexts(EquipmentSlotsPresentationContext context, EquipmentSlotsRenderContext.Builder builder)
        {
            foreach (var armor in context.EquippedArmors)
            {
                switch (armor.SlotPosition)
                {
                    case EquipmentSlotPositions.HEAD:
                        builder.SetHead(ItemPresentationToRenderContextConverter.ConvertArmorEquipmentSlotPresentationContext(armor.ItemPresentationContext, armor.ArmorPresentationContext));
                        break;
                    case EquipmentSlotPositions.CHEST:
                        builder.SetChest(ItemPresentationToRenderContextConverter.ConvertArmorEquipmentSlotPresentationContext(armor.ItemPresentationContext, armor.ArmorPresentationContext));
                        break;
                    case EquipmentSlotPositions.HANDS:
                        builder.SetHands(ItemPresentationToRenderContextConverter.ConvertArmorEquipmentSlotPresentationContext(armor.ItemPresentationContext, armor.ArmorPresentationContext));
                        break;
                    case EquipmentSlotPositions.FEET:
                        builder.SetFeet(ItemPresentationToRenderContextConverter.ConvertArmorEquipmentSlotPresentationContext(armor.ItemPresentationContext, armor.ArmorPresentationContext));
                        break;
                }
            }
        }

        private void ConvertEquippedJewelryContexts(EquipmentSlotsPresentationContext context, EquipmentSlotsRenderContext.Builder builder)
        {
            foreach (var jewelry in context.EquippedJewelry)
            {
                switch (jewelry.SlotPosition)
                {
                    case EquipmentSlotPositions.BELT:
                        builder.SetBelt(ItemPresentationToRenderContextConverter.ConvertEquipmentSlotPresentationContext(jewelry.ItemPresentationContext));
                        break;
                    case EquipmentSlotPositions.LEFT_RING:
                        builder.SetLeftRing(ItemPresentationToRenderContextConverter.ConvertEquipmentSlotPresentationContext(jewelry.ItemPresentationContext));
                        break;
                    case EquipmentSlotPositions.RIGHT_RING:
                        builder.SetRightRing(ItemPresentationToRenderContextConverter.ConvertEquipmentSlotPresentationContext(jewelry.ItemPresentationContext));
                        break;
                    case EquipmentSlotPositions.AMULET:
                        builder.SetNeck(ItemPresentationToRenderContextConverter.ConvertEquipmentSlotPresentationContext(jewelry.ItemPresentationContext));
                        break;
                }
            }
        }

        private void ConvertEquippedRecoveryPotionsContexts(EquipmentSlotsPresentationContext context, EquipmentSlotsRenderContext.Builder builder)
        {
            foreach (var potion in context.EquippedRecoveryPotions)
            {
                switch (potion.SlotPosition)
                {
                    case EquipmentSlotPositions.OUTER_LEFT_POTION:
                        builder.SetLeftMostPotion(ItemPresentationToRenderContextConverter.ConvertRecoveryPotionEquipmentSlotPresentationContext(potion.ItemPresentationContext, potion.RecoveryPotionPresentationContext));
                        break;
                    case EquipmentSlotPositions.MIDDLE_LEFT_POTION:
                        builder.SetLeftMiddlePotion(ItemPresentationToRenderContextConverter.ConvertRecoveryPotionEquipmentSlotPresentationContext(potion.ItemPresentationContext, potion.RecoveryPotionPresentationContext));
                        break;
                    case EquipmentSlotPositions.MIDDLE_POTION:
                        builder.SetMiddlePotion(ItemPresentationToRenderContextConverter.ConvertRecoveryPotionEquipmentSlotPresentationContext(potion.ItemPresentationContext, potion.RecoveryPotionPresentationContext));
                        break;
                    case EquipmentSlotPositions.MIDDLE_RIGHT_POTION:
                        builder.SetRightMiddlePotion(ItemPresentationToRenderContextConverter.ConvertRecoveryPotionEquipmentSlotPresentationContext(potion.ItemPresentationContext, potion.RecoveryPotionPresentationContext));
                        break;
                    case EquipmentSlotPositions.OUTER_RIGHT_POTION:
                        builder.SetRightMostPotion(ItemPresentationToRenderContextConverter.ConvertRecoveryPotionEquipmentSlotPresentationContext(potion.ItemPresentationContext, potion.RecoveryPotionPresentationContext));
                        break;
                }
            }
        }

        private InventoryGridRenderContext ConvertInventoryGridPresentationContext(InventoryGridPresentationContext toConvert)
        {
            InventoryGridRenderContext result = new InventoryGridRenderContext();

            result = ConvertWeaponPresentationContexts(toConvert, result);
            result = ConvertArmorPresentationContexts(toConvert, result);
            result = ConvertJewelryPresentationContexts(toConvert, result);
            result = ConvertRecoveryPotionPresentationContexts(toConvert, result);

            return result;
        }

        private InventoryGridRenderContext ConvertWeaponPresentationContexts(InventoryGridPresentationContext toConvert, InventoryGridRenderContext parentContext)
        {
            if (toConvert.WeaponsPresentationContexts != null)
            {
                foreach (var weaponContext in toConvert.WeaponsPresentationContexts)
                {
                    parentContext = ConvertAndAddInventoryWeaponRenderContext(weaponContext, parentContext);
                }
            }

            return parentContext;
        }

        private InventoryGridRenderContext ConvertArmorPresentationContexts(InventoryGridPresentationContext toConvert, InventoryGridRenderContext parentContext)
        {
            if (toConvert.ArmorsPresentationContexts != null)
            {
                foreach (var armorContext in toConvert.ArmorsPresentationContexts)
                {
                    parentContext = ConvertAndAddInventoryArmorRenderContext(armorContext, parentContext);
                }
            }

            return parentContext;
        }

        private InventoryGridRenderContext ConvertJewelryPresentationContexts(InventoryGridPresentationContext toConvert, InventoryGridRenderContext parentContext)
        {
            if (toConvert.JewelriesPresentationContexts != null)
            {
                foreach (var jewelryContext in toConvert.JewelriesPresentationContexts)
                {
                    parentContext = ConvertAndAddInventoryPlainItemRenderContext(jewelryContext, parentContext);
                }
            }

            return parentContext;
        }

        private InventoryGridRenderContext ConvertRecoveryPotionPresentationContexts(InventoryGridPresentationContext toConvert, InventoryGridRenderContext parentContext)
        {
            if (toConvert.RecoveryPotionsPresentationContexts != null)
            {
                foreach (var recoveryPotionContext in toConvert.RecoveryPotionsPresentationContexts)
                {
                    parentContext = ConvertAndAddInventoryRecoveryPotionRenderContext(recoveryPotionContext, parentContext);
                }
            }

            return parentContext;
        }

        private InventoryGridRenderContext ConvertAndAddInventoryWeaponRenderContext(InventoryWeaponPresentationContext inventoryWeaponContext, InventoryGridRenderContext inventoryGridRenderContext)
        {
            var itemContext = inventoryWeaponContext.ItemContext;
            var weaponContext = inventoryWeaponContext.WeaponContext;
            var tooltip = ConvertWeaponPresentationContext(weaponContext, itemContext);

            return ConvertAndAddInventoryItemRenderContext(itemContext, inventoryGridRenderContext, tooltip);
        }

        private InventoryGridRenderContext ConvertAndAddInventoryArmorRenderContext(InventoryArmorPresentationContext inventoryArmorContext, InventoryGridRenderContext inventoryGridRenderContext)
        {
            var itemContext = inventoryArmorContext.ItemContext;
            var armorContext = inventoryArmorContext.ArmorContext;
            var tooltip = ConvertArmorPresentationContext(armorContext, itemContext);

            return ConvertAndAddInventoryItemRenderContext(itemContext, inventoryGridRenderContext, tooltip);
        }

        private InventoryGridRenderContext ConvertAndAddInventoryPlainItemRenderContext(
            InventoryItemPresentationContext itemContext, 
            InventoryGridRenderContext inventoryGridRenderContext)
        {
            var tooltip = ConvertPlainItemPresentationContextToTooltipContext(itemContext);
            return ConvertAndAddInventoryItemRenderContext(itemContext, inventoryGridRenderContext, tooltip);
        }

        private InventoryGridRenderContext ConvertAndAddInventoryRecoveryPotionRenderContext(InventoryRecoveryPotionPresentationContext inventoryRecoveryPotionContext, InventoryGridRenderContext inventoryGridRenderContext)
        {
            var itemContext = inventoryRecoveryPotionContext.ItemContext;
            var recoveryPotionContext = inventoryRecoveryPotionContext.RecoveryPotionContext;
            var tooltip = ConvertRecoveryPotionPresentationContext(recoveryPotionContext, itemContext);

            return ConvertAndAddInventoryItemRenderContext(itemContext, inventoryGridRenderContext, tooltip);
        }

        private InventoryGridRenderContext ConvertAndAddInventoryItemRenderContext(
            InventoryItemPresentationContext itemContext, 
            InventoryGridRenderContext inventoryGridRenderContext, 
            ItemTooltipRenderContext? tooltipRenderContext = null)
        {
            for (int x = 0; x < itemContext.DimensionX; x++)
            {
                for (int y = 0; y < itemContext.DimensionY; y++)
                {
                    InventorySlotRenderContext.Builder builder = new InventorySlotRenderContext.Builder()
                        .ShouldRenderSomething(true)
                        .WithCanBeEquipped(itemContext.CanBeEquipped);

                    if (x == 0 && y == 0)
                    {
                        builder.WithItemImageName(itemContext.ItemId);
                    }

                    if (tooltipRenderContext != null)
                    {
                        builder.WithToolTipRenderContext(tooltipRenderContext.Value);
                    }

                    InventorySlotRenderContext slotRenderContext = builder.Build();
                    inventoryGridRenderContext.AddSlotRenderContext(
                        itemContext.TopLeftCornerX + x, 
                        itemContext.TopLeftCornerY + y, 
                        slotRenderContext);
                }
            }

            return inventoryGridRenderContext;
        }

        private ItemTooltipRenderContext ConvertWeaponPresentationContext(WeaponPresentationContext weaponContext, InventoryItemPresentationContext itemContext)
        {
            return new ItemTooltipRenderContext.Builder()
                .WithItemName(itemContext.ItemId)
                .WithItemBaseTypeName(itemContext.ItemId)
                .WithItemPotential(itemContext.ItemPotential)
                .WithItemHeaderLines(ConvertWeaponPresentationContextBaseStatsToTooltipTextSegments(weaponContext, itemContext.ItemClass))
                .WithItemImplicitLines(ConvertItemImplicitsToTextSegments(itemContext))
                .Build();
        }

        private ItemTooltipRenderContext ConvertArmorPresentationContext(ArmorPresentationContext armorContext, InventoryItemPresentationContext itemContext)
        {
            return new ItemTooltipRenderContext.Builder()
                .WithItemName(itemContext.ItemId)
                .WithItemBaseTypeName(itemContext.ItemId)
                .WithItemPotential(itemContext.ItemPotential)
                .WithItemHeaderLines(ConvertArmorPresentationContextBaseStatsToTooltipTextSegments(armorContext, itemContext.ItemClass))
                .WithItemImplicitLines(ConvertItemImplicitsToTextSegments(itemContext))
                .Build();
        }

        private ItemTooltipRenderContext ConvertPlainItemPresentationContextToTooltipContext(InventoryItemPresentationContext itemContext)
        {
            return new ItemTooltipRenderContext.Builder()
                .WithItemName(itemContext.ItemId)
                .WithItemBaseTypeName(itemContext.ItemId)
                .WithItemPotential(itemContext.ItemPotential)
                .WithItemHeaderLines(ConvertItemClassToTooltipForJewelry(itemContext.ItemClass))
                .WithItemImplicitLines(ConvertItemImplicitsToTextSegments(itemContext))
                .Build();
        }

        private ItemTooltipRenderContext ConvertRecoveryPotionPresentationContext(RecoveryPotionPresentationContext recoveryPotionContext, InventoryItemPresentationContext itemContext)
        {
            return new ItemTooltipRenderContext.Builder()
                .WithItemName(itemContext.ItemId)
                .WithItemBaseTypeName(itemContext.ItemId)
                .WithItemPotential(itemContext.ItemPotential)
                .WithItemHeaderLines(ConvertRecoveryPotionPresentationContextBaseStatsToTooltipTextSegments(recoveryPotionContext, itemContext.ItemClass))
                .WithItemImplicitLines(ConvertItemImplicitsToTextSegments(itemContext))
                .Build();
        }

        private List<List<UiTextSegment>> ConvertWeaponPresentationContextBaseStatsToTooltipTextSegments(WeaponPresentationContext weaponContext, ItemClass itemClass)
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

        private List<List<UiTextSegment>> ConvertArmorPresentationContextBaseStatsToTooltipTextSegments(ArmorPresentationContext armorContext, ItemClass itemClass)
        {
            List<List<UiTextSegment>> result = new List<List<UiTextSegment>>();

            result.Add(ConvertItemClassToTextSegment(itemClass));
            result.Add(ConvertArmorValueToTextSegments(armorContext.ArmorValue));
            result.Add(ConvertArmorMovementSpeedAddendToTextSegments(armorContext.MovementSpeedAddend));

            return result;
        }

        private List<List<UiTextSegment>> ConvertItemClassToTooltipForJewelry(ItemClass itemClass)
        {
            List<List<UiTextSegment>> result = new List<List<UiTextSegment>>();

            result.Add(ConvertItemClassToTextSegment(itemClass));

            return result;
        }

        private List<List<UiTextSegment>> ConvertRecoveryPotionPresentationContextBaseStatsToTooltipTextSegments(RecoveryPotionPresentationContext recoveryPotionContext, ItemClass itemClass)
        {
            List<List<UiTextSegment>> result = new List<List<UiTextSegment>>();

            result.Add(ConvertItemClassToTextSegment(itemClass));
            result.Add(ConvertRecoveryPotionRecoveryAmountToTextSegments(recoveryPotionContext.RecoveryAmount));
            result.Add(ConvertRecoveryPotionUsesToTextSegments(recoveryPotionContext.Uses));

            return result;
        }

        private List<UiTextSegment> ConvertWeaponPhysDamageToTextSegments(DamageRange physMinMaxDam)
        {
            return ConvertDamageRangeToTextSegments("weapon-tooltip-phys-dam", physMinMaxDam);
        }

        private List<UiTextSegment> ConvertWeaponSpellDamageToTextSegments(DamageRange spellMinMaxDam)
        {
            return ConvertDamageRangeToTextSegments("weapon-tooltip-spell-dam", spellMinMaxDam);
        }

        private List<UiTextSegment> ConvertDamageRangeToTextSegments(string localizationKey, DamageRange damageRange)
        {
            string localizedString = localizationGateway.GetLocalizedString(localizationKey);
            string formattedString = string.Format(localizedString, damageRange.MinDamage, damageRange.MaxDamage);
            return MarkupTextParser.Parse(formattedString);
        }

        private List<UiTextSegment> ConvertWeaponCritChanceToTextSegments(int critChanceCents)
        {
            string localizedString = localizationGateway.GetLocalizedString("weapon-tooltip-crit-chance");
            string formattedString = string.Format(localizedString, critChanceCents / 100.0);
            return MarkupTextParser.Parse(formattedString);
        }

        private List<UiTextSegment> ConvertWeaponSkillsPerSecondToTextSegments(double skillsPerSecond)
        {
            string skillsPerSecondTwoDecimal = skillsPerSecond.ToString("F2");
            string localizedString = localizationGateway.GetLocalizedString("weapon-tooltip-skills-per-second");
            string formattedString = string.Format(localizedString, skillsPerSecondTwoDecimal);
            return MarkupTextParser.Parse(formattedString);
        }

        private List<UiTextSegment> ConvertArmorValueToTextSegments(int armorValue)
        {
            return ConvertIntegerToTextSegments("armor-tooltip-armor", armorValue);
        }

        private List<UiTextSegment> ConvertArmorMovementSpeedAddendToTextSegments(int movementSpeedAddend)
        {
            return ConvertIntegerToTextSegments("armor-tooltip-movement-speed", movementSpeedAddend);
        }

        private List<UiTextSegment> ConvertRecoveryPotionUsesToTextSegments(int uses)
        {
            return ConvertIntegerToTextSegments("life-potion-tooltip-usages", uses);
        }

        private List<UiTextSegment> ConvertRecoveryPotionRecoveryAmountToTextSegments(int recoveryAmount)
        {
            return ConvertIntegerToTextSegments("life-potion-tooltip-heal-value", recoveryAmount);
        }

        private List<UiTextSegment> ConvertIntegerToTextSegments(string localizationKey, int value)
        {
            string localizedString = localizationGateway.GetLocalizedString(localizationKey);
            string formattedString = string.Format(localizedString, value);
            return MarkupTextParser.Parse(formattedString);
        }

        private List<UiTextSegment> ConvertItemClassToTextSegment(ItemClass itemClass)
        {
            List<UiTextSegment> result = new List<UiTextSegment>();
            string localizedClassName = enumLocalizationGateway.GetLocalizedEnumString<ItemClass>(itemClass);

            result.Add(new UiTextSegment(localizedClassName, false));

            return result;
        }

        private List<List<UiTextSegment>> ConvertItemImplicitsToTextSegments(InventoryItemPresentationContext itemContext)
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

        private List<UiTextSegment> ConvertAffixToTextSegments(IAffixPresentationContext affix)
        {
            List<UiTextSegment> result = new List<UiTextSegment>();
            string affixUiText = localizationGateway.GetLocalizedString(affix.Name);

            string formattedAffixText = string.Format(affixUiText, affix.GetValues());

            result.Add(new UiTextSegment(formattedAffixText, false));

            return result;
        }
    }
}