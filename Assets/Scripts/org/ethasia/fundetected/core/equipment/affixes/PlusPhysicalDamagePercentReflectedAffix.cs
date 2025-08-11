namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusPhysicalDamagePercentReflectedAffix : EquipmentAffix
    {
        private int plusPhysicalDamagePercentValue;

        public PlusPhysicalDamagePercentReflectedAffix(int plusPhysicalDamagePercentValue) : base(AffixTypes.PREFIX)
        {
            this.plusPhysicalDamagePercentValue = plusPhysicalDamagePercentValue;
        }

        public override void RerollValue(IntegerMinMaxIncrementRollableEquipmentAffix rerollStrategy)
        {
            plusPhysicalDamagePercentValue = rerollStrategy.RerollValue();
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusPhysicalDamagePercentReflectedBy(plusPhysicalDamagePercentValue);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusPhysicalDamagePercentReflectedBy(plusPhysicalDamagePercentValue);
        }

        public override void ApplyLocalWeaponEffects(LocalWeaponModifiers localWeaponModifiers)
        {

        }

        public override void UnApplyLocalWeaponEffects(LocalWeaponModifiers localWeaponModifiers)
        {

        }

        public override void ApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers)
        {

        }

        public override void UnApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers)
        {

        }
    }
}