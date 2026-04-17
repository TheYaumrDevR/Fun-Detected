using UnityEngine;
using UnityEngine.UIElements;

using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{
    public class UiRenderer : IUiRenderer
    {
        private InventoryWindow inventoryWindow;

        public void RenderEquippedItemInInventoryWindow(EquipmentSlotPositions slotPosition, EquipmentSlotRenderContext renderContext)
        {
            var inventoryWindow = GetInventoryWindow();

            if (inventoryWindow != null && inventoryWindow.visible)
            {
                inventoryWindow.RenderEquippedItem(slotPosition, renderContext);
            }
        }

        private InventoryWindow GetInventoryWindow()
        {
            if (inventoryWindow == null)
            {
                var uiDocument = Object.FindAnyObjectByType<UnityEngine.UIElements.UIDocument>();
                if (uiDocument?.rootVisualElement != null)
                {
                    inventoryWindow = uiDocument.rootVisualElement.Q<UIToolkit.InventoryWindow>();
                }
            }

            return inventoryWindow;
        }
    }
}