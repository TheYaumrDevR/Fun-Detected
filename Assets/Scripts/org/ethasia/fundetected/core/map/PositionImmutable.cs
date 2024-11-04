namespace Org.Ethasia.Fundetected.Core.Map
{
    public struct PositionImmutable
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

        public PositionImmutable(int x, int y)
        {
            X = x;
            Y = y;
        }     

        public override bool Equals(object other)
        {
            if (null == other || GetType() != other.GetType())
            {
                return false;
            }

            PositionImmutable otherPosition = (PositionImmutable)other;

            return X == otherPosition.X && Y == otherPosition.Y;
        }

        public override int GetHashCode()
        {
            int intermediate = (Y + ((X + 1) / 2));
            return X + (intermediate * intermediate);
        }     
    }
}