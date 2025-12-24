namespace Org.Ethasia.Fundetected.Interactors.Map
{
    public struct InfiniteHealingWell
    {
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

        public InfiniteHealingWell(int x, int y)
        {
            X = x;
            Y = y;
            Width = 10;
            Height = 12;
        }
    }
}