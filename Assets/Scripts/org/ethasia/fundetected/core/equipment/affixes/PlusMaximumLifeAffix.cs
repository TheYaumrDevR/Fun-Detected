namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusMaximumLifeAffix : EquipmentAffix
    {
        private int value;

        public PlusMaximumLifeAffix(int value) : base(AffixTypes.PREFIX)
        {
            this.value = value;
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusMaximumLifeBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusMaximumLifeBy(value);
        }
    }
}