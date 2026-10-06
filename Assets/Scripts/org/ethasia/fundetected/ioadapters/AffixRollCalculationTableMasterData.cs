using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public struct AffixRollCalculationTableMasterData
    {
        public List<AffixRollCalculationTableEntryMasterData> Tiers { get; private set; }

        public class Builder
        {
            private List<AffixRollCalculationTableEntryMasterData> tiers = new List<AffixRollCalculationTableEntryMasterData>();

            public Builder AddTier(AffixRollCalculationTableEntryMasterData value)
            {
                tiers.Add(value);
                return this;
            }

            public AffixRollCalculationTableMasterData Build()
            {
                AffixRollCalculationTableMasterData result = new AffixRollCalculationTableMasterData();
                result.Tiers = tiers;

                return result;
            }
        }        
    }
}