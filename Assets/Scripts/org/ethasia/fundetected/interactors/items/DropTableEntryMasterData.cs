namespace Org.Ethasia.Fundetected.Interactors.Items
{
    public struct DropTableEntryMasterData
    {
        public double DropChance
        {
            get;
            private set;
        }

        public ItemMasterData Item
        {
            get;
            private set;
        }

        public DropTableEntryMasterData(double dropChance, ItemMasterData item)
        {
            DropChance = dropChance;
            Item = item;
        }
    }
}