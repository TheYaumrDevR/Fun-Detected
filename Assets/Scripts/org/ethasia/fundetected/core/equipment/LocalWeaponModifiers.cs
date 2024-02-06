namespace Org.Ethasia.Fundetected.Core.Equipment
{
    public class LocalWeaponModifiers
    {
        public DamageRange PlusMinToMaxPhysicalDamage
        {
            get;
            private set;
        }

        public DamageRange PlusMinToMaxFireDamage
        {
            get;
            private set;
        }

        public DamageRange PlusMinToMaxColdDamage
        {
            get;
            private set;
        }

        public DamageRange PlusMinToMaxLightningDamage
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

        public void IncreasePlusMinToMaxColdDamageBy(int min, int max)
        {
            PlusMinToMaxColdDamage.minDamage += min;
            PlusMinToMaxColdDamage.maxDamage += max;
        }     

        public void DecreasePlusMinToMaxColdDamageBy(int min, int max)
        {
            PlusMinToMaxColdDamage.minDamage -= min;
            PlusMinToMaxColdDamage.maxDamage -= max;
        }

        public void IncreasePlusMinToMaxFireDamageBy(int min, int max)
        {
            PlusMinToMaxFireDamage.minDamage += min;
            PlusMinToMaxFireDamage.maxDamage += max;
        }

        public void DecreasePlusMinToMaxFireDamageBy(int min, int max)
        {
            PlusMinToMaxFireDamage.minDamage -= min;
            PlusMinToMaxFireDamage.maxDamage -= max;
        }

        public void IncreasePlusMinToMaxLightningDamageBy(int min, int max)
        {
            PlusMinToMaxLightningDamage.minDamage += min;
            PlusMinToMaxLightningDamage.maxDamage += max;
        }

        public void DecreasePlusMinToMaxLightningDamageBy(int min, int max)
        {
            PlusMinToMaxLightningDamage.minDamage -= min;
            PlusMinToMaxLightningDamage.maxDamage -= max;
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