namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PhysicalDamagePercentStolenAsManaAffix : EquipmentAffix
    {
        private float value;

        public PhysicalDamagePercentStolenAsManaAffix(float value) : base(AffixTypes.PREFIX)
        {
            this.value = value;
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePhysicalDamagePercentStolenAsMana(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePhysicalDamagePercentStolenAsMana(value);
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
    }
}