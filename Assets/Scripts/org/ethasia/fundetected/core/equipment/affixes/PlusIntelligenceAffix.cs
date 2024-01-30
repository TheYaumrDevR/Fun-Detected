namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusIntelligenceAffix : EquipmentAffix
    {
        private int value;

        public PlusIntelligenceAffix(int value)
        {
            this.value = value;
        }

        public void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusIntelligenceBy(value);
        }

        public void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusIntelligenceBy(value);
        }
    }
}