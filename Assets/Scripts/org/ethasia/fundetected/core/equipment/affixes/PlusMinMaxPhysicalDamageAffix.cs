namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusMinMaxPhysicalDamageAffix : EquipmentAffix
    {
        private int plusMinPhysicalDamageValue;
        private int plusMaxPhysicalDamageValue;

        public PlusMinMaxPhysicalDamageAffix(int plusMinPhysicalDamageValue, int plusMaxPhysicalDamageValue) : base(AffixTypes.PREFIX)
        {
            this.plusMinPhysicalDamageValue = plusMinPhysicalDamageValue;
            this.plusMaxPhysicalDamageValue = plusMaxPhysicalDamageValue;
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {

        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {

        }

        public override void ApplyLocalWeaponEffects(LocalWeaponModifiers localWeaponModifiers)
        {
            localWeaponModifiers.IncreasePlusMinToMaxPhysicalDamageBy(plusMinPhysicalDamageValue, plusMaxPhysicalDamageValue);
        }        

        public override void UnApplyLocalWeaponEffects(LocalWeaponModifiers localWeaponModifiers)
        {
            localWeaponModifiers.DecreasePlusMinToMaxPhysicalDamageBy(plusMinPhysicalDamageValue, plusMaxPhysicalDamageValue);
        }

        public override void ApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers)
        {

        }

        public override void UnApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers)
        {

        }           
    }
}