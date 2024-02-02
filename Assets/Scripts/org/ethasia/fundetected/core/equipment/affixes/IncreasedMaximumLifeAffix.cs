namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class IncreasedMaximumLifeAffix : EquipmentAffix
    {
        private int value;

        public IncreasedMaximumLifeAffix(int value) : base(AffixTypes.PREFIX)
        {
            this.value = value;
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreaseIncreasedMaximumLifeInPercentBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreaseIncreasedMaximumLifeInPercentBy(value);
        }
    }
}