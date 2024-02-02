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

        public abstract void ApplyEffects(StatsFromEquipment statsFromEquipment);
        public abstract void UnApplyEffects(StatsFromEquipment statsFromEquipment);
    }
}