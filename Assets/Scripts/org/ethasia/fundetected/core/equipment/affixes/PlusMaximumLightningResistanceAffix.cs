namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusMaximumLightningResistanceAffix : EquipmentAffix
    {
        private int value;

        public PlusMaximumLightningResistanceAffix(int value) : base(AffixTypes.IMPLICIT_ONLY)
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
            statsFromEquipment.IncreasePlusMaximumLightningResistanceBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusMaximumLightningResistanceBy(value);
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
            PlusMaximumLightningResistanceAffix copy = new PlusMaximumLightningResistanceAffix(value);
            Clone(copy);

            return copy;
        }
    }
}