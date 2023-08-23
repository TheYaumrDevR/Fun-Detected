namespace Org.Ethasia.Fundetected.Core.Equipment
{

    public class MeleeWeapon : Equipment
    {
        public DamageRange MinToMaxDamage
        {
            get;
            private set;
        }

        public double AttacksPerSecond
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

        new public class Builder : Equipment.Builder
        {
            private DamageRange minToMaxDamage;
            private double attacksPerSecond;
            private int criticalStrikeChance;
            private int weaponRange;

            public Builder SetMinToMaxDamage(DamageRange value)
            {
                this.minToMaxDamage = value;
                return this;
            }

            public Builder SetAttacksPerSecond(double value)
            {
                this.attacksPerSecond = value;
                return this;
            }         

            public Builder SetCriticalStrikeChance(int value)
            {
                this.criticalStrikeChance = value;
                return this;
            }    

            public Builder SetWeaponRange(int value)
            {
                this.weaponRange = value;
                return this;
            }               

            public MeleeWeapon Build()
            {
                MeleeWeapon result = new MeleeWeapon();

                result.MinToMaxDamage = minToMaxDamage;
                result.CriticalStrikeChance = criticalStrikeChance;
                result.AttacksPerSecond = attacksPerSecond;
                result.WeaponRange = weaponRange;

                FillEquipmentFields(result);

                return result;
            }
        }
    }
}