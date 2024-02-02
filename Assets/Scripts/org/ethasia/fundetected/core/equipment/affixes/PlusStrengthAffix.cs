namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusStrengthAffix : EquipmentAffix
    {
        private int value;

        public PlusStrengthAffix(int value) : base(false)
        {
            this.value = value;
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusStrengthBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusStrengthBy(value);
        }
    }
}