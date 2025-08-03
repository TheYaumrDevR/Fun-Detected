using Org.Ethasia.Fundetected.Core.Items;

namespace Org.Ethasia.Fundetected.Core.Map
{
    public struct DropTableEntry
    {
        public double DropChance
        {
            get;
            private set;
        }

        public Item Item
        {
            get;
            private set;
        }

        public DropTableEntry(double dropChance, Item item)
        {
            DropChance = dropChance;
            Item = item;
        }
    }
}