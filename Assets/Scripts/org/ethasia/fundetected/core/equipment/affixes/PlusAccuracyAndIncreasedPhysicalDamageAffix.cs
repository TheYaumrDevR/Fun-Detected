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
            statsFromEquipment.IncreaseIncreasedPhysicalDamageInPercentBy(increasedPhysicalDamageValue);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusAccuracyBy(plusAccuracyValue);
            statsFromEquipment.DecreaseIncreasedPhysicalDamageInPercentBy(increasedPhysicalDamageValue);
        }
    }
}