using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Items
{
    public class ItemInventoryGrid
    {
        private ItemInInventoryShape[,] inventoryGrid = new ItemInInventoryShape[12, 5];
        private List<ItemInInventoryShape> items = new List<ItemInInventoryShape>();

        public List<ItemInInventoryShape> GetItems()
        {
            return items;
        }

        public ItemReplacementResult ReplaceItemAt(ItemInInventoryShape item, PositionImmutable position)
        {
            ItemInInventoryShape lastItemInGrid = null;
            for (int x = 0; x < item.Width; x++)
            {
                for (int y = 0; y < item.Height; y++)
                {
                    PositionImmutable gridCellPos = new PositionImmutable(position.X + x, position.Y + y);
                    if (GridPositionIsOutsideGrid(gridCellPos))
                    {
                        return ItemReplacementResult.Failed();
                    }

                    ItemInInventoryShape currentItemInGrid = inventoryGrid[gridCellPos.X, gridCellPos.Y];
                    if (currentItemInGrid != null)
                    {
                        if (lastItemInGrid != null && !currentItemInGrid.IsSameItemInstanceAs(lastItemInGrid))
                        {
                            return ItemReplacementResult.Failed(); // positions occupied by at least two different items, cannot replace
                        }

                        lastItemInGrid = currentItemInGrid;
                    }
                }
            }

            RemoveItemFromGrid(lastItemInGrid);
            PutItemInGrid(new ItemInventoryShapeWithPosition(item, position));

            return ItemReplacementResult.Succeeded(lastItemInGrid);
        }

        public bool AddItemAtNextFreePosition(ItemInInventoryShape item)
        {
            for (int x = 0; x < inventoryGrid.GetLength(0); x++)
            {
                if (ItemWidthAtPositionIsOutsideGrid(item, x))
                {
                    return false;
                }

                for (int y = 0; y < inventoryGrid.GetLength(1); y++)
                {
                    if (ItemHeightAtPositionIsOutsideGrid(item, y))
                    {
                        break;
                    }

                    ItemInventoryShapeWithPosition itemWithPosition = ItemInventoryShapeWithPosition.FromItemAndXAndY(item, x, y);
                    int highestOccupiedYPosition = CalculateHighestOccupiedYPosition(itemWithPosition);

                    if (PlaceItemIfHighestOccupiedPositionIsNegative(highestOccupiedYPosition, itemWithPosition))
                    {
                        return true;
                    }

                    y = highestOccupiedYPosition;
                }
            }

            return false;
        }

        public ItemInInventoryShape RemoveItemAt(PositionImmutable position)
        {
            ItemInInventoryShape result = inventoryGrid[position.X, position.Y];
            RemoveItemFromGrid(result);
            
            return result;
        }

        public ItemInInventoryShape GetItemAt(PositionImmutable position)
        {
            if (GridPositionIsOutsideGrid(position))
            {
                return null;
            }

            return inventoryGrid[position.X, position.Y];
        }        

        private bool GridPositionIsOutsideGrid(PositionImmutable position)
        {
            return position.X < 0 || position.X >= inventoryGrid.GetLength(0) ||
                   position.Y < 0 || position.Y >= inventoryGrid.GetLength(1);
        }

        private int CalculateHighestOccupiedYPosition(ItemInventoryShapeWithPosition itemWithPosition)
        {
            int highestOccupiedY = -1;

            ItemInInventoryShape item = itemWithPosition.Item;
            PositionImmutable position = itemWithPosition.Position;

            for (int x = 0; x < item.Width; x++)
            {
                for (int y = 0; y < item.Height; y++)
                {
                    PositionImmutable gridCellPos = new PositionImmutable(position.X + x, position.Y + y);
                    if (inventoryGrid[gridCellPos.X, gridCellPos.Y] != null)
                    {
                        if (gridCellPos.Y > highestOccupiedY)
                        {
                            highestOccupiedY = gridCellPos.Y;
                        }
                    }
                }
            }

            return highestOccupiedY;
        }

        private bool ItemWidthAtPositionIsOutsideGrid(ItemInInventoryShape item, int x)
        {
            return x + item.Width > inventoryGrid.GetLength(0);
        }

        private bool ItemHeightAtPositionIsOutsideGrid(ItemInInventoryShape item, int y)
        {
            return y + item.Height > inventoryGrid.GetLength(1);
        }

        private bool PlaceItemIfHighestOccupiedPositionIsNegative(int highestOccupiedYPosition, ItemInventoryShapeWithPosition itemWithPosition)
        {
            if (highestOccupiedYPosition == -1)
            {
                PutItemInGrid(itemWithPosition);
                return true;
            }

            return false;
        }        

        private void PutItemInGrid(ItemInventoryShapeWithPosition itemWithPosition)
        {
            ItemInInventoryShape item = itemWithPosition.Item;
            PositionImmutable position = itemWithPosition.Position;

            items.Add(item);

            for (int x = 0; x < item.Width; x++)
            {
                for (int y = 0; y < item.Height; y++)
                {
                    inventoryGrid[position.X + x, position.Y + y] = item;
                }
            }

            item.AddToItemGridAtPosition(position);
        }

        private void RemoveItemFromGrid(ItemInInventoryShape itemWithPosition)
        {
            if (itemWithPosition != null)
            {
                Item item = itemWithPosition.Item;
                PositionImmutable position = itemWithPosition.LastTopLeftCornerPosInItemGrid.Value;

                items.Remove(itemWithPosition);

                for (int x = 0; x < itemWithPosition.Width; x++)
                {
                    for (int y = 0; y < itemWithPosition.Height; y++)
                    {
                        inventoryGrid[position.X + x, position.Y + y] = null;
                    }
                }

                itemWithPosition.RemoveFromItemGrid();                
            }
        }

        public struct ItemReplacementResult
        {
            public bool Success
            {
                get;
                private set;
            }

            public ItemInInventoryShape ReplacedItem
            {
                get;
                private set;
            }

            private ItemReplacementResult(bool success, ItemInInventoryShape replacedItem)
            {
                Success = success;
                ReplacedItem = replacedItem;
            }

            public static ItemReplacementResult Failed()
            {
                return new ItemReplacementResult(false, null);
            }

            public static ItemReplacementResult Succeeded(ItemInInventoryShape replacedItem)
            {
                return new ItemReplacementResult(true, replacedItem);
            }
        }

        private class ItemInventoryShapeWithPosition
        {
            public ItemInInventoryShape Item
            {
                get;
                private set;
            }

            public PositionImmutable Position
            {
                get;
                private set;
            }

            public ItemInventoryShapeWithPosition(ItemInInventoryShape item, PositionImmutable position)
            {
                Item = item;
                Position = position;
            }

            public static ItemInventoryShapeWithPosition FromItemAndXAndY(ItemInInventoryShape item, int x, int y)
            {
                return new ItemInventoryShapeWithPosition(item, new PositionImmutable(x, y));
            }
        }
    }
}