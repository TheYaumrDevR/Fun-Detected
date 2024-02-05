namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusMaximumMagicResistanceAffix : EquipmentAffix
    {
        private int value;

        public PlusMaximumMagicResistanceAffix(int value) : base(AffixTypes.IMPLICIT_ONLY)
        {
            this.value = value;
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusMaximumMagicResistanceBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusMaximumMagicResistanceBy(value);
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