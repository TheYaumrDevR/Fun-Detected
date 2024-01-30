namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusAgilityAffix : EquipmentAffix
    {
        private int value;

        public PlusAgilityAffix(int value)
        {
            this.value = value;
        }

        public void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusAgilityBy(value);
        }

        public void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusAgilityBy(value);
        }
    }
}