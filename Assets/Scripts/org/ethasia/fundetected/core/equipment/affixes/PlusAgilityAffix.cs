namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusAgilityAffix : EquipmentAffix
    {
        private int value;

        public PlusAgilityAffix(int value) : base(AffixTypes.SUFFIX)
        {
            this.value = value;
        }

        public override void RerollValue(IntegerMinMaxIncrementRollableEquipmentAffix rerollStrategy)
        {
            value = rerollStrategy.RerollValue();
        }

        public override void RerollValue(IntegerIntervalMinMaxIncrementRollableEquipmentAffix rerollStrategy) {}

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusAgilityBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusAgilityBy(value);
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
            PlusAgilityAffix copy = new PlusAgilityAffix(value);
            Clone(copy);

            return copy;
        }         
    }
}