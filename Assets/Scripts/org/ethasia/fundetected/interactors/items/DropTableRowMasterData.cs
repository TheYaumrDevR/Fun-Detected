using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Interactors.Items
{
    public struct DropTableRowMasterData
    {
        public double DropChance
        {
            get;
            private set;
        }

        public List<DropTableEntryMasterData> DropTableEntries
        {
            get;
            private set;
        }

        public List<DropTableEntryEqualChanceGroupMasterData> DropTableEntryEqualChanceGroups
        {
            get;
            private set;
        }

        public DropTableRowMasterData(double dropChance)
        {
            this.DropChance = dropChance;
            this.DropTableEntries = new List<DropTableEntryMasterData>();
            this.DropTableEntryEqualChanceGroups = new List<DropTableEntryEqualChanceGroupMasterData>();
        }
    }
}