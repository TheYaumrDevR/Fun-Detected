using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class DropTableMasterDataProvider
    {
        private PotionMasterDataProvider potionMasterDataProvider;
        private JewelryMasterDataProvider jewelryMasterDataProvider;
        private WeaponMasterDataProvider weaponMasterDataProvider;

        public DropTableMasterDataProvider()
        {
            this.potionMasterDataProvider = new PotionMasterDataProvider();
            this.jewelryMasterDataProvider = new JewelryMasterDataProvider();
            this.weaponMasterDataProvider = new WeaponMasterDataProvider();
        }

        public DropTableMasterData GetGlobalDropTable()
        {
            DropTableEntryMasterData tinyLifePotion = new DropTableEntryMasterData(0, potionMasterDataProvider.GetTinyLifePotionMasterData());
            DropTableEntryMasterData warBelt = new DropTableEntryMasterData(0, jewelryMasterDataProvider.GetWarBeltMasterData());
            DropTableEntryMasterData ironAmulet = new DropTableEntryMasterData(0, jewelryMasterDataProvider.GetIronAmuletMasterData());
            DropTableEntryMasterData diamondBand = new DropTableEntryMasterData(0, jewelryMasterDataProvider.GetDiamondBandMasterData());
            DropTableEntryMasterData ironSpikeBand = new DropTableEntryMasterData(0, jewelryMasterDataProvider.GetIronspikeBandMasterData());
            DropTableEntryMasterData corrodedCutlass = new DropTableEntryMasterData(0, weaponMasterDataProvider.GetCorrodedCutlassMasterData());

            DropTableEntryEqualChanceGroupMasterData group1 = new DropTableEntryEqualChanceGroupMasterData(1.0);
            group1.DropTableEntries.Add(tinyLifePotion);
            group1.DropTableEntries.Add(warBelt);
            group1.DropTableEntries.Add(ironAmulet);
            group1.DropTableEntries.Add(diamondBand);
            group1.DropTableEntries.Add(ironSpikeBand);
            group1.DropTableEntries.Add(corrodedCutlass);

            DropTableRowMasterData tier1Row = new DropTableRowMasterData(1.0);
            tier1Row.DropTableEntryEqualChanceGroups.Add(group1);

            DropTableMasterData result = new DropTableMasterData(100);
            result.DropTableRows.Add(tier1Row);

            return result;
        }
    }
}