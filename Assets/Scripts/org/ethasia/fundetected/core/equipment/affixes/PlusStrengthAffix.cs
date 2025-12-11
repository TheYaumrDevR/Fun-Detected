namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusStrengthAffix : EquipmentAffix
    {
        private int value;

        public PlusStrengthAffix(int value) : base(AffixTypes.SUFFIX)
        {
            this.value = value;
        }

        public override void RerollValue(IntegerMinMaxIncrementRollableEquipmentAffix rerollStrategy)
        {
            value = rerollStrategy.RerollValue();
        }

        public override void RerollValue(IntegerIntervalMinMaxIncrementRollableEquipmentAffix rerollStrategy) {}

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusStrengthBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusStrengthBy(value);
        }

        public override void ApplyLocalWeaponEffects(LocalWeaponModifiers localWeaponModifiers)
        {

        }

        public override void UnApplyLocalWeaponEffects(LocalWeaponModifiers localWeaponModifiers)
        {

        }

        public override void ApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers)
        {

        }

        public override void UnApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers)
        {

        }    

        public override EquipmentAffix Clone()
        {
            PlusStrengthAffix copy = new PlusStrengthAffix(value);
            Clone(copy);

            return copy;
        }     
    }
}