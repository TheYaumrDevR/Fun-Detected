namespace Org.Ethasia.Fundetected.Core.Map
{
    public struct AreaDimensions
    {
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

        public int LowestScreenX
        {
            get;
            private set;
        }

        public int LowestScreenY
        {
            get;
            private set;
        }

        public class Builder
        {
            private int width;
            private int height;
            private int lowestScreenX;
            private int lowestScreenY;

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

            public Builder SetLowestScreenX(int value)
            {
                lowestScreenX = value;
                return this;
            }

            public Builder SetLowestScreenY(int value)
            {
                lowestScreenY = value;
                return this;
            }

            public AreaDimensions Build()
            {
                AreaDimensions result = new AreaDimensions();

                result.Width = width;
                result.Height = height;
                result.LowestScreenX = lowestScreenX;
                result.LowestScreenY = lowestScreenY;

                return result;
            }
        }
    }
}