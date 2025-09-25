namespace Org.Ethasia.Fundetected.Core.Map
{
    public class Position
    {
        public int X;
        public int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }  

        public void SetFromOtherPosition(Position other)
        {
            X = other.X;
            Y = other.Y;
        }
    }
}