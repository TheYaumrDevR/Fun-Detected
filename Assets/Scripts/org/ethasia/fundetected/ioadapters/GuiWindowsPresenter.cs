using System.Collections.Generic;

using Org.Ethasia.Fundetected.Interactors.Presentation;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class GuiWindowsPresenter : IGuiWindowsPresenter
    {
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
                    builder.SetMainHand(ConvertEquipmentSlotPresentationContext(weapon.ItemPresentationContext));
                }
                else if (weapon.SlotPosition == EquipmentSlotPositions.OFF_HAND)
                {
                    builder.SetOffHand(ConvertEquipmentSlotPresentationContext(weapon.ItemPresentationContext));
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
                        builder.SetHead(ConvertEquipmentSlotPresentationContext(armor.ItemPresentationContext));
                        break;
                    case EquipmentSlotPositions.CHEST:
                        builder.SetChest(ConvertEquipmentSlotPresentationContext(armor.ItemPresentationContext));
                        break;
                    case EquipmentSlotPositions.HANDS:
                        builder.SetHands(ConvertEquipmentSlotPresentationContext(armor.ItemPresentationContext));
                        break;
                    case EquipmentSlotPositions.FEET:
                        builder.SetFeet(ConvertEquipmentSlotPresentationContext(armor.ItemPresentationContext));
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
                        builder.SetBelt(ConvertEquipmentSlotPresentationContext(jewelry.ItemPresentationContext));
                        break;
                    case EquipmentSlotPositions.LEFT_RING:
                        builder.SetLeftRing(ConvertEquipmentSlotPresentationContext(jewelry.ItemPresentationContext));
                        break;
                    case EquipmentSlotPositions.RIGHT_RING:
                        builder.SetRightRing(ConvertEquipmentSlotPresentationContext(jewelry.ItemPresentationContext));
                        break;
                    case EquipmentSlotPositions.AMULET:
                        builder.SetNeck(ConvertEquipmentSlotPresentationContext(jewelry.ItemPresentationContext));
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
                        builder.SetLeftMostPotion(ConvertEquipmentSlotPresentationContext(potion.ItemPresentationContext));
                        break;
                    case EquipmentSlotPositions.MIDDLE_LEFT_POTION:
                        builder.SetLeftMiddlePotion(ConvertEquipmentSlotPresentationContext(potion.ItemPresentationContext));
                        break;
                    case EquipmentSlotPositions.MIDDLE_POTION:
                        builder.SetMiddlePotion(ConvertEquipmentSlotPresentationContext(potion.ItemPresentationContext));
                        break;
                    case EquipmentSlotPositions.MIDDLE_RIGHT_POTION:
                        builder.SetRightMiddlePotion(ConvertEquipmentSlotPresentationContext(potion.ItemPresentationContext));
                        break;
                    case EquipmentSlotPositions.OUTER_RIGHT_POTION:
                        builder.SetRightMostPotion(ConvertEquipmentSlotPresentationContext(potion.ItemPresentationContext));
                        break;
                }
            }
        }

        private EquipmentSlotRenderContext ConvertEquipmentSlotPresentationContext(InventoryItemPresentationContext context)
        {
            return new EquipmentSlotRenderContext.Builder()
                .SetItemImagePath(context.ItemId)
                .SetIsEquipped(context.CanBeEquipped)
                .Build();
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
                    parentContext = ConvertAndAddInventoryRenderContext(weaponContext.ItemContext, parentContext);
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
                    parentContext = ConvertAndAddInventoryRenderContext(armorContext.ItemContext, parentContext);
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
                    parentContext = ConvertAndAddInventoryRenderContext(jewelryContext, parentContext);
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
                    parentContext = ConvertAndAddInventoryRenderContext(recoveryPotionContext.ItemContext, parentContext);
                }
            }

            return parentContext;
        }

        private InventoryGridRenderContext ConvertAndAddInventoryRenderContext(InventoryItemPresentationContext itemContext, InventoryGridRenderContext inventoryGridRenderContext)
        {
            for (int x = 0; x < itemContext.DimensionX; x++)
            {
                for (int y = 0; y < itemContext.DimensionY; y++)
                {
                    if (x == 0 && y == 0)
                    {
                        InventorySlotRenderContext slotRenderContext = new InventorySlotRenderContext.Builder()
                            .ShouldRenderSomething(true)
                            .WithItemImageName(itemContext.ItemId)
                            .WithCanBeEquipped(itemContext.CanBeEquipped)
                            .Build();

                        inventoryGridRenderContext.AddSlotRenderContext(itemContext.TopLeftCornerX, itemContext.TopLeftCornerY, slotRenderContext);
                    }
                    else
                    {
                        InventorySlotRenderContext slotRenderContext = new InventorySlotRenderContext.Builder()
                            .ShouldRenderSomething(true)
                            .WithCanBeEquipped(itemContext.CanBeEquipped)
                            .Build();

                        inventoryGridRenderContext.AddSlotRenderContext(itemContext.TopLeftCornerX + x, itemContext.TopLeftCornerY + y, slotRenderContext);
                    }
                }
            }

            return inventoryGridRenderContext;
        }
    }
}