namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusAllAttributesAffix : EquipmentAffix, IAffixWithOneInteger
    {
        public int Value 
        { 
            get; 
            private set; 
        }

        public PlusAllAttributesAffix(int value) : base(AffixTypes.SUFFIX)
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
            statsFromEquipment.IncreasePlusAgilityBy(Value);
            statsFromEquipment.IncreasePlusIntelligenceBy(Value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusStrengthBy(Value);
            statsFromEquipment.DecreasePlusAgilityBy(Value);
            statsFromEquipment.DecreasePlusIntelligenceBy(Value);
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
            PlusAllAttributesAffix copy = new PlusAllAttributesAffix(Value);
            Clone(copy);

            return copy;
        }
    }
}