namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class IncreasedPhysicalDamageAffix : EquipmentAffix
    {
        private int value;

        public IncreasedPhysicalDamageAffix(int value) : base(AffixTypes.PREFIX)
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
            localWeaponModifiers.IncreaseIncreasedPhysicalDamageInPercentBy(value);
        }

        public override void UnApplyLocalWeaponEffects(LocalWeaponModifiers localWeaponModifiers)
        {
            localWeaponModifiers.DecreaseIncreasedPhysicalDamageInPercentBy(value);
        }      

        public override void ApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers)
        {

        }

        public override void UnApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers)
        {

        }  
    }
}