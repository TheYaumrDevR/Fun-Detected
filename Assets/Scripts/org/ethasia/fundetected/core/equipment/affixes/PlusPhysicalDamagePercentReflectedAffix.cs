namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusPhysicalDamagePercentReflectedAffix : EquipmentAffix, IAffixWithOneInteger
    {
        public int Value 
        { 
            get; 
            private set; 
        }

        public PlusPhysicalDamagePercentReflectedAffix(int plusPhysicalDamagePercentValue) : base(AffixTypes.PREFIX)
        {
            Value = plusPhysicalDamagePercentValue;
        }

        public override void RerollValue(IntegerMinMaxIncrementRollableEquipmentAffix rerollStrategy)
        {
            Value = rerollStrategy.RerollValue();
        }

        public override void RerollValue(IntegerIntervalMinMaxIncrementRollableEquipmentAffix rerollStrategy) {}

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusPhysicalDamagePercentReflectedBy(Value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusPhysicalDamagePercentReflectedBy(Value);
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
            PlusPhysicalDamagePercentReflectedAffix copy = new PlusPhysicalDamagePercentReflectedAffix(Value);
            Clone(copy);

            return copy;
        }
    }
}