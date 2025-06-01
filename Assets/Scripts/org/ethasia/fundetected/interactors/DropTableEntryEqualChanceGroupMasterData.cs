using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Interactors
{
    public struct DropTableEntryEqualChanceGroupMasterData
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

        public DropTableEntryEqualChanceGroupMasterData(double dropChance)
        {
            this.DropChance = dropChance;
            this.DropTableEntries = new List<DropTableEntryMasterData>();
        }
    }
}