namespace Org.Ethasia.Fundetected.Core.Map
{
    public struct ReloadableTile : ITile
    {
        public string Id
        {
            get;
            private set;
        }

        public int StartX
        {
            get;
            private set;
        }

        public int StartY
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

        private ReloadableTile(string id, int startX, int startY, int width, int height)
        {
            Id = id;
            StartX = startX;
            StartY = startY;
            Width = width;
            Height = height;
        }

        public class Builder
        {
            private string id;
            private int startX;
            private int startY;
            private int width;
            private int height;

            public Builder SetId(string value)
            {
                id = value;
                return this;
            }

            public Builder SetStartX(int value)
            {
                startX = value;
                return this;
            }

            public Builder SetStartY(int value)
            {
                startY = value;
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

            public ReloadableTile Build()
            {
                ReloadableTile result = new ReloadableTile();

                result.Id = id;
                result.StartX = startX;
                result.StartY = startY;
                result.Width = width;
                result.Height = height;

                return result;
            }
        }
    }
}