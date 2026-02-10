using UnityEngine;
using UnityEngine.UIElements;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{

    [UxmlElement]
    public partial class InventoryGridPanel : VisualElement
    {
        private const string INVENTORY_SLOT_NAME_SUFFIX = "inventory-slot";

        private InventorySlot[,] inventorySlots;

        public InventoryGridPanel()
        {
            var visualTree = Resources.Load<VisualTreeAsset>("UIElements/InventoryGridPanel");
            visualTree.CloneTree(this);

            inventorySlots = new InventorySlot[12, 5];

            for (int row = 0; row < 12; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    string slotName = $"{row}-{col}-{INVENTORY_SLOT_NAME_SUFFIX}";
                    inventorySlots[row, col] = this.Q<InventorySlot>(slotName);
                }
            }
        }

        public void RenderInventoryItems(InventoryGridRenderContext renderContext)
        {
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    InventorySlotRenderContext slotRenderContext = renderContext.SlotRenderContexts[i, j];

                    if (inventorySlots[i, j] != null)
                    {
                        inventorySlots[i, j].RenderItem(slotRenderContext);
                    }
                }
            }
        }
    }
}