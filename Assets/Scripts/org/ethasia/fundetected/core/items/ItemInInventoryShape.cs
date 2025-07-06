namespace Org.Ethasia.Fundetected.Core.Items
{
    public class ItemInInventoryShape
    {
        private int width;
        private int height;
        private Item Item;

        private ItemInInventoryShape(int width, int height)
        {
            this.width = width;
            this.height = height;
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
        
        public bool IsShapeEqualTo(ItemInInventoryShape other)
        {
            return this.width == other.width && this.height == other.height;
        }
    }
}