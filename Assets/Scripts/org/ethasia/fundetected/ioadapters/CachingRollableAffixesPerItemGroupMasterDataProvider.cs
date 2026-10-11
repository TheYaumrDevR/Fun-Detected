using Org.Ethasia.Fundetected.Core.Equipment.Affixes;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class CachingRollableAffixesPerItemGroupMasterDataProvider : IRollableAffixesPerItemGroupMasterDataProvider
    {
        private readonly IRollableAffixesPerItemGroupMasterDataProvider realProvider;

        private AffixRollCalculationTableMasterData? prefixesForOneHandedSwords;
        private AffixRollCalculationTableMasterData? suffixesForOneHandedSwords;
        private AffixRollCalculationTableMasterData? prefixesForRings;
        private AffixRollCalculationTableMasterData? suffixesForRings;
        private AffixRollCalculationTableMasterData? prefixesForBelts;
        private AffixRollCalculationTableMasterData? suffixesForBelts;
        private AffixRollCalculationTableMasterData? prefixesForAmulets;
        private AffixRollCalculationTableMasterData? suffixesForAmulets;

        public CachingRollableAffixesPerItemGroupMasterDataProvider(IRollableAffixesPerItemGroupMasterDataProvider realProvider)
        {
            this.realProvider = realProvider;
        }

        public AffixRollCalculationTableMasterData CreateRollablePrefixesForOneHandedSwords()
        {
            if (!prefixesForOneHandedSwords.HasValue)
            {
                prefixesForOneHandedSwords = realProvider.CreateRollablePrefixesForOneHandedSwords();
            }

            return prefixesForOneHandedSwords.Value;
        }

        public AffixRollCalculationTableMasterData CreateRollableSuffixesForOneHandedSwords()
        {
            if (!suffixesForOneHandedSwords.HasValue)
            {
                suffixesForOneHandedSwords = realProvider.CreateRollableSuffixesForOneHandedSwords();
            }

            return suffixesForOneHandedSwords.Value;
        }

        public AffixRollCalculationTableMasterData CreateRollablePrefixesForRings()
        {
            if (!prefixesForRings.HasValue)
            {
                prefixesForRings = realProvider.CreateRollablePrefixesForRings();
            }

            return prefixesForRings.Value;
        }

        public AffixRollCalculationTableMasterData CreateRollableSuffixesForRings()
        {
            if (!suffixesForRings.HasValue)
            {
                suffixesForRings = realProvider.CreateRollableSuffixesForRings();
            }

            return suffixesForRings.Value;
        }

        public AffixRollCalculationTableMasterData CreateRollablePrefixesForBelts()
        {
            if (!prefixesForBelts.HasValue)
            {
                prefixesForBelts = realProvider.CreateRollablePrefixesForBelts();
            }

            return prefixesForBelts.Value;
        }

        public AffixRollCalculationTableMasterData CreateRollableSuffixesForBelts()
        {
            if (!suffixesForBelts.HasValue)
            {
                suffixesForBelts = realProvider.CreateRollableSuffixesForBelts();
            }

            return suffixesForBelts.Value;
        }

        public AffixRollCalculationTableMasterData CreateRollablePrefixesForAmulets()
        {
            if (!prefixesForAmulets.HasValue)
            {
                prefixesForAmulets = realProvider.CreateRollablePrefixesForAmulets();
            }

            return prefixesForAmulets.Value;
        }

        public AffixRollCalculationTableMasterData CreateRollableSuffixesForAmulets()
        {
            if (!suffixesForAmulets.HasValue)
            {
                suffixesForAmulets = realProvider.CreateRollableSuffixesForAmulets();
            }

            return suffixesForAmulets.Value;
        }
    }
}