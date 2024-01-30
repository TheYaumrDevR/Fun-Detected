namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusStrengthAffix : EquipmentAffix
    {
        private int value;

        public PlusStrengthAffix(int value)
        {
            this.value = value;
        }

        public void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusStrengthBy(value);
        }

        public void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusStrengthBy(value);
        }
    }
}