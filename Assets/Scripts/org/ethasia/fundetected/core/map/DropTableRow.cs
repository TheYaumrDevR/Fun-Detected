using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Core.Map
{
    public struct DropTableRow
    {
        public double DropChance
        {
            get;
            private set;
        }

        public List<DropTableEntry> DropTableEntries
        {
            get;
            private set;
        }

        public DropTableRow(double dropChance)
        {
            DropChance = dropChance;
            DropTableEntries = new List<DropTableEntry>();
        }
    }
}