namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PhysicalDamagePercentStolenAsLifeAffix : EquipmentAffix
    {
        private float value;

        public PhysicalDamagePercentStolenAsLifeAffix(float value) : base(AffixTypes.PREFIX)
        {
            this.value = value;
        }

        public override void RerollValue(IntegerMinMaxIncrementRollableEquipmentAffix rerollStrategy)
        {

        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePhysicalDamagePercentStolenAsLife(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePhysicalDamagePercentStolenAsLife(value);
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
            PhysicalDamagePercentStolenAsLifeAffix copy = new PhysicalDamagePercentStolenAsLifeAffix(value);
            Clone(copy);

            return copy;
        }
    }
}