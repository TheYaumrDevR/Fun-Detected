using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct WeaponPresentationContext
    {
        public DamageRange MinToMaxPhysicalDamage
        {
            get;
            private set;
        }

        public DamageRange MinToMaxSpellDamage
        {
            get;
            private set;
        }

        public double SkillsPerSecond
        {
            get;
            private set;
        }

        public int CriticalStrikeChance
        {
            get;
            private set;
        }

        public bool IsPhysicalDamageModified
        {
            get;
            private set;
        }

        public bool IsSpellDamageModified
        {
            get;
            private set;
        }

        public bool IsSkillsPerSecondModified
        {
            get;
            private set;
        }

        public bool IsCriticalStrikeChanceModified
        {
            get;
            private set;
        }

        public class Builder
        {
            private WeaponPresentationContext result;

            public Builder WithMinToMaxPhysicalDamage(DamageRange value)
            {
                result.MinToMaxPhysicalDamage = value;
                return this;
            }

            public Builder WithMinToMaxSpellDamage(DamageRange value)
            {
                result.MinToMaxSpellDamage = value;
                return this;
            }

            public Builder WithSkillsPerSecond(double value)
            {
                result.SkillsPerSecond = value;
                return this;
            }

            public Builder WithCriticalStrikeChance(int value)
            {
                result.CriticalStrikeChance = value;
                return this;
            }

            public Builder WithIsPhysicalDamageModified(bool value)
            {
                result.IsPhysicalDamageModified = value;
                return this;
            }

            public Builder WithIsSpellDamageModified(bool value)
            {
                result.IsSpellDamageModified = value;
                return this;
            }

            public Builder WithIsSkillsPerSecondModified(bool value)
            {
                result.IsSkillsPerSecondModified = value;
                return this;
            }

            public Builder WithIsCriticalStrikeChanceModified(bool value)
            {
                result.IsCriticalStrikeChanceModified = value;
                return this;
            }

            public WeaponPresentationContext Build()
            {
                return result;
            }
        }
    }
}