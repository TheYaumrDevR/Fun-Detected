using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusMinMaxGlobalPhysicalDamageWithAttacksAffix : EquipmentAffix
    {
        private int lowerValue;
        private int upperValue;

        public PlusMinMaxGlobalPhysicalDamageWithAttacksAffix(int lowerValue, int upperValue) : base(AffixTypes.PREFIX)
        {
            this.lowerValue = lowerValue;
            this.upperValue = upperValue;
        }

        public override void RerollValue(IntegerMinMaxIncrementRollableEquipmentAffix rerollStrategy)
        {

        }

        public override void RerollValue(IntegerIntervalMinMaxIncrementRollableEquipmentAffix rerollStrategy)
        {
            DamageRange rerolledValues = rerollStrategy.RerollValue();

            lowerValue = rerolledValues.MinDamage;
            upperValue = rerolledValues.MaxDamage;
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusMinMaxPhysicalDamageWithAttacksBy(lowerValue, upperValue);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusMinMaxPhysicalDamageWithAttacksBy(lowerValue, upperValue);
        }

        public override void ApplyLocalWeaponEffects(LocalWeaponModifiers localWeaponModifiers) {}

        public override void UnApplyLocalWeaponEffects(LocalWeaponModifiers localWeaponModifiers) {}

        public override void ApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers) {}

        public override void UnApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers) {}

        public override EquipmentAffix Clone()
        {
            PlusMinMaxGlobalPhysicalDamageWithAttacksAffix copy = new PlusMinMaxGlobalPhysicalDamageWithAttacksAffix(lowerValue, upperValue);
            Clone(copy);

            return copy;
        }        
    }
}