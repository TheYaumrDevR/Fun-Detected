namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusLightningResistanceAffix : EquipmentAffix
    {
        private int value;

        public PlusLightningResistanceAffix(int value) : base(AffixTypes.SUFFIX)
        {
            this.value = value;
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusLightningResistanceBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusLightningResistanceBy(value);
        }
    }
}