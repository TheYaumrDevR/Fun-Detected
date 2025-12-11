namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusMinMaxColdDamageAffix : EquipmentAffix
    {
        private int plusMinDamageValue;
        private int plusMaxDamageValue;

        public PlusMinMaxColdDamageAffix(int plusMinDamageValue, int plusMaxDamageValue) : base(AffixTypes.PREFIX)
        {
            this.plusMinDamageValue = plusMinDamageValue;
            this.plusMaxDamageValue = plusMaxDamageValue;
        }

        public override void RerollValue(IntegerMinMaxIncrementRollableEquipmentAffix rerollStrategy)
        {

        }

        public override void RerollValue(IntegerIntervalMinMaxIncrementRollableEquipmentAffix rerollStrategy) {}

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {

        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {

        }

        public override void ApplyLocalWeaponEffects(LocalWeaponModifiers localWeaponModifiers)
        {
            localWeaponModifiers.IncreasePlusMinToMaxColdDamageBy(plusMinDamageValue, plusMaxDamageValue);
        }

        public override void UnApplyLocalWeaponEffects(LocalWeaponModifiers localWeaponModifiers)
        {
            localWeaponModifiers.DecreasePlusMinToMaxColdDamageBy(plusMinDamageValue, plusMaxDamageValue);
        }

        public override void ApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers)
        {

        }

        public override void UnApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers)
        {

        }

        public override EquipmentAffix Clone()
        {
            PlusMinMaxColdDamageAffix copy = new PlusMinMaxColdDamageAffix(plusMinDamageValue, plusMaxDamageValue);
            Clone(copy);

            return copy;
        }
    }
}