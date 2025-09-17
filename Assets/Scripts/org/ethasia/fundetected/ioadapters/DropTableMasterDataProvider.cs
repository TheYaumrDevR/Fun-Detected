using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class DropTableMasterDataProvider
    {
        private PotionMasterDataProvider potionMasterDataProvider;
        private JewelryMasterDataProvider jewelryMasterDataProvider;

        public DropTableMasterDataProvider()
        {
            this.potionMasterDataProvider = new PotionMasterDataProvider();
            this.jewelryMasterDataProvider = new JewelryMasterDataProvider();
        }

        public DropTableMasterData GetGlobalDropTable()
        {
            DropTableEntryMasterData tinyLifePotion = new DropTableEntryMasterData(0, potionMasterDataProvider.GetTinyLifePotionMasterData());
            DropTableEntryMasterData warBelt = new DropTableEntryMasterData(0, jewelryMasterDataProvider.GetWarBeltMasterData());
            DropTableEntryMasterData ironAmulet = new DropTableEntryMasterData(0, jewelryMasterDataProvider.GetIronAmuletMasterData());
            DropTableEntryMasterData ironBand = new DropTableEntryMasterData(0, jewelryMasterDataProvider.GetDiamondBandMasterData());

            DropTableEntryEqualChanceGroupMasterData jewelryGroup = new DropTableEntryEqualChanceGroupMasterData(1.0);
            jewelryGroup.DropTableEntries.Add(tinyLifePotion);
            jewelryGroup.DropTableEntries.Add(warBelt);
            jewelryGroup.DropTableEntries.Add(ironAmulet);
            jewelryGroup.DropTableEntries.Add(ironBand);

            DropTableRowMasterData tier1Row = new DropTableRowMasterData(1.0);
            tier1Row.DropTableEntryEqualChanceGroups.Add(jewelryGroup);

            DropTableMasterData result = new DropTableMasterData(100);
            result.DropTableRows.Add(tier1Row);

            return result;
        }
    }
}