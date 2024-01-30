namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public interface EquipmentAffix
    {
        void ApplyEffects(StatsFromEquipment statsFromEquipment);
        void UnApplyEffects(StatsFromEquipment statsFromEquipment);
    }
}