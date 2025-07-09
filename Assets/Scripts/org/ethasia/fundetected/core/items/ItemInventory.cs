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

            PutItemInGrid(item, position);

            item.AddToItemGridAtPosition(position);
            lastItemInGrid?.RemoveFromItemGrid();

            return lastItemInGrid;
        }

        public bool AddItemAtNextFreePosition(ItemInInventoryShape item)
        {
            for (int x = 0; x < inventoryGrid.GetLength(0); x++)
            {
                for (int y = 0; y < inventoryGrid.GetLength(1); y++)
                {
                    // check if position is free based on item dimensions and if not get the x and y offset (return it as a helper struct)
                }
            }


            return false;
        }

        private bool GridPositionIsOutsideGrid(PositionImmutable position)
        {
            return position.X < 0 || position.X >= inventoryGrid.GetLength(0) ||
                   position.Y < 0 || position.Y >= inventoryGrid.GetLength(1);
        }

        private void PutItemInGrid(ItemInInventoryShape item, PositionImmutable position)
        {
            for (int x = 0; x < item.Width; x++)
            {
                for (int y = 0; y < item.Height; y++)
                {
                    inventoryGrid[position.X + x, position.Y + y] = item;
                }
            }
        }
    }
}