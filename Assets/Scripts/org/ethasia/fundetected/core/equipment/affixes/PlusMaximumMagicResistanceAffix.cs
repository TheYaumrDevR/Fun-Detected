namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusMaximumMagicResistanceAffix : EquipmentAffix, IAffixWithOneInteger
    {
        public int Value 
        { 
            get; 
            private set; 
        }

        public PlusMaximumMagicResistanceAffix(int value) : base(AffixTypes.IMPLICIT_ONLY)
        {
            Value = value;
        }

        public override void RerollValue(IntegerMinMaxIncrementRollableEquipmentAffix rerollStrategy)
        {
            Value = rerollStrategy.RerollValue();
        }

        public override void RerollValue(IntegerIntervalMinMaxIncrementRollableEquipmentAffix rerollStrategy) {}

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusMaximumMagicResistanceBy(Value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusMaximumMagicResistanceBy(Value);
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
            PlusMaximumMagicResistanceAffix copy = new PlusMaximumMagicResistanceAffix(Value);
            Clone(copy);

            return copy;
        }
    }
}