using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Items
{
    public class ItemInventory
    {
        private ItemInInventoryShape[,] inventoryGrid = new ItemInInventoryShape[12, 5];

        public ItemInInventoryShape ReplaceItemAt(ItemInInventoryShape item, PositionImmutable position)
        {
            ItemInInventoryShape lastItemInGrid = null;
            for (int x = 0; x < item.Width; x++)
            {
                for (int y = 0; y < item.Height; y++)
                {
                    PositionImmutable gridCellPos = new PositionImmutable(position.X + x, position.Y + y);
                    if (GridPositionIsOutsideGrid(gridCellPos))
                    {
                        return null;
                    }

                    ItemInInventoryShape currentItemInGrid = inventoryGrid[gridCellPos.X, gridCellPos.Y];
                    if (currentItemInGrid != null)
                    {
                        if (lastItemInGrid != null && !currentItemInGrid.IsSameItemInstanceAs(lastItemInGrid))
                        {
                            return null; // positions occupied by at least two different items, cannot replace
                        }

                        lastItemInGrid = currentItemInGrid;
                    }
                }
            }

            PutItemInGrid(new ItemInventoryShapeWithPosition(item, position));
            lastItemInGrid?.RemoveFromItemGrid();

            return lastItemInGrid;
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
                        return true; // item placed successfully
                    }

                    y = highestOccupiedYPosition;
                }
            }

            return false;
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

            for (int x = 0; x < item.Width; x++)
            {
                for (int y = 0; y < item.Height; y++)
                {
                    inventoryGrid[position.X + x, position.Y + y] = item;
                }
            }

            item.AddToItemGridAtPosition(position);
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