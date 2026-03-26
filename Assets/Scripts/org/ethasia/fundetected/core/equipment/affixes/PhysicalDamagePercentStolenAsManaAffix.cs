namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PhysicalDamagePercentStolenAsManaAffix : EquipmentAffix, IAffixWithOneFloat
    {
        public float Value 
        { 
            get; 
            private set;
        }

        public PhysicalDamagePercentStolenAsManaAffix(float value) : base(AffixTypes.PREFIX)
        {
            Value = value;
        }

        public override void RerollValue(IntegerMinMaxIncrementRollableEquipmentAffix rerollStrategy)
        {

        }

        public override void RerollValue(IntegerIntervalMinMaxIncrementRollableEquipmentAffix rerollStrategy) {}

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePhysicalDamagePercentStolenAsMana(Value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePhysicalDamagePercentStolenAsMana(Value);
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
            PhysicalDamagePercentStolenAsManaAffix copy = new PhysicalDamagePercentStolenAsManaAffix(Value);
            Clone(copy);

            return copy;
        }

        public override void Accept(IAffixVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}