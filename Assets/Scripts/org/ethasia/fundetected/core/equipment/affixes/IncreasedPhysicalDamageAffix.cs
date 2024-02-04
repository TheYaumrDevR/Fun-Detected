namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class IncreasedPhysicalDamageAffix : EquipmentAffix
    {
        private int value;

        public IncreasedPhysicalDamageAffix(int value) : base(AffixTypes.PREFIX)
        {
            this.value = value;
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreaseIncreasedPhysicalDamageInPercentBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreaseIncreasedPhysicalDamageInPercentBy(value);
        }
    }
}