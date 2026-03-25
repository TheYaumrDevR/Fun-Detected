namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusMaximumManaAffix : EquipmentAffix, IAffixWithOneInteger
    {
        public int Value 
        { 
            get; 
            private set; 
        }

        public PlusMaximumManaAffix(int value) : base(AffixTypes.PREFIX)
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
            statsFromEquipment.IncreasePlusMaximumManaBy(Value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusMaximumManaBy(Value);
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
            PlusMaximumManaAffix copy = new PlusMaximumManaAffix(Value);
            Clone(copy);

            return copy;
        }
    }
}