namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusMinMaxLightningDamageAffix : EquipmentAffix
    {
        private int plusMinDamageValue;
        private int plusMaxDamageValue;

        public PlusMinMaxLightningDamageAffix(int plusMinDamageValue, int plusMaxDamageValue) : base(AffixTypes.PREFIX)
        {
            this.plusMinDamageValue = plusMinDamageValue;
            this.plusMaxDamageValue = plusMaxDamageValue;
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {

        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {

        }

        public override void ApplyLocalWeaponEffects(LocalWeaponModifiers localWeaponModifiers)
        {
            localWeaponModifiers.IncreasePlusMinToMaxLightningDamageBy(plusMinDamageValue, plusMaxDamageValue);
        }

        public override void UnApplyLocalWeaponEffects(LocalWeaponModifiers localWeaponModifiers)
        {
            localWeaponModifiers.DecreasePlusMinToMaxLightningDamageBy(plusMinDamageValue, plusMaxDamageValue);
        }

        public override void ApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers)
        {

        }

        public override void UnApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers)
        {

        }
    }  
}