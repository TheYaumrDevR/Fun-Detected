namespace Org.Ethasia.Fundetected.Core.Map
{
    public class DamageRange
    {
        public int MinDamage;
        public int MaxDamage;

        public DamageRange(int minDamage, int maxDamage)
        {
            this.MaxDamage = maxDamage;
            this.MinDamage = minDamage;
        }

        public void Negate()
        {
            MinDamage = -MinDamage;
            MaxDamage = -MaxDamage;
        }

        public void Add(DamageRange other)
        {
            MinDamage += other.MinDamage;
            MaxDamage += other.MaxDamage;
        }

        public void Add(int min, int max)
        {
            MinDamage += min;
            MaxDamage += max;
        }

        public void Subtract(int min, int max)
        {
            MinDamage -= min;
            MaxDamage -= max;
        }

        public void Multiply(float multiplier)
        {
            MinDamage = (int)(MinDamage * multiplier);
            MaxDamage = (int)(MaxDamage * multiplier);
        }

        public void SetToZero()
        {
            MinDamage = 0;
            MaxDamage = 0;
        }

        public DamageRange Clone()
        {
            return new DamageRange(MinDamage, MaxDamage);
        }
    }
}