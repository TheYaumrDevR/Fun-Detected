using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Equipment
{
    public readonly struct TotalLocalWeaponStats
    {
        public DamageRange PhysicalDamage { get; }
        public DamageRange LightningDamage { get; }
        public DamageRange ColdDamage { get; }
        public DamageRange FireDamage { get; }
        public DamageRange SpellDamage { get; }
        public double SkillsPerSecond { get; }
        public int CriticalStrikeChance { get; }

        private TotalLocalWeaponStats(Builder builder)
        {
            PhysicalDamage = builder.PhysicalDamage;
            LightningDamage = builder.LightningDamage;
            ColdDamage = builder.ColdDamage;
            FireDamage = builder.FireDamage;
            SpellDamage = builder.SpellDamage;
            SkillsPerSecond = builder.SkillsPerSecond;
            CriticalStrikeChance = builder.CriticalStrikeChance;
        }

        public static TotalLocalWeaponStats CalculateFrom(Weapon weapon)
        {
            LocalWeaponModifiers modifiers = weapon.LocalModifiers;
            DamageRange basePhysicalDamage = weapon.MinToMaxPhysicalDamage;
            DamageRange baseSpellDamage = weapon.MinToMaxSpellDamage;

            int baseMinPhysicalDamage = basePhysicalDamage != null ? basePhysicalDamage.MinDamage : 0;
            int baseMaxPhysicalDamage = basePhysicalDamage != null ? basePhysicalDamage.MaxDamage : 0;

            double physicalDamageIncrease = 1.0 + modifiers.IncreasedPhysicalDamageInPercent / 100.0;
            int resultPhysicalMinDamage = (int)((baseMinPhysicalDamage + modifiers.PlusMinToMaxPhysicalDamage.MinDamage) * physicalDamageIncrease);
            int resultPhysicalMaxDamage = (int)((baseMaxPhysicalDamage + modifiers.PlusMinToMaxPhysicalDamage.MaxDamage) * physicalDamageIncrease);

            int spellMin = baseSpellDamage != null ? baseSpellDamage.MinDamage : 0;
            int spellMax = baseSpellDamage != null ? baseSpellDamage.MaxDamage : 0;

            return new Builder()
                .SetPhysicalDamage(new DamageRange(resultPhysicalMinDamage, resultPhysicalMaxDamage))
                .SetLightningDamage(modifiers.PlusMinToMaxLightningDamage.Clone())
                .SetColdDamage(modifiers.PlusMinToMaxColdDamage.Clone())
                .SetFireDamage(modifiers.PlusMinToMaxFireDamage.Clone())
                .SetSpellDamage(new DamageRange(spellMin, spellMax))
                .SetSkillsPerSecond(weapon.SkillsPerSecond * (1.0 + modifiers.IncreasedAttackSpeedInPercent / 100.0))
                .SetCriticalStrikeChance(weapon.CriticalStrikeChance)
                .Build();
        }

        public class Builder
        {
            internal DamageRange PhysicalDamage;
            internal DamageRange LightningDamage;
            internal DamageRange ColdDamage;
            internal DamageRange FireDamage;
            internal DamageRange SpellDamage;
            internal double SkillsPerSecond;
            internal int CriticalStrikeChance;

            public Builder SetPhysicalDamage(DamageRange value)
            {
                PhysicalDamage = value;
                return this;
            }

            public Builder SetLightningDamage(DamageRange value)
            {
                LightningDamage = value;
                return this;
            }

            public Builder SetColdDamage(DamageRange value)
            {
                ColdDamage = value;
                return this;
            }

            public Builder SetFireDamage(DamageRange value)
            {
                FireDamage = value;
                return this;
            }

            public Builder SetSpellDamage(DamageRange value)
            {
                SpellDamage = value;
                return this;
            }

            public Builder SetSkillsPerSecond(double value)
            {
                SkillsPerSecond = value;
                return this;
            }

            public Builder SetCriticalStrikeChance(int value)
            {
                CriticalStrikeChance = value;
                return this;
            }

            public TotalLocalWeaponStats Build()
            {
                return new TotalLocalWeaponStats(this);
            }
        }
    }
}