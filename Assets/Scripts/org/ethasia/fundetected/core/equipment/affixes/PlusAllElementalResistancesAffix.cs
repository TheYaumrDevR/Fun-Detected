namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusAllElementalResistancesAffix : EquipmentAffix, IAffixWithOneInteger
    {
        public int Value 
        { 
            get; 
            private set; 
        }

        public PlusAllElementalResistancesAffix(int value) : base(AffixTypes.SUFFIX)
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
            statsFromEquipment.IncreasePlusColdResistanceBy(Value);
            statsFromEquipment.IncreasePlusFireResistanceBy(Value);
            statsFromEquipment.IncreasePlusLightningResistanceBy(Value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusColdResistanceBy(Value);
            statsFromEquipment.DecreasePlusFireResistanceBy(Value);
            statsFromEquipment.DecreasePlusLightningResistanceBy(Value);
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
            PlusAllElementalResistancesAffix copy = new PlusAllElementalResistancesAffix(Value);
            Clone(copy);

            return copy;
        }

        public override void Accept(IAffixVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}