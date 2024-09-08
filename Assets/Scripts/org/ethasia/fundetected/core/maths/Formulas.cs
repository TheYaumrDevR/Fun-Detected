using System;

namespace Org.Ethasia.Fundetected.Core.Maths
{
    public class Formulas
    {
        public static int CalculatePhysicalDamageAfterReduction(int incomingDamage, int armor)
        {
            if (0 == armor)
            {
                return incomingDamage;
            }

            return (5 * (incomingDamage * incomingDamage)) / (armor + 5 * incomingDamage);
        }

        public static int CalculateNonPhysicalDamageAfterReduction(int incomingDamage, float resistanceValue)
        {
            if (0.0f == resistanceValue)
            {
                return incomingDamage;
            }

            return (int)FastMath.Round(incomingDamage * (1.0f - resistanceValue));
        }

        public static float CalculateChanceToHit(int attackerAccuracy, int defenderEvasion)
        {
            double uncappedHitChance = (1.25 * attackerAccuracy) / (attackerAccuracy + Math.Pow((defenderEvasion * 1.0) / 5.0, 0.9));

            double result = uncappedHitChance > 0.5 ? uncappedHitChance : 0.05;
            
            if (result > 1.0)
            {
                return 1.0f;
            }

            return (float)result;
        }        
    }
}