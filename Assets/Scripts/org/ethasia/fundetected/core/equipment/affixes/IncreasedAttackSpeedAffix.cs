namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class IncreasedAttackSpeedAffix : EquipmentAffix, IAffixWithOneInteger
    {
        public int Value 
        { 
            get; 
            private set; 
        }

        public override void RerollValue(IntegerMinMaxIncrementRollableEquipmentAffix rerollStrategy)
        {
            Value = rerollStrategy.RerollValue();
        }

        public IncreasedAttackSpeedAffix(int value) : base(AffixTypes.SUFFIX)
        {
            Value = value;
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
            localWeaponModifiers.IncreaseIncreasedAttackSpeedInPercentBy(Value);
        }

        public override void UnApplyLocalWeaponEffects(LocalWeaponModifiers localWeaponModifiers)
        {
            localWeaponModifiers.DecreaseIncreasedAttackSpeedInPercentBy(Value);
        }

        public override void ApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers)
        {

        }

        public override void UnApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers)
        {

        }

        public override EquipmentAffix Clone()
        {
            IncreasedAttackSpeedAffix copy = new IncreasedAttackSpeedAffix(Value);
            Clone(copy);
            
            return copy;
        }
    }
}