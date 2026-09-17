using UnityEngine;
using UnityEngine.UIElements;

using Org.Ethasia.Fundetected.Interactors.Items;
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

        private PlayerInventoryInteractor playerInventoryInteractor = new PlayerInventoryInteractor();

        public InventoryGridPanel()
        {
            var visualTree = Resources.Load<VisualTreeAsset>("UIElements/InventoryGridPanel");
            visualTree.CloneTree(this);

            grid = this.Q<VisualElement>(GRID_CELLS_LAYER_NAME);
            itemImagesLayer = this.Q<VisualElement>(ITEM_IMAGES_LAYER_NAME);

            alreadyRenderedItems = new VisualElement[GRID_COLUMNS, GRID_ROWS];

            CreateInventorySlots();

            RegisterCallback<ClickEvent>(OnGridClicked);
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
                        inventorySlots[i, j].RenderNothing();
                        inventorySlots[i, j].RenderItem(slotRenderContext);
                    }

                    UnrenderItemImage(i, j);
                    RenderItemImage(slotRenderContext, i, j);
                }
            }
        }

        public void RenderNoItemAt(InventoryGridItemDimensions itemDimensions)
        {
            for (int x = itemDimensions.TopLeftCornerX; x < itemDimensions.TopLeftCornerX + itemDimensions.Width; x++)
            {
                for (int y = itemDimensions.TopLeftCornerY; y < itemDimensions.TopLeftCornerY + itemDimensions.Height; y++)
                {
                    if (inventorySlots[x, y] != null)
                    {
                        inventorySlots[x, y].RenderNothing();
                        UnrenderItemImage(x, y);
                    }
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

                    cell.SetPositionInGrid(row, col);

                    grid.Add(cell);
                    inventorySlots[row, col] = cell;
                }
            }            
        }

        private void OnGridClicked(ClickEvent clickEvent)
        {
            IIconOnCursorRenderer iconOnCursorRenderer = TechnicalFactory.GetInstance().GetIconOnCursorRendererInstance();

            Vector2 localClickPosition = this.WorldToLocal(clickEvent.position);

            if (!iconOnCursorRenderer.HasItemOnCursor())
            {
                int cellX = Mathf.FloorToInt(localClickPosition.x / CELL_SIZE);
                int cellY = Mathf.FloorToInt(localClickPosition.y / CELL_SIZE);

                inventorySlots[cellX, cellY]?.OnPointerDown(null);

                return;
            }

            (int itemWidth, int itemHeight) = playerInventoryInteractor.GetItemOnCursorDimensions();

            InventoryGridItemDimensions targetDimensions = CalculateTargetDropDimensions(localClickPosition, itemWidth, itemHeight);

            if (targetDimensions.Width > 0 && targetDimensions.Height > 0)
            {
                DropItemIntoBackendGrid(targetDimensions);
            }
        }

        private InventoryGridItemDimensions CalculateTargetDropDimensions(Vector2 localClickPosition, int itemWidth, int itemHeight)
        {
            float itemTopLeftX = localClickPosition.x - (itemWidth * CELL_SIZE) / 2f + CELL_SIZE / 2f;
            float itemTopLeftY = localClickPosition.y - (itemHeight * CELL_SIZE) / 2f + CELL_SIZE / 2f;

            int cellX = Mathf.FloorToInt(itemTopLeftX / CELL_SIZE);
            int cellY = Mathf.FloorToInt(itemTopLeftY / CELL_SIZE);

            if (cellX + itemWidth <= 0 || cellY + itemHeight <= 0 || cellX >= GRID_COLUMNS || cellY >= GRID_ROWS)
            {
                return new InventoryGridItemDimensions.Builder()
                    .SetTopLeftCornerX(0)
                    .SetTopLeftCornerY(0)
                    .SetWidth(0)
                    .SetHeight(0)
                    .Build();
            }

            cellX = Mathf.Clamp(cellX, 0, GRID_COLUMNS - itemWidth);
            cellY = Mathf.Clamp(cellY, 0, GRID_ROWS - itemHeight);

            return new InventoryGridItemDimensions.Builder()
                .SetTopLeftCornerX(cellX)
                .SetTopLeftCornerY(cellY)
                .SetWidth(itemWidth)
                .SetHeight(itemHeight)
                .Build();
        }

        private void DropItemIntoBackendGrid(InventoryGridItemDimensions targetDimensions)
        {
            playerInventoryInteractor.TryDropItemOnCursorIntoGridAt(targetDimensions.TopLeftCornerX, targetDimensions.TopLeftCornerY);
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

            itemImage.pickingMode = PickingMode.Ignore;
        }

        private void AddItemImageToLayer(VisualElement itemImage, int posX, int posY)
        {
            if (itemImagesLayer != null)
            {
                itemImagesLayer.Add(itemImage);
            }

            alreadyRenderedItems[posX, posY] = itemImage;            
        }

        private void UnrenderItemImage(int posX, int posY)
        {
            if (alreadyRenderedItems[posX, posY] != null)
            {
                RemoveItemImageFromLayer(alreadyRenderedItems[posX, posY], posX, posY);
            }
        }

        private void RemoveItemImageFromLayer(VisualElement itemImage, int posX, int posY)
        {
            if (itemImagesLayer != null)
            {
                itemImagesLayer.Remove(itemImage);
            }

            alreadyRenderedItems[posX, posY] = null;
        }
    }
}