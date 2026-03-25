namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusStrengthAffix : EquipmentAffix, IAffixWithOneInteger
    {
        public int Value 
        { 
            get; 
            private set; 
        }

        public PlusStrengthAffix(int value) : base(AffixTypes.SUFFIX)
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
            statsFromEquipment.IncreasePlusStrengthBy(Value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusStrengthBy(Value);
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
            PlusStrengthAffix copy = new PlusStrengthAffix(Value);
            Clone(copy);

            return copy;
        }     
    }
}