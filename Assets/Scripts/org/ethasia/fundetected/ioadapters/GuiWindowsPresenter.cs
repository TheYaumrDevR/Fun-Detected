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
            return new EquipmentSlotsRenderContext.Builder()
                .SetMainHand(ConvertEquipmentSlotPresentationContext(context.MainHand))
                .SetOffHand(ConvertEquipmentSlotPresentationContext(context.OffHand))
                .SetHead(ConvertEquipmentSlotPresentationContext(context.Head))
                .SetChest(ConvertEquipmentSlotPresentationContext(context.Chest))
                .SetHands(ConvertEquipmentSlotPresentationContext(context.Hands))
                .SetFeet(ConvertEquipmentSlotPresentationContext(context.Feet))
                .SetBelt(ConvertEquipmentSlotPresentationContext(context.Belt))
                .SetLeftRing(ConvertEquipmentSlotPresentationContext(context.LeftRing))
                .SetRightRing(ConvertEquipmentSlotPresentationContext(context.RightRing))
                .SetNeck(ConvertEquipmentSlotPresentationContext(context.Neck))
                .SetLeftMostPotion(ConvertEquipmentSlotPresentationContext(context.LeftMostPotion))
                .SetLeftMiddlePotion(ConvertEquipmentSlotPresentationContext(context.LeftMiddlePotion))
                .SetMiddlePotion(ConvertEquipmentSlotPresentationContext(context.MiddlePotion))
                .SetRightMiddlePotion(ConvertEquipmentSlotPresentationContext(context.RightMiddlePotion))
                .SetRightMostPotion(ConvertEquipmentSlotPresentationContext(context.RightMostPotion))
                .Build();
        }

        private EquipmentSlotRenderContext ConvertEquipmentSlotPresentationContext(EquipmentSlotPresentationContext context)
        {
            return new EquipmentSlotRenderContext.Builder()
                .SetItemImagePath(context.ItemId)
                .SetIsEquipped(context.IsLegallyEquipped)
                .Build();
        }

        private InventoryGridRenderContext ConvertInventoryGridPresentationContext(InventoryGridPresentationContext toConvert)
        {
            InventoryGridRenderContext result = new InventoryGridRenderContext();

            if (toConvert.ItemsPresentationContexts != null)
            {
                foreach (var itemContext in toConvert.ItemsPresentationContexts)
                {
                    result = ConvertAndAddInventoryRenderContext(itemContext, result);
                }
            }

            return result;
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