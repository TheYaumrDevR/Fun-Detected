namespace Org.Ethasia.Fundetected.Interactors
{
    public struct PortalProperties
    {
        public bool AreSet
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

        public int Width;
        public int Height;

        public PortalProperties(int x, int y)
        {
            X = x;
            Y = y;
            Width = 1;
            Height = 1;
            AreSet = true;
        }

        public static PortalProperties CreateUnset()
        {
            PortalProperties result = new PortalProperties(0, 0);
            result.AreSet = false;

            return result;
        }
    }
}