namespace Org.Ethasia.Fundetected.Interactors
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

        public InfiniteHealingWell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}