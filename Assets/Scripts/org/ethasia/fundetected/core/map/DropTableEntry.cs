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

        public Item DropItem()
        {
            Item result = Item.Clone();
            // TODO: give item a "roll random magic affixes" method which determines random affixes for a magic item. 
            // The item should have a 20% chance to drop as magic
            result.RerollEntireItem();

            return result;
        }
    }
}