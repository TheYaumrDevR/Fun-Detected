namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusAgilityAffix : EquipmentAffix
    {
        private int value;

        public PlusAgilityAffix(int value) : base(AffixTypes.SUFFIX)
        {
            this.value = value;
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusAgilityBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusAgilityBy(value);
        }
    }
}