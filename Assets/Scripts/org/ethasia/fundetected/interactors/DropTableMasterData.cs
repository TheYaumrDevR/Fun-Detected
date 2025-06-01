using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Interactors
{
    public struct DropTableMasterData
    {
        public int DropWeight
        {
            get;
            private set;
        }

        public List<DropTableRowMasterData> DropTableRows
        {
            get;
            private set;
        }

        public DropTableMasterData(int dropWeight)
        {
            this.DropWeight = dropWeight;
            this.DropTableRows = new List<DropTableRowMasterData>();
        }
    }
}