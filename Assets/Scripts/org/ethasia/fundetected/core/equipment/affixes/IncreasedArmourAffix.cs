namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class IncreasedArmourAffix : EquipmentAffix
    {
        private int value;

        public IncreasedArmourAffix(int value) : base(AffixTypes.PREFIX)
        {
            this.value = value;
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
    }
}