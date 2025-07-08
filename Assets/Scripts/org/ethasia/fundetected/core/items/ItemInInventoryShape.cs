using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Items
{
    public class ItemInInventoryShape
    {
        private Item Item;
        private PositionImmutable? topLeftCornerPosInItemGrid;

        public int Width
        {
            get;
            private set;
        }

        public int Height
        {
            get;
            private set;
        }


        private ItemInInventoryShape(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public static ItemInInventoryShape CreateOneByOne(Item item)
        {
            ItemInInventoryShape result = new ItemInInventoryShape(1, 1);
            result.Item = item;

            return result;
        }

        public static ItemInInventoryShape CreateTwoByOne(Item item)
        {
            ItemInInventoryShape result = new ItemInInventoryShape(2, 1);
            result.Item = item;

            return result;
        }

        public static ItemInInventoryShape CreateOneByTwo(Item item)
        {
            ItemInInventoryShape result = new ItemInInventoryShape(1, 2);
            result.Item = item;

            return result;
        }

        public static ItemInInventoryShape CreateOneByThree(Item item)
        {
            ItemInInventoryShape result = new ItemInInventoryShape(1, 3);
            result.Item = item;

            return result;
        }

        public static ItemInInventoryShape CreateOneByFour(Item item)
        {
            ItemInInventoryShape result = new ItemInInventoryShape(1, 4);
            result.Item = item;

            return result;
        }

        public static ItemInInventoryShape CreateTwoByTwo(Item item)
        {
            ItemInInventoryShape result = new ItemInInventoryShape(2, 2);
            result.Item = item;

            return result;
        }

        public static ItemInInventoryShape CreateTwoByThree(Item item)
        {
            ItemInInventoryShape result = new ItemInInventoryShape(2, 3);
            result.Item = item;

            return result;
        }

        public static ItemInInventoryShape CreateTwoByFour(Item item)
        {
            ItemInInventoryShape result = new ItemInInventoryShape(2, 4);
            result.Item = item;

            return result;
        }

        public void AddToItemGridAtPosition(PositionImmutable position)
        {
            this.topLeftCornerPosInItemGrid = position;
        }

        public void RemoveFromItemGrid()
        {
            this.topLeftCornerPosInItemGrid = null;
        }

        public bool IsShapeEqualTo(ItemInInventoryShape other)
        {
            return this.Width == other.Width && this.Height == other.Height;
        }

        public bool IsSameItemInstanceAs(ItemInInventoryShape other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Item == other.Item;
        }

        public bool IsAtPosition(PositionImmutable position)
        {
            if (!topLeftCornerPosInItemGrid.HasValue)
            {
                return false; 
            }

            return this.topLeftCornerPosInItemGrid.Equals(position);
        }
    }
}