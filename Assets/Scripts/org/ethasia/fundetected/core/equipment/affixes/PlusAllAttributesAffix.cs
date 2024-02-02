namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusAllAttributesAffix : EquipmentAffix
    {
        private int value;

        public PlusAllAttributesAffix(int value) : base(AffixTypes.SUFFIX)
        {
            this.value = value;
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusStrengthBy(value);
            statsFromEquipment.IncreasePlusAgilityBy(value);
            statsFromEquipment.IncreasePlusIntelligenceBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusStrengthBy(value);
            statsFromEquipment.DecreasePlusAgilityBy(value);
            statsFromEquipment.DecreasePlusIntelligenceBy(value);
        }
    }
}