namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusAccuracyAffix : EquipmentAffix
    {
        private int value;

        public PlusAccuracyAffix(int value) : base(AffixTypes.SUFFIX)
        {
            this.value = value;
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusAccuracyBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusAccuracyBy(value);
        }
    }
}