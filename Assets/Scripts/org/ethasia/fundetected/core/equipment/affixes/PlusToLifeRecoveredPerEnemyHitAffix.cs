namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusToLifeRecoveredPerEnemyHitAffix : EquipmentAffix, IAffixWithOneInteger
    {
        public int Value 
        { 
            get; 
            private set; 
        }

        public PlusToLifeRecoveredPerEnemyHitAffix(int value) : base(AffixTypes.SUFFIX)
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

        }

        public override void UnApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers)
        {

        }    

        public override EquipmentAffix Clone()
        {
            PlusToLifeRecoveredPerEnemyHitAffix copy = new PlusToLifeRecoveredPerEnemyHitAffix(Value);
            Clone(copy);

            return copy;
        }    

        public override void Accept(IAffixVisitor visitor)
        {
            visitor.Visit(this);
        } 
    }
}