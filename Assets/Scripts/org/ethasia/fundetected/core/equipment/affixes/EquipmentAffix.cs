namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public abstract class EquipmentAffix
    {
        public AffixTypes AffixType
        {
            get;
            private set;
        }

        public EquipmentAffix(AffixTypes affixType)
        {
            AffixType = affixType;
        }

        public abstract void RerollValue(IntegerMinMaxIncrementRollableEquipmentAffix rerollStrategy);
        public abstract void ApplyEffects(StatsFromEquipment statsFromEquipment);
        public abstract void UnApplyEffects(StatsFromEquipment statsFromEquipment);
        public abstract void ApplyLocalWeaponEffects(LocalWeaponModifiers localWeaponModifiers);
        public abstract void UnApplyLocalWeaponEffects(LocalWeaponModifiers localWeaponModifiers);
        public abstract void ApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers);
        public abstract void UnApplyLocalArmorEffects(LocalArmorModifiers localArmorModifiers);
    }
}