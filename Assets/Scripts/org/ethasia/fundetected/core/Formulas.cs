namespace Org.Ethasia.Fundetected.Core
{
    public class Formulas
    {
        public static int CalculatePhysicalDamageAfterReduction(int incomingDamage, int armor)
        {
            if (0 == armor)
            {
                return incomingDamage;
            }

            return (5 * incomingDamage * incomingDamage) / (armor + 5 * incomingDamage);
        }
    }
}