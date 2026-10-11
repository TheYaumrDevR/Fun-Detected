namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public interface IRollableAffixesPerItemGroupMasterDataProvider
    {
        AffixRollCalculationTableMasterData CreateRollablePrefixesForOneHandedSwords();
        AffixRollCalculationTableMasterData CreateRollableSuffixesForOneHandedSwords();
        AffixRollCalculationTableMasterData CreateRollablePrefixesForRings();
        AffixRollCalculationTableMasterData CreateRollableSuffixesForRings();
        AffixRollCalculationTableMasterData CreateRollablePrefixesForBelts();
        AffixRollCalculationTableMasterData CreateRollableSuffixesForBelts();
        AffixRollCalculationTableMasterData CreateRollablePrefixesForAmulets();
        AffixRollCalculationTableMasterData CreateRollableSuffixesForAmulets();
    }
}