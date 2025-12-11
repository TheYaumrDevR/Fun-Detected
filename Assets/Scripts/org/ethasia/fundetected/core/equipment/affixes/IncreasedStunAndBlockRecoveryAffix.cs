namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class IncreasedStunAndBlockRecoveryAffix : EquipmentAffix
    {
        private int value;

        public IncreasedStunAndBlockRecoveryAffix(int value) : base(AffixTypes.SUFFIX)
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
            statsFromEquipment.IncreaseIncreasedStunAndBlockRecoveryInPercentBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreaseIncreasedStunAndBlockRecoveryInPercentBy(value);
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
            IncreasedStunAndBlockRecoveryAffix copy = new IncreasedStunAndBlockRecoveryAffix(value);
            Clone(copy);

            return copy;
        }
    }
}