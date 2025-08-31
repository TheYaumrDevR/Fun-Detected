using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Equipment;

namespace Org.Ethasia.Fundetected.Core.Map.Tests
{
    public class TestDropTableFactory
    {
        public static List<DropTable> CreateDropTableWithFourJewelryItems()
        {
            DropTableEntry tableEntry1 = new DropTableEntry(0.1, CreateJewelryWithName("First Item"));
            DropTableEntry tableEntry2 = new DropTableEntry(0.1, CreateJewelryWithName("Second Item"));
            DropTableEntry tableEntry3 = new DropTableEntry(0.7, CreateJewelryWithName("Third Item"));
            DropTableEntry tableEntry4 = new DropTableEntry(0.1, CreateJewelryWithName("Fourth Item"));

            DropTableEntry tableEntry5 = new DropTableEntry(0.6, CreateJewelryWithName("First Item Third Row"));

            DropTableRow row1 = new DropTableRow(0.00001);
            DropTableRow row2 = new DropTableRow(0.1);
            DropTableRow row3 = new DropTableRow(0.2);

            row2.DropTableEntries.Add(tableEntry1);
            row2.DropTableEntries.Add(tableEntry2);
            row2.DropTableEntries.Add(tableEntry3);
            row2.DropTableEntries.Add(tableEntry4);

            row3.DropTableEntries.Add(tableEntry5);

            DropTable dropTable1 = new DropTable(100);
            DropTable dropTable2 = new DropTable(200);

            dropTable2.DropTableRows.Add(row1);
            dropTable2.DropTableRows.Add(row2);
            dropTable2.DropTableRows.Add(row3);

            List<DropTable> result = new List<DropTable>();
            result.Add(dropTable1);
            result.Add(dropTable2);

            return result;
        }

        private static Jewelry CreateJewelryWithName(string name)
        {
            Jewelry.Builder jewelryBuilder = new Jewelry.Builder();
            jewelryBuilder.SetName(name);

            return jewelryBuilder.Build();
        }
    }
}
