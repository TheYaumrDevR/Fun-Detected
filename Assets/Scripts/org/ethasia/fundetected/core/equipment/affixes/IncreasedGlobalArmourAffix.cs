namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class IncreasedGlobalArmourAffix : EquipmentAffix
    {
        private int value;

        public IncreasedGlobalArmourAffix(int value) : base(AffixTypes.PREFIX)
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
            statsFromEquipment.IncreaseIncreasedArmourInPercentBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreaseIncreasedArmourInPercentBy(value);
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
            IncreasedGlobalArmourAffix copy = new IncreasedGlobalArmourAffix(value);
            Clone(copy);
            
            return copy;
        }
    }
}