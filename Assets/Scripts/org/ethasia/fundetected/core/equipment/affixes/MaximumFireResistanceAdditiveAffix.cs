namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class MaximumFireResistanceAdditiveAffix : EquipmentAffix
    {
        private int value;

        public MaximumFireResistanceAdditiveAffix(int value) : base(AffixTypes.IMPLICIT_ONLY)
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