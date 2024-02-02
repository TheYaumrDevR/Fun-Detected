namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusIntelligenceAffix : EquipmentAffix
    {
        private int value;

        public PlusIntelligenceAffix(int value) : base(false)
        {
            this.value = value;
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusIntelligenceBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusIntelligenceBy(value);
        }
    }
}