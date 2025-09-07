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
            DropTableEntryMasterData tinyLifePotion = new DropTableEntryMasterData(1.0, potionMasterDataProvider.GetTinyLifePotionMasterData());
            DropTableEntryMasterData warBelt = new DropTableEntryMasterData(1.0, jewelryMasterDataProvider.GetWarBeltMasterData());
            DropTableEntryMasterData ironAmulet = new DropTableEntryMasterData(1.0, jewelryMasterDataProvider.GetIronAmuletMasterData());
            DropTableEntryMasterData ironBand = new DropTableEntryMasterData(1.0, jewelryMasterDataProvider.GetDiamondBandMasterData());

            DropTableRowMasterData tier1Row = new DropTableRowMasterData(1.0);
            tier1Row.DropTableEntries.Add(tinyLifePotion);
            tier1Row.DropTableEntries.Add(warBelt);
            tier1Row.DropTableEntries.Add(ironAmulet);
            tier1Row.DropTableEntries.Add(ironBand);

            DropTableMasterData result = new DropTableMasterData(100);
            result.DropTableRows.Add(tier1Row);

            return result;
        }
    }
}