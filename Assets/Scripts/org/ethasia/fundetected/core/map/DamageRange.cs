namespace Org.Ethasia.Fundetected.Core.Map
{
    public class DamageRange
    {
        public int minDamage;
        public int maxDamage;

        public DamageRange(int minDamage, int maxDamage)
        {
            this.maxDamage = maxDamage;
            this.minDamage = minDamage;
        }
    }
}