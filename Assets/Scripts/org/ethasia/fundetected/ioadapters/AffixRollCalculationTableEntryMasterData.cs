using Org.Ethasia.Fundetected.Core.Equipment.Affixes;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public struct AffixRollCalculationTableEntryMasterData
    {
        public int Tier { get; private set; }
        public RollableEquipmentAffix RollableAffix { get; private set; }
        public int MinItemLevel { get; private set; }
        public int Weighting { get; private set; }

        public class Builder
        {
            private int tier;
            private RollableEquipmentAffix rollableAffix;
            private int minItemLevel;
            private int weighting;

            public Builder SetTier(int value)
            {
                tier = value;
                return this;
            }

            public Builder SetRollableAffix(RollableEquipmentAffix value)
            {
                rollableAffix = value;
                return this;
            }

            public Builder SetMinItemLevel(int value)
            {
                minItemLevel = value;
                return this;
            }

            public Builder SetWeighting(int value)
            {
                weighting = value;
                return this;
            }

            public AffixRollCalculationTableEntryMasterData Build()
            {
                AffixRollCalculationTableEntryMasterData result = new AffixRollCalculationTableEntryMasterData();

                result.Tier = tier;
                result.RollableAffix = rollableAffix;
                result.MinItemLevel = minItemLevel;
                result.Weighting = weighting;

                return result;
            }
        }        
    }
}