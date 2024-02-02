namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusColdResistanceAffix : EquipmentAffix
    {
        private int value;

        public PlusColdResistanceAffix(int value) : base(AffixTypes.SUFFIX)
        {
            this.value = value;
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusColdResistanceBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusColdResistanceBy(value);
        }
    }
}