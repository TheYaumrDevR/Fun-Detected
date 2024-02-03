namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusAllElementalResistancesAffix : EquipmentAffix
    {
        private int value;

        public PlusAllElementalResistancesAffix(int value) : base(AffixTypes.SUFFIX)
        {
            this.value = value;
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusColdResistanceBy(value);
            statsFromEquipment.IncreasePlusFireResistanceBy(value);
            statsFromEquipment.IncreasePlusLightningResistanceBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusColdResistanceBy(value);
            statsFromEquipment.DecreasePlusFireResistanceBy(value);
            statsFromEquipment.DecreasePlusLightningResistanceBy(value);
        }
    }
}