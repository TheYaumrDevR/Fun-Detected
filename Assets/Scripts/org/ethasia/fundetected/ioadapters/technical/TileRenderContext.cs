namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public struct TileRenderContext
    {
        public string TileSetName
        {
            get;
            private set;
        }

        public string TileName
        {
            get;
            private set;
        }

        public int X
        {
            get;
            private set;
        }

        public int Y
        {
            get;
            private set;
        }

        private TileRenderContext(string tileSetName, string tileName, int x, int y)
        {
            TileSetName = tileSetName;
            TileName = tileName;
            X = x;
            Y = y;
        }

        public class Builder
        {
            private string tileSetName;
            private string tileName;
            private int x;
            private int y;

            public Builder SetTileSetName(string value)
            {
                tileSetName = value;
                return this;
            }

            public Builder SetTileName(string value)
            {
                tileName = value;
                return this;
            }

            public Builder SetX(int value)
            {
                x = value;
                return this;
            }

            public Builder SetY(int value)
            {
                y = value;
                return this;
            }

            public TileRenderContext Build()
            {
                return new TileRenderContext(tileSetName, tileName, x, y);
            }
        }
    }
}