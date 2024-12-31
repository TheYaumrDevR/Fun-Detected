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

        public PortalProperties(int x, int y)
        {
            X = x;
            Y = y;
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