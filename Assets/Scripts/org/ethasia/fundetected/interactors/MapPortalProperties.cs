using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors
{
    public struct MapPortalProperties
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

        public MapPortalProperties(Position position, int width, int height)
        {
            Position = position;
            Width = width;
            Height = height;
        }
    }
}