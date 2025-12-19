using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core
{
    public class StatsFromEquipment
    {
        public int PlusIntelligence
        {
            get;
            private set;
        }

        public int PlusAgility
        {
            get;
            private set;
        }

        public int PlusStrength
        {
            get;
            private set;
        }

        public int PlusMaximumLife
        {
            get;
            private set;
        }

        public int PlusMaximumMana
        {
            get;
            private set;
        }

        public int IncreasedMaximumLifeInPercent
        {
            get;
            private set;
        }

        public int PlusAccuracy
        {
            get;
            private set;
        }

        public float PhysicalDamagePercentStolenAsLife
        {
            get;
            private set;
        }

        public float PhysicalDamagePercentStolenAsMana
        {
            get;
            private set;
        }

        public int PlusFireResistance
        {
            get;
            private set;
        }

        public int PlusLightningResistance
        {
            get;
            private set;
        }

        public int PlusColdResistance
        {
            get;
            private set;
        }

        public int PlusMagicResistance
        {
            get;
            private set;
        }

        public int PlusMaximumFireResistance
        {
            get;
            private set;
        }

        public int PlusMaximumLightningResistance
        {
            get;
            private set;
        }

        public int PlusMaximumColdResistance
        {
            get;
            private set;
        }

        public int PlusMaximumMagicResistance
        {
            get;
            private set;
        }

        public int PlusAllSocketedSpellsLevel
        {
            get;
            private set;
        }

        public int PlusRightHandWeaponRange
        {
            get;
            private set;
        }

        public int PlusLeftHandWeaponRange
        {
            get;
            private set;
        }

        public int IncreasedStunAndBlockRecoveryInPercent
        {
            get;
            private set;
        }

        public int PlusPhysicalDamagePercentReflected
        {
            get;
            private set;
        }

        public DamageRange PlusMinMaxPhysicalDamageWithRightHandMeleeAttacks
        {
            get;
            private set;
        }

        public DamageRange PlusMinMaxPhysicalDamageWithLeftHandMeleeAttacks
        {
            get;
            private set;
        }

        public DamageRange PlusMinMaxPhysicalDamageWithRangedAttacks
        {
            get;
            private set;
        }

        public DamageRange PlusMinMaxPhysicalDamageWithSpells
        {
            get;
            private set;
        }

        public int IncreasedPhysicalDamageInPercent
        {
            get;
            private set;
        }

        public int IncreasedPhysicalDamageWithAttacksInPercent
        {
            get;
            private set;
        }

        public int IncreasedArmourInPercent
        {
            get;
            private set;
        }

        public StatsFromEquipment()
        {
            PlusMinMaxPhysicalDamageWithRightHandMeleeAttacks = new DamageRange(0, 0);
            PlusMinMaxPhysicalDamageWithLeftHandMeleeAttacks = new DamageRange(0, 0);
            PlusMinMaxPhysicalDamageWithRangedAttacks = new DamageRange(0, 0);
            PlusMinMaxPhysicalDamageWithSpells = new DamageRange(0, 0);
        }

        public void IncreasePlusIntelligenceBy(int value)
        {
            PlusIntelligence += value;
        }

        public void IncreasePlusAgilityBy(int value)
        {
            PlusAgility += value;
        }

        public void IncreasePlusStrengthBy(int value)
        {
            PlusStrength += value;
        }

        public void IncreasePlusMaximumLifeBy(int value)
        {
            PlusMaximumLife += value;
        }

        public void IncreasePlusMaximumManaBy(int value)
        {
            PlusMaximumMana += value;
        }

        public void IncreaseIncreasedMaximumLifeInPercentBy(int value)
        {
            IncreasedMaximumLifeInPercent += value;
        }

        public void IncreasePlusAccuracyBy(int value)
        {
            PlusAccuracy += value;
        }

        public void IncreasePhysicalDamagePercentStolenAsLife(float value)
        {
            PhysicalDamagePercentStolenAsLife += value;
        }

        public void IncreasePhysicalDamagePercentStolenAsMana(float value)
        {
            PhysicalDamagePercentStolenAsMana += value;
        }

        public void IncreasePlusFireResistanceBy(int value)
        {
            PlusFireResistance += value;
        }

        public void IncreasePlusLightningResistanceBy(int value)
        {
            PlusLightningResistance += value;
        }

        public void IncreasePlusColdResistanceBy(int value)
        {
            PlusColdResistance += value;
        }

        public void IncreasePlusMagicResistanceBy(int value)
        {
            PlusMagicResistance += value;
        }

        public void IncreasePlusMaximumFireResistanceBy(int value)
        {
            PlusMaximumFireResistance += value;
        }

        public void IncreasePlusMaximumLightningResistanceBy(int value)
        {
            PlusMaximumLightningResistance += value;
        }

        public void IncreasePlusMaximumColdResistanceBy(int value)
        {
            PlusMaximumColdResistance += value;
        }

        public void IncreasePlusMaximumMagicResistanceBy(int value)
        {
            PlusMaximumMagicResistance += value;
        }

        public void IncreasePlusAllSocketedSpellsLevelBy(int value)
        {
            PlusAllSocketedSpellsLevel += value;
        }

        public void IncreaseIncreasedStunAndBlockRecoveryInPercentBy(int value)
        {
            IncreasedStunAndBlockRecoveryInPercent += value;
        }

        public void IncreasePlusPhysicalDamagePercentReflectedBy(int value)
        {
            PlusPhysicalDamagePercentReflected += value;
        }

        public void IncreasePlusMinMaxPhysicalDamageWithAttacksBy(int min, int max)
        {
            PlusMinMaxPhysicalDamageWithRightHandMeleeAttacks.Add(min, max);
            PlusMinMaxPhysicalDamageWithLeftHandMeleeAttacks.Add(min, max);
            PlusMinMaxPhysicalDamageWithRangedAttacks.Add(min, max);
        }

        public void IncreasePlusMinMaxPhysicalDamageWithMeleeAttacksBy(int min, int max)
        {
            PlusMinMaxPhysicalDamageWithRightHandMeleeAttacks.Add(min, max);
            PlusMinMaxPhysicalDamageWithLeftHandMeleeAttacks.Add(min, max);
        }

        public void IncreasePlusMinMaxPhysicalDamageWithRightHandMeleeAttacksBy(int min, int max)
        {
            PlusMinMaxPhysicalDamageWithRightHandMeleeAttacks.Add(min, max);
        }

        public void IncreasePlusMinMaxPhysicalDamageWithLeftHandMeleeAttacksBy(int min, int max)
        {
            PlusMinMaxPhysicalDamageWithLeftHandMeleeAttacks.Add(min, max);
        }

        public void IncreasePlusMinMaxPhysicalDamageWithRangedAttacksBy(int min, int max)
        {
            PlusMinMaxPhysicalDamageWithRangedAttacks.Add(min, max);
        }

        public void IncreasePlusMinMaxPhysicalDamageWithSpellsBy(int min, int max)
        {
            PlusMinMaxPhysicalDamageWithSpells.Add(min, max);
        }

        public void IncreaseIncreasedPhysicalDamageInPercentBy(int value)
        {
            IncreasedPhysicalDamageInPercent += value;
        }

        public void IncreaseIncreasedPhysicalDamageWithAttacksInPercentBy(int value)
        {
            IncreasedPhysicalDamageWithAttacksInPercent += value;
        }

        public void IncreaseIncreasedArmourInPercentBy(int value)
        {
            IncreasedArmourInPercent += value;
        }

        public void IncreasePlusRightHandWeaponRange(int value)
        {
            PlusRightHandWeaponRange += value;
        }

        public void IncreasePlusLeftHandWeaponRange(int value)
        {
            PlusLeftHandWeaponRange += value;
        }

        public void DecreasePlusIntelligenceBy(int value)
        {
            PlusIntelligence -= value;
        }

        public void DecreasePlusAgilityBy(int value)
        {
            PlusAgility -= value;
        }

        public void DecreasePlusStrengthBy(int value)
        {
            PlusStrength -= value;
        }

        public void DecreaseIncreasedMaximumLifeInPercentBy(int value)
        {
            IncreasedMaximumLifeInPercent -= value;
        }

        public void DecreasePlusMaximumManaBy(int value)
        {
            PlusMaximumMana -= value;
        }

        public void DecreasePlusMaximumLifeBy(int value)
        {
            PlusMaximumLife -= value;
        }

        public void DecreasePlusAccuracyBy(int value)
        {
            PlusAccuracy -= value;
        }

        public void DecreasePhysicalDamagePercentStolenAsLife(float value)
        {
            PhysicalDamagePercentStolenAsLife -= value;
        }

        public void DecreasePhysicalDamagePercentStolenAsMana(float value)
        {
            PhysicalDamagePercentStolenAsMana -= value;
        }

        public void DecreasePlusFireResistanceBy(int value)
        {
            PlusFireResistance -= value;
        }

        public void DecreasePlusLightningResistanceBy(int value)
        {
            PlusLightningResistance -= value;
        }

        public void DecreasePlusColdResistanceBy(int value)
        {
            PlusColdResistance -= value;
        }

        public void DecreasePlusMagicResistanceBy(int value)
        {
            PlusMagicResistance -= value;
        }

        public void DecreasePlusMaximumFireResistanceBy(int value)
        {
            PlusMaximumFireResistance -= value;
        }

        public void DecreasePlusMaximumLightningResistanceBy(int value)
        {
            PlusMaximumLightningResistance -= value;
        }

        public void DecreasePlusMaximumColdResistanceBy(int value)
        {
            PlusMaximumColdResistance -= value;
        }

        public void DecreasePlusMaximumMagicResistanceBy(int value)
        {
            PlusMaximumMagicResistance -= value;
        }

        public void DecreasePlusAllSocketedSpellsLevelBy(int value)
        {
            PlusAllSocketedSpellsLevel -= value;
        }

        public void DecreaseIncreasedStunAndBlockRecoveryInPercentBy(int value)
        {
            IncreasedStunAndBlockRecoveryInPercent -= value;
        }

        public void DecreasePlusPhysicalDamagePercentReflectedBy(int value)
        {
            PlusPhysicalDamagePercentReflected -= value;
        }

        public void DecreasePlusMinMaxPhysicalDamageWithAttacksBy(int min, int max)
        {
            PlusMinMaxPhysicalDamageWithRightHandMeleeAttacks.Subtract(min, max);
            PlusMinMaxPhysicalDamageWithLeftHandMeleeAttacks.Subtract(min, max);
            PlusMinMaxPhysicalDamageWithRangedAttacks.Subtract(min, max);
        }

        public void DecreasePlusMinMaxPhysicalDamageWithMeleeAttacksBy(int min, int max)
        {
            PlusMinMaxPhysicalDamageWithRightHandMeleeAttacks.Subtract(min, max);
            PlusMinMaxPhysicalDamageWithLeftHandMeleeAttacks.Subtract(min, max);
        }

        public void DecreasePlusMinMaxPhysicalDamageWithRightHandMeleeAttacksBy(int min, int max)
        {
            PlusMinMaxPhysicalDamageWithRightHandMeleeAttacks.Subtract(min, max);
        }

        public void DecreasePlusMinMaxPhysicalDamageWithLeftHandMeleeAttacksBy(int min, int max)
        {
            PlusMinMaxPhysicalDamageWithLeftHandMeleeAttacks.Subtract(min, max);
        }

        public void DecreasePlusMinMaxPhysicalDamageWithRangedAttacksBy(int min, int max)
        {
            PlusMinMaxPhysicalDamageWithRangedAttacks.Subtract(min, max);
        }

        public void DecreasePlusMinMaxPhysicalDamageWithSpellsBy(int min, int max)
        {
            PlusMinMaxPhysicalDamageWithSpells.Subtract(min, max);
        }

        public void DecreaseIncreasedPhysicalDamageInPercentBy(int value)
        {
            IncreasedPhysicalDamageInPercent -= value;
        }

        public void DecreaseIncreasedArmourInPercentBy(int value)
        {
            IncreasedArmourInPercent -= value;
        }
        
        public void DecreaseIncreasedPhysicalDamageWithAttacksInPercentBy(int value)
        {
            IncreasedPhysicalDamageWithAttacksInPercent -= value;
        }

        public void DecreasePlusRightHandWeaponRange(int value)
        {
            PlusRightHandWeaponRange -= value;
        }

        public void DecreasePlusLeftHandWeaponRange(int value)
        {
            PlusLeftHandWeaponRange -= value;
        }
    }
}