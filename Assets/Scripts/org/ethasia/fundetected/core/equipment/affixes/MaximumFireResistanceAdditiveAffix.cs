namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class MaximumFireResistanceAdditiveAffix : EquipmentAffix
    {
        private int value;

        public MaximumFireResistanceAdditiveAffix(int value)
        {
            this.value = value;
        }

        public void ApplyEffects()
        {
            // Add value to player maximum fire resistance
        }
    }
}