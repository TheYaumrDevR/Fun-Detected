namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusMaximumManaAffix : EquipmentAffix
    {
        private int value;

        public PlusMaximumManaAffix(int value) : base(AffixTypes.PREFIX)
        {
            this.value = value;
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusMaximumManaBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusMaximumManaBy(value);
        }
    }
}