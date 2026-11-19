namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public interface IRollableAffixesPerItemGroupMasterDataProvider
    {
        bool TryGetAffixByUniqueId(string uniqueId, out AffixRollCalculationTableEntryMasterData entry);
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