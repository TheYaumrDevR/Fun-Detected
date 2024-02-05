namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusAccuracyAndIncreasedPhysicalDamageAffix : EquipmentAffix
    {
        private int plusAccuracyValue;
        private int increasedPhysicalDamageValue;

        public PlusAccuracyAndIncreasedPhysicalDamageAffix(int plusAccuracyValue, int increasedPhysicalDamageValue) : base(AffixTypes.PREFIX)
        {
            this.plusAccuracyValue = plusAccuracyValue;
            this.increasedPhysicalDamageValue = increasedPhysicalDamageValue;
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusAccuracyBy(plusAccuracyValue);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusAccuracyBy(plusAccuracyValue);
        }

        public override void ApplyLocalWeaponEffects(LocalWeaponModifiers localWeaponModifiers)
        {
            localWeaponModifiers.IncreaseIncreasedPhysicalDamageInPercentBy(increasedPhysicalDamageValue);
        }

        public override void UnApplyLocalWeaponEffects(LocalWeaponModifiers localWeaponModifiers)
        {
            localWeaponModifiers.DecreaseIncreasedPhysicalDamageInPercentBy(increasedPhysicalDamageValue);
        }

        public override void ApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers)
        {

        }

        public override void UnApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers)
        {

        }
    }
}