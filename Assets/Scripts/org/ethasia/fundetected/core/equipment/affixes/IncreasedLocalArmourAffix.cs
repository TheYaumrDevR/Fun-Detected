namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class IncreasedLocalArmourAffix : EquipmentAffix
    {
        private int value;

        public IncreasedLocalArmourAffix(int value) : base(AffixTypes.PREFIX)
        {
            this.value = value;
        }

        public override void RerollValue(IntegerMinMaxIncrementRollableEquipmentAffix rerollStrategy)
        {
            value = rerollStrategy.RerollValue();
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {

        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {

        }

        public override void ApplyLocalWeaponEffects(LocalWeaponModifiers localWeaponModifiers)
        {

        }

        public override void UnApplyLocalWeaponEffects(LocalWeaponModifiers localWeaponModifiers)
        {

        }

        public override void ApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers)
        {
            localArmorModifiers.IncreaseIncreasedArmorInPercentBy(value);
        }

        public override void UnApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers)
        {
            localArmorModifiers.DecreaseIncreasedArmorInPercentBy(value);
        }

        public override EquipmentAffix Clone()
        {
            IncreasedLocalArmourAffix copy = new IncreasedLocalArmourAffix(value);
            Clone(copy);
            
            return copy;
        }
    }
}