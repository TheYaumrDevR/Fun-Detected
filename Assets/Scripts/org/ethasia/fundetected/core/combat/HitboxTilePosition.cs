namespace Org.Ethasia.Fundetected.Core.Combat
{
    public struct HitboxTilePosition
    {
        public readonly int X;
        public readonly int Y;
        public readonly bool IsInvalid;

        public HitboxTilePosition(bool isInvalid)
        {
            X = 0;
            Y = 0;
            IsInvalid = true;
        }

        public HitboxTilePosition(int x, int y)
        {
            X = x;
            Y = y;
            IsInvalid = false;
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