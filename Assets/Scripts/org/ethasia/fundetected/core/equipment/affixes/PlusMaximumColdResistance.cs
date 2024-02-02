namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusMaximumColdResistance : EquipmentAffix
    {
        private int value;

        public PlusMaximumColdResistance(int value) : base(AffixTypes.IMPLICIT_ONLY)
        {
            this.value = value;
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusMaximumColdResistanceBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusMaximumColdResistanceBy(value);
        }
    }
}