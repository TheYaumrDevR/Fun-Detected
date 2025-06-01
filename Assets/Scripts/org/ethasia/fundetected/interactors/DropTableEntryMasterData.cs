namespace Org.Ethasia.Fundetected.Interactors
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
            this.DropChance = dropChance;
            this.Item = item;
        }
    }
}