namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class FireResistanceAdditiveAffix : EquipmentAffix
    {
        private int value;

        public FireResistanceAdditiveAffix(int value) : base(false)
        {
            this.value = value;
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusFireResistanceBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusFireResistanceBy(value);
        }
    }
}