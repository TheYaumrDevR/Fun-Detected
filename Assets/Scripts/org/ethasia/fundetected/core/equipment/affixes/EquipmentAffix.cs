namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public abstract class EquipmentAffix
    {
        // TODO: It can be prefix, suffix, implicit only, unique
        public bool IsPrefix
        {
            get;
            private set;
        }

        public EquipmentAffix(bool isPrefix)
        {
            IsPrefix = isPrefix;
        }

        public abstract void ApplyEffects(StatsFromEquipment statsFromEquipment);
        public abstract void UnApplyEffects(StatsFromEquipment statsFromEquipment);
    }
}