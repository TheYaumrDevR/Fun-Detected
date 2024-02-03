namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusMaximumFireResistanceAffix : EquipmentAffix
    {
        private int value;

        public PlusMaximumFireResistanceAffix(int value) : base(AffixTypes.IMPLICIT_ONLY)
        {
            this.value = value;
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusMaximumFireResistanceBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusMaximumFireResistanceBy(value);
        }        
    }
}