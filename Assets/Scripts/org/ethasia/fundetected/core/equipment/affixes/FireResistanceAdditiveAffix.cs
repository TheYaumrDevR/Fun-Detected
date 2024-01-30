namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class FireResistanceAdditiveAffix : EquipmentAffix
    {
        private int value;

        public FireResistanceAdditiveAffix(int value)
        {
            this.value = value;
        }

        public void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusFireResistanceBy(value);
        }

        public void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusFireResistanceBy(value);
        }
    }
}