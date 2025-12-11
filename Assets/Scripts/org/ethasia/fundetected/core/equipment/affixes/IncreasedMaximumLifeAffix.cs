namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class IncreasedMaximumLifeAffix : EquipmentAffix
    {
        private int value;

        public IncreasedMaximumLifeAffix(int value) : base(AffixTypes.PREFIX)
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
            statsFromEquipment.IncreaseIncreasedMaximumLifeInPercentBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreaseIncreasedMaximumLifeInPercentBy(value);
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
            IncreasedMaximumLifeAffix copy = new IncreasedMaximumLifeAffix(value);
            Clone(copy);

            return copy;
        }
    }
}