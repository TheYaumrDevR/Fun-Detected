using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class DropTableMasterDataProvider
    {
        private PotionMasterDataProvider potionMasterDataProvider;

        public DropTableMasterDataProvider()
        {
            this.potionMasterDataProvider = new PotionMasterDataProvider();
        }

        public DropTableMasterData GetGlobalDropTable()
        {
            DropTableEntryMasterData tinyLifePotion = new DropTableEntryMasterData(1.0, potionMasterDataProvider.GetTinyLifePotionMasterData());

            DropTableRowMasterData tier1Row = new DropTableRowMasterData(1.0);
            tier1Row.DropTableEntries.Add(tinyLifePotion);

            DropTableMasterData result = new DropTableMasterData(100);
            result.DropTableRows.Add(tier1Row);

            return result;
        }
    }
}