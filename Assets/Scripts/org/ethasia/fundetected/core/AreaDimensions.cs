namespace Org.Ethasia.Fundetected.Core
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

        public float LowestScreenX
        {
            get;
            private set;
        }

        public float LowestScreenY
        {
            get;
            private set;
        }

        public class Builder
        {
            private int width;
            private int height;
            private float lowestScreenX;
            private float lowestScreenY;

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

            public Builder SetLowestScreenX(float value)
            {
                lowestScreenX = value;
                return this;
            }

            public Builder SetLowestScreenY(float value)
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