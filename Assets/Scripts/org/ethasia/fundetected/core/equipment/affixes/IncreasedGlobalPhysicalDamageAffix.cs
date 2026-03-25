namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class IncreasedGlobalPhysicalDamageAffix : EquipmentAffix, IAffixWithOneInteger
    {
        public int Value 
        { 
            get; 
            private set; 
        }

        public IncreasedGlobalPhysicalDamageAffix(int value) : base(AffixTypes.PREFIX)
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
            statsFromEquipment.IncreaseIncreasedPhysicalDamageInPercentBy(Value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreaseIncreasedPhysicalDamageInPercentBy(Value);
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
            IncreasedGlobalPhysicalDamageAffix copy = new IncreasedGlobalPhysicalDamageAffix(Value);
            Clone(copy);
            
            return copy;
        }
    }
}