namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class IncreasedArmourAffix : EquipmentAffix
    {
        private int value;

        public IncreasedArmourAffix(int value) : base(AffixTypes.PREFIX)
        {
            this.value = value;
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreaseIncreasedArmorInPercentBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreaseIncreasedArmorInPercentBy(value);
        }
    }
}