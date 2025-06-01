using UnityEngine;

namespace Org.Ethasia.Fundetected.Core.Items
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
            this.DropChance = dropChance;
            this.Item = item;
        }
    }
}