using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Interactors.Presentation;
using Org.Ethasia.Fundetected.Ioadapters.Presentation;
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
            InventoryGridRenderContext inventoryGridRenderContext = InventoryPresentationToRenderContextConverter.Convert(context.InventoryGridPresentationContext);

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
    }
}