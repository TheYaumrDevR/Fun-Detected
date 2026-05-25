namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public struct InventoryGridItemDimensions
    {
        public int TopLeftCornerX
        {
            get;
            private set;
        }

        public int TopLeftCornerY
        {
            get;
            private set;
        }

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

        public class Builder
        {
            private int topLeftCornerX;
            private int topLeftCornerY;
            private int width;
            private int height;

            public Builder SetTopLeftCornerX(int value)
            {
                topLeftCornerX = value;
                return this;
            }

            public Builder SetTopLeftCornerY(int value)
            {
                topLeftCornerY = value;
                return this;
            }

            public Builder SetWidth(int value)
            {
                width = value;
                return this;
            }

            public Builder SetHeight(int value)
            {
                height = value;
                return this;
            }

            public InventoryGridItemDimensions Build()
            {
                return new InventoryGridItemDimensions
                {
                    TopLeftCornerX = topLeftCornerX,
                    TopLeftCornerY = topLeftCornerY,
                    Width = width,
                    Height = height
                };
            }
        }
    }
}