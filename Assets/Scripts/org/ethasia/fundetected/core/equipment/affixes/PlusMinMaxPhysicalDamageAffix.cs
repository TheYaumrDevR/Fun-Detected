namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public class PlusMinMaxPhysicalDamageAffix : EquipmentAffix
    {
        private int plusMinPhysicalDamageValue;
        private int plusMaxPhysicalDamageValue;

        public PlusMinMaxPhysicalDamageAffix(int plusMinPhysicalDamageValue, int plusMaxPhysicalDamageValue) : base(AffixTypes.PREFIX)
        {
            this.plusMinPhysicalDamageValue = plusMinPhysicalDamageValue;
            this.plusMaxPhysicalDamageValue = plusMaxPhysicalDamageValue;
        }

        public override void ApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.IncreasePlusMinimumPhysicalDamageBy(plusMinPhysicalDamageValue);
            statsFromEquipment.IncreasePlusMaximumPhysicalDamageBy(plusMaxPhysicalDamageValue);
        }

        public override void UnApplyEffects(StatsFromEquipment statsFromEquipment)
        {
            statsFromEquipment.DecreasePlusMinimumPhysicalDamageBy(plusMinPhysicalDamageValue);
            statsFromEquipment.DecreasePlusMaximumPhysicalDamageBy(plusMaxPhysicalDamageValue);
        }
    }
}