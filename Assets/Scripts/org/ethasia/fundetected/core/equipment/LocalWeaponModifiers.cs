using Org.Ethasia.Fundetected.Core.Map;

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

        public int IncreasedAttackSpeedInPercent
        {
            get;
            private set;
        }

        public LocalWeaponModifiers()
        {
            PlusMinToMaxPhysicalDamage = new DamageRange(0, 0);
            PlusMinToMaxFireDamage = new DamageRange(0, 0);
            PlusMinToMaxColdDamage = new DamageRange(0, 0);
            PlusMinToMaxLightningDamage = new DamageRange(0, 0);
        }

        public void IncreasePlusMinToMaxPhysicalDamageBy(int min, int max)
        {
            PlusMinToMaxPhysicalDamage.Add(min, max);
        }

        public void DecreasePlusMinToMaxPhysicalDamageBy(int min, int max)
        {
            PlusMinToMaxPhysicalDamage.Add(-min, -max);
        }

        public void IncreasePlusMinToMaxColdDamageBy(int min, int max)
        {
            PlusMinToMaxColdDamage.Add(min, max);
        }     

        public void DecreasePlusMinToMaxColdDamageBy(int min, int max)
        {
            PlusMinToMaxColdDamage.Add(-min, -max);
        }

        public void IncreasePlusMinToMaxFireDamageBy(int min, int max)
        {
            PlusMinToMaxFireDamage.Add(min, max);
        }

        public void DecreasePlusMinToMaxFireDamageBy(int min, int max)
        {
            PlusMinToMaxFireDamage.Add(-min, -max);
        }

        public void IncreasePlusMinToMaxLightningDamageBy(int min, int max)
        {
            PlusMinToMaxLightningDamage.Add(min, max);
        }

        public void DecreasePlusMinToMaxLightningDamageBy(int min, int max)
        {
            PlusMinToMaxLightningDamage.Add(-min, -max);
        }   

        public void IncreaseIncreasedPhysicalDamageInPercentBy(int value)
        {
            IncreasedPhysicalDamageInPercent += value;
        }

        public void DecreaseIncreasedPhysicalDamageInPercentBy(int value)
        {
            IncreasedPhysicalDamageInPercent -= value;
        }

        public void IncreaseIncreasedAttackSpeedInPercentBy(int value)
        {
            IncreasedAttackSpeedInPercent += value;
        }

        public void DecreaseIncreasedAttackSpeedInPercentBy(int value)
        {
            IncreasedAttackSpeedInPercent -= value;
        }
    }
}