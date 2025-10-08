namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class IncreasedGlobalPhysicalDamageAffix : EquipmentAffix
    {
        private int value;

        public IncreasedGlobalPhysicalDamageAffix(int value) : base(AffixTypes.PREFIX)
        {
            this.value = value;
        }

        public override void RerollValue(IntegerMinMaxIncrementRollableEquipmentAffix rerollStrategy)
        {
            value = rerollStrategy.RerollValue();
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreaseIncreasedPhysicalDamageInPercentBy(value);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreaseIncreasedPhysicalDamageInPercentBy(value);
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
            IncreasedGlobalPhysicalDamageAffix copy = new IncreasedGlobalPhysicalDamageAffix(value);
            Clone(copy);
            
            return copy;
        }
    }
}