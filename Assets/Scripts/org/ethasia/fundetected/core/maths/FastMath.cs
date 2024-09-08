using System;

namespace Org.Ethasia.Fundetected.Core.Maths
{
    public class FastMath
    {
        private static readonly double[] RoundAdjustments = CreateRoundAdjustments();

        public static double Round(double value)
        {
            return FastMath.Floor(value + 0.5);
        }

        public static double Round(double value, int decimalPlaces)
        {
            double adjustment = RoundAdjustments[decimalPlaces];
            return FastMath.Floor(value * adjustment + 0.5) / adjustment;
        }        

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

        private static double[] CreateRoundAdjustments()
        {
            double[] result = new double[15];
            
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Math.Pow(10, i);
            }

            return result;
        }
    }
}