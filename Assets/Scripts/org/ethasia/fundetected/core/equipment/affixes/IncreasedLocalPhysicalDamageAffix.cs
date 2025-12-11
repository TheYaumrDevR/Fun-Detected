namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class IncreasedLocalPhysicalDamageAffix : EquipmentAffix
    {
        private int value;

        public IncreasedLocalPhysicalDamageAffix(int value) : base(AffixTypes.PREFIX)
        {
            this.value = value;
        }

        public override void RerollValue(IntegerMinMaxIncrementRollableEquipmentAffix rerollStrategy)
        {
            value = rerollStrategy.RerollValue();
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
            localWeaponModifiers.IncreaseIncreasedPhysicalDamageInPercentBy(value);
        }

        public override void UnApplyLocalWeaponEffects(LocalWeaponModifiers localWeaponModifiers)
        {
            localWeaponModifiers.DecreaseIncreasedPhysicalDamageInPercentBy(value);
        }

        public override void ApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers)
        {

        }

        public override void UnApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers)
        {

        }  
        
        public override EquipmentAffix Clone()
        {
            IncreasedLocalPhysicalDamageAffix copy = new IncreasedLocalPhysicalDamageAffix(value);
            Clone(copy);
            
            return copy;
        }
    }
}