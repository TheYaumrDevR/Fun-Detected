namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusMagicResistanceAffix : EquipmentAffix
    {
        private int value;

        public PlusMagicResistanceAffix(int value) : base(AffixTypes.SUFFIX)
        {
            this.value = value;
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusMagicResistanceBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusMagicResistanceBy(value);
        }
    }
}