namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class IncreasedLocalArmourAffix : EquipmentAffix, IAffixWithOneInteger
    {
        public int Value 
        { 
            get; 
            private set; 
        }

        public IncreasedLocalArmourAffix(int value) : base(AffixTypes.PREFIX)
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

        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {

        }

        public override void ApplyLocalWeaponEffects(LocalWeaponModifiers localWeaponModifiers)
        {

        }

        public override void UnApplyLocalWeaponEffects(LocalWeaponModifiers localWeaponModifiers)
        {

        }

        public override void ApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers)
        {
            localArmorModifiers.IncreaseIncreasedArmorInPercentBy(Value);
        }

        public override void UnApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers)
        {
            localArmorModifiers.DecreaseIncreasedArmorInPercentBy(Value);
        }

        public override EquipmentAffix Clone()
        {
            IncreasedLocalArmourAffix copy = new IncreasedLocalArmourAffix(Value);
            Clone(copy);
            
            return copy;
        }
    }
}