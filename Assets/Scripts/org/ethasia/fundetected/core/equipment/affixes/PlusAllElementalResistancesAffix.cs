namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusAllElementalResistancesAffix : EquipmentAffix
    {
        private int value;

        public PlusAllElementalResistancesAffix(int value) : base(AffixTypes.SUFFIX)
        {
            this.value = value;
        }

        public override void RerollValue(IntegerMinMaxIncrementRollableEquipmentAffix rerollStrategy)
        {
            value = rerollStrategy.RerollValue();
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusColdResistanceBy(value);
            statsFromEquipment.IncreasePlusFireResistanceBy(value);
            statsFromEquipment.IncreasePlusLightningResistanceBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusColdResistanceBy(value);
            statsFromEquipment.DecreasePlusFireResistanceBy(value);
            statsFromEquipment.DecreasePlusLightningResistanceBy(value);
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
            PlusAllElementalResistancesAffix copy = new PlusAllElementalResistancesAffix(value);
            Clone(copy);

            return copy;
        }
    }
}