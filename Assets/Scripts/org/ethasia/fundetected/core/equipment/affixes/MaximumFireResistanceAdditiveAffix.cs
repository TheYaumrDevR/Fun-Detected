namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class MaximumFireResistanceAdditiveAffix : EquipmentAffix
    {
        private int value;

        public MaximumFireResistanceAdditiveAffix(int value)
        {
            this.value = value;
        }

        public void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusMaximumFireResistanceBy(value);
        }

        public void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusMaximumFireResistanceBy(value);
        }        
    }
}