using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{
    [UxmlElement]
    public partial class InventoryWindow : FunDetectedWindowExtension
    {
        private const string EQUIPMENT_SLOTS_PANEL_NAME = "inventory-equipment-panel";

        private EquipmentSlotsPanel equipmentSlotsPanel;

        protected override string GetBaseWindowName() 
        {
            return "base-window";
        }

        protected override void Initialize()
        {
            var visualTree = Resources.Load<VisualTreeAsset>("UIElements/InventoryWindow");
            visualTree.CloneTree(this);

            equipmentSlotsPanel = this.Q<EquipmentSlotsPanel>(EQUIPMENT_SLOTS_PANEL_NAME);
        }

        public void Open(InventoryRenderContext renderContext)
        {
            this.IsOpen = true;

            if (equipmentSlotsPanel != null)
            {
                equipmentSlotsPanel.RenderEquippedItems(renderContext.EquipmentSlotsRenderContext);
            }
        }

        protected override List<VisualElement> FindChildrenToMoveToContentArea()
        {
            var result = new List<VisualElement>();

            if (BaseWindow != null)
            {
                foreach (var child in BaseWindow.Children())
                {
                    if (child.name.StartsWith("inventory"))
                    {
                        result.Add(child);
                    }
                }
            }

            return result;
        }
    }
}