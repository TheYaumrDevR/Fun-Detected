using Org.Ethasia.Fundetected.Core.Equipment.Affixes;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Equipment
{

    public class Weapon : Equipment
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

        public int WeaponRange
        {
            get;
            private set;
        }

        public LocalWeaponModifiers LocalModifiers
        {
            get;
            private set;
        }

        protected override void ApplyLocalAffixes()
        {
            foreach (EquipmentAffix prefix in prefixes)
            {
                prefix.ApplyLocalWeaponEffects(LocalModifiers);
            }

            foreach (EquipmentAffix suffix in suffixes)
            {
                suffix.ApplyLocalWeaponEffects(LocalModifiers);
            }
        }        

        new public class Builder : Equipment.Builder
        {
            private DamageRange minToMaxPhysicalDamage;
            private DamageRange minToMaxSpellDamage;
            private double skillsPerSecond;
            private int criticalStrikeChance;
            private int weaponRange;

            public Weapon.Builder SetMinToMaxPhysicalDamage(DamageRange value)
            {
                this.minToMaxPhysicalDamage = value;
                return this;
            }

            public Weapon.Builder SetMinToMaxSpellDamage(DamageRange value)
            {
                this.minToMaxSpellDamage = value;
                return this;
            }            

            public Weapon.Builder SetSkillsPerSecond(double value)
            {
                this.skillsPerSecond = value;
                return this;
            }         

            public Weapon.Builder SetCriticalStrikeChance(int value)
            {
                this.criticalStrikeChance = value;
                return this;
            }    

            public Weapon.Builder SetWeaponRange(int value)
            {
                this.weaponRange = value;
                return this;
            }               

            public Weapon Build()
            {
                Weapon result = new Weapon();

                result.MinToMaxPhysicalDamage = minToMaxPhysicalDamage;
                result.MinToMaxSpellDamage = minToMaxSpellDamage;
                result.CriticalStrikeChance = criticalStrikeChance;
                result.SkillsPerSecond = skillsPerSecond;
                result.WeaponRange = weaponRange;
                result.LocalModifiers = new LocalWeaponModifiers();

                FillEquipmentFields(result);

                return result;
            }
        }
    }
}