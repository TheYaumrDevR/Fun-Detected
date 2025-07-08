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
                    PositionImmutable currentPosition = new PositionImmutable(position.X + x, position.Y + y);
                    if (position.X + x < 0 || position.X + x >= inventoryGrid.GetLength(0) ||
                        position.Y + y < 0 || position.Y + y >= inventoryGrid.GetLength(1))
                    {
                        return null;
                    }

                    ItemInInventoryShape currentItemInGrid = inventoryGrid[position.X + x, position.Y + y];
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

            for (int x = 0; x < item.Width; x++)
            {
                for (int y = 0; y < item.Height; y++)
                {
                    inventoryGrid[position.X + x, position.Y + y] = item;
                }
            }

            item.AddToItemGridAtPosition(position);

            if (lastItemInGrid != null)
            {
                lastItemInGrid.RemoveFromItemGrid();
            }

            return lastItemInGrid;
        }

        public bool AddItemAtNextFreePosition(ItemInInventoryShape item)
        {
            return false;
        }
    }
}