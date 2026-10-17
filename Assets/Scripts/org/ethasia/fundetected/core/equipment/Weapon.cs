using Org.Ethasia.Fundetected.Core.Equipment.Affixes;
using Org.Ethasia.Fundetected.Core.Items;
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

        public TotalLocalWeaponStats TotalStats
        {
            get;
            private set;
        }

        public override void OnEquip(StatsFromEquipment statsFromEquipment, EquipmentSlotTypes slotType)
        {
            base.OnEquip(statsFromEquipment, slotType);

            if (slotType == EquipmentSlotTypes.MAIN_HAND)
            {
                statsFromEquipment.IncreasePlusMinMaxPhysicalDamageWithRightHandMeleeAttacksBy(TotalStats.PhysicalDamage.MinDamage, TotalStats.PhysicalDamage.MaxDamage);
                statsFromEquipment.IncreasePlusRightHandWeaponRange(WeaponRange);
                statsFromEquipment.SetRightHandWeaponSkillsPerSecond(TotalStats.SkillsPerSecond);
            }
            else if (slotType == EquipmentSlotTypes.OFF_HAND)
            {
                statsFromEquipment.IncreasePlusMinMaxPhysicalDamageWithLeftHandMeleeAttacksBy(TotalStats.PhysicalDamage.MinDamage, TotalStats.PhysicalDamage.MaxDamage);
                statsFromEquipment.IncreasePlusLeftHandWeaponRange(WeaponRange);
                statsFromEquipment.SetLeftHandWeaponSkillsPerSecond(TotalStats.SkillsPerSecond);
            }
        }

        public override void OnUnequip(StatsFromEquipment statsFromEquipment, EquipmentSlotTypes slotType)
        {
            base.OnUnequip(statsFromEquipment, slotType);

            if (slotType == EquipmentSlotTypes.MAIN_HAND)
            {
                statsFromEquipment.DecreasePlusMinMaxPhysicalDamageWithRightHandMeleeAttacksBy(TotalStats.PhysicalDamage.MinDamage, TotalStats.PhysicalDamage.MaxDamage);
                statsFromEquipment.DecreasePlusRightHandWeaponRange(WeaponRange);
                statsFromEquipment.ClearRightHandWeaponSkillsPerSecond();
            }
            else if (slotType == EquipmentSlotTypes.OFF_HAND)
            {
                statsFromEquipment.DecreasePlusMinMaxPhysicalDamageWithLeftHandMeleeAttacksBy(TotalStats.PhysicalDamage.MinDamage, TotalStats.PhysicalDamage.MaxDamage);
                statsFromEquipment.DecreasePlusLeftHandWeaponRange(WeaponRange);
                statsFromEquipment.ClearLeftHandWeaponSkillsPerSecond();
            }
        }

        protected override void ApplyLocalAffixes()
        {
            LocalModifiers.Reset();

            foreach (EquipmentAffix prefix in prefixes)
            {
                prefix.ApplyLocalWeaponEffects(LocalModifiers);
            }

            foreach (EquipmentAffix suffix in suffixes)
            {
                suffix.ApplyLocalWeaponEffects(LocalModifiers);
            }

            RecalculateTotalStats();
        }

        public override void Accept(ItemVisitor visitor)
        {
            visitor.Visit(this);
        }

        protected override Item CloneActual()
        {
            Weapon result = new Weapon();
            result.MinToMaxPhysicalDamage = MinToMaxPhysicalDamage?.Clone();
            result.MinToMaxSpellDamage = MinToMaxSpellDamage?.Clone();
            result.SkillsPerSecond = SkillsPerSecond;
            result.CriticalStrikeChance = CriticalStrikeChance;
            result.WeaponRange = WeaponRange;
            result.LocalModifiers = LocalModifiers.Clone();

            Clone(result);

            result.RecalculateTotalStats();

            return result;
        }

        private void RecalculateTotalStats()
        {
            TotalStats = TotalLocalWeaponStats.CalculateFrom(this);
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
                result.RecalculateTotalStats();

                FillEquipmentFields(result);

                return result;
            }
        }
    }
}