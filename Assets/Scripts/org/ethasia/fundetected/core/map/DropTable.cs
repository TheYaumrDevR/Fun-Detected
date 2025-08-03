using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Core.Map
{
    public struct DropTable
    {
        public int DropWeight
        {
            get;
            private set;
        }

        public List<DropTableRow> DropTableRows
        {
            get;
            private set;
        }

        public DropTable(int dropWeight)
        {
            this.DropWeight = dropWeight;
            this.DropTableRows = new List<DropTableRow>();
        }
    }
}