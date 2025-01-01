namespace Org.Ethasia.Fundetected.Core.Map
{
    public class MapPortal
    {
        public Position Position
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
            private Position position;
            private int width;
            private int height;

            public Builder SetPosition(Position value)
            {
                position = value;
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

            public MapPortal Build()
            {
                MapPortal result = new MapPortal();

                result.Position = position;
                result.Width = width;
                result.Height = height;

                return result;
            }
        }
    }
}