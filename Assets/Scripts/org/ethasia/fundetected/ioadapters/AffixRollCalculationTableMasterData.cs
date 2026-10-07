using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public struct AffixRollCalculationTableMasterData
    {
        public List<AffixRollCalculationTableEntryMasterData> RollableAffixes { get; private set; }

        public class Builder
        {
            private List<AffixRollCalculationTableEntryMasterData> rollableAffixes = new List<AffixRollCalculationTableEntryMasterData>();

            public Builder AddRollableAffix(AffixRollCalculationTableEntryMasterData value)
            {
                rollableAffixes.Add(value);
                return this;
            }

            public AffixRollCalculationTableMasterData Build()
            {
                AffixRollCalculationTableMasterData result = new AffixRollCalculationTableMasterData();
                result.RollableAffixes = rollableAffixes;

                return result;
            }
        }        
    }
}