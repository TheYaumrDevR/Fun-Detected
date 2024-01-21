namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class FireResistanceAdditiveAffix : EquipmentAffix
    {
        private int value;

        public FireResistanceAdditiveAffix(int value)
        {
            this.value = value;
        }

        public void ApplyEffects()
        {
            // Add value to player fire resistance
        }
    }
}