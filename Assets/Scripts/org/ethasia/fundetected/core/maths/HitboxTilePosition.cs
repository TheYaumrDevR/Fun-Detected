namespace Org.Ethasia.Fundetected.Core
{
    public struct HitboxTilePosition
    {
        public readonly int X;
        public readonly int Y;

        public HitboxTilePosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object otherObject)
        {
            if (otherObject == null || GetType() != otherObject.GetType())
            {
                return false;
            }

            HitboxTilePosition other = (HitboxTilePosition)otherObject;
            return X == other.X && Y == other.Y;
        }     

        public override int GetHashCode()
        {
            return X ^ Y;
        }         
    }
}