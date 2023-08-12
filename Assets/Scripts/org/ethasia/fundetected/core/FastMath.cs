namespace Org.Ethasia.Fundetected.Core
{
    public class FastMath
    {
        public static int Floor(double x) 
        {
            int xCast = (int)x;
            return x < xCast ? xCast - 1 : xCast;            
        }

        public static int Ceil(double x)
        {
            return -Floor(-x);
        }

        public static bool NearlyEqual(float a, float b, float threshold)
        {
            return ((a < b) ? (b - a) : (a - b)) <= threshold;
        }
    }
}