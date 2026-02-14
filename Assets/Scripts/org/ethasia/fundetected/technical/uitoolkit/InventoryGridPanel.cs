using UnityEngine;
using UnityEngine.UIElements;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{

    [UxmlElement]
    public partial class InventoryGridPanel : VisualElement
    {
        private const int GRID_ROWS = 5;
        private const int GRID_COLUMNS = 12;
        private const int CELL_SIZE = 34;

        private const string GRID_CELLS_LAYER_NAME = "grid-cells";
        private const string ITEM_IMAGES_LAYER_NAME = "item-images";

        private InventorySlot[,] inventorySlots;
        private VisualElement[,] alreadyRenderedItems;
        private VisualElement grid;
        private VisualElement itemImagesLayer;

        public InventoryGridPanel()
        {
            var visualTree = Resources.Load<VisualTreeAsset>("UIElements/InventoryGridPanel");
            visualTree.CloneTree(this);

            grid = this.Q<VisualElement>(GRID_CELLS_LAYER_NAME);
            itemImagesLayer = this.Q<VisualElement>(ITEM_IMAGES_LAYER_NAME);

            alreadyRenderedItems = new VisualElement[GRID_COLUMNS, GRID_ROWS];

            CreateInventorySlots();
        }

        public void RenderInventoryItems(InventoryGridRenderContext renderContext)
        {
            for (int i = 0; i < GRID_COLUMNS; i++)
            {
                for (int j = 0; j < GRID_ROWS; j++)
                {
                    InventorySlotRenderContext slotRenderContext = renderContext.SlotRenderContexts[i, j];

                    if (inventorySlots[i, j] != null)
                    {
                        inventorySlots[i, j].RenderItem(slotRenderContext);
                    }

                    RenderItemImage(slotRenderContext, i, j);
                }
            }
        }

        private void CreateInventorySlots()
        {
            inventorySlots = new InventorySlot[GRID_COLUMNS, GRID_ROWS];

            for (int row = 0; row < GRID_COLUMNS; row++)
            {
                for (int col = 0; col < GRID_ROWS; col++)
                {
                    var cell = new InventorySlot();

                    grid.Add(cell);
                    inventorySlots[row, col] = cell;
                }
            }            
        }

        private void RenderItemImage(InventorySlotRenderContext slotRenderContext, int posX, int posY)
        {
            if (!string.IsNullOrEmpty(slotRenderContext.ItemImageName))
            {
                if (alreadyRenderedItems[posX, posY] == null)
                {
                    Sprite itemSprite = Resources.Load<Sprite>(slotRenderContext.ItemImageName);

                    var itemImage = CreateItemImage(itemSprite);
                    StyleItemImage(itemImage, itemSprite, posX, posY);  
                    AddItemImageToLayer(itemImage, posX, posY);
                }
            }
        }

        private VisualElement CreateItemImage(Sprite itemSprite)
        {
            var result = new VisualElement();

            result.style.backgroundImage = new StyleBackground(
                itemSprite
            );

            return result;
        }

        private void StyleItemImage(VisualElement itemImage, Sprite itemSprite, int posX, int posY)
        {
            itemImage.style.position = Position.Absolute;
            itemImage.style.left = posX * CELL_SIZE;
            itemImage.style.top = posY * CELL_SIZE;

            itemImage.style.width = itemSprite.rect.width;
            itemImage.style.height = itemSprite.rect.height;
        }

        private void AddItemImageToLayer(VisualElement itemImage, int posX, int posY)
        {
            if (itemImagesLayer != null)
            {
                itemImagesLayer.Add(itemImage);
            }

            alreadyRenderedItems[posX, posY] = itemImage;            
        }
    }
}