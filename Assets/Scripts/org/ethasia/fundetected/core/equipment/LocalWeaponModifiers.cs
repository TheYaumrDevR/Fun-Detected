namespace Org.Ethasia.Fundetected.Core.Equipment
{
    public class LocalWeaponModifiers
    {
        public DamageRange PlusMinToMaxPhysicalDamage
        {
            get;
            private set;
        }

        public int IncreasedPhysicalDamageInPercent
        {
            get;
            private set;
        }

        public LocalWeaponModifiers()
        {
            PlusMinToMaxPhysicalDamage = new DamageRange(0, 0);
        }

        public void IncreasePlusMinToMaxPhysicalDamageBy(int min, int max)
        {
            PlusMinToMaxPhysicalDamage.minDamage += min;
            PlusMinToMaxPhysicalDamage.maxDamage += max;
        }

        public void DecreasePlusMinToMaxPhysicalDamageBy(int min, int max)
        {
            PlusMinToMaxPhysicalDamage.minDamage -= min;
            PlusMinToMaxPhysicalDamage.maxDamage -= max;
        }

        public void IncreaseIncreasedPhysicalDamageInPercentBy(int value)
        {
            IncreasedPhysicalDamageInPercent += value;
        }

        public void DecreaseIncreasedPhysicalDamageInPercentBy(int value)
        {
            IncreasedPhysicalDamageInPercent -= value;
        }
    }
}