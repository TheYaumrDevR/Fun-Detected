using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Equipment;

namespace Org.Ethasia.Fundetected.Core.Map.Tests
{
    public class TestDropTableFactory
    {
        public static List<DropTable> CreateDropTableWithFourJewelryItems()
        {
            DropTableEntry tableEntry1 = new DropTableEntry(0.1, CreateJewelryWithNameAndMinimumItemLevel("First Item", 0));
            DropTableEntry tableEntry2 = new DropTableEntry(0.1, CreateJewelryWithNameAndMinimumItemLevel("Second Item", 0));
            DropTableEntry tableEntry3 = new DropTableEntry(0.7, CreateJewelryWithNameAndMinimumItemLevel("Third Item", 0));
            DropTableEntry tableEntry4 = new DropTableEntry(0.1, CreateJewelryWithNameAndMinimumItemLevel("Fourth Item", 0));

            DropTableEntry tableEntry5 = new DropTableEntry(0.6, CreateJewelryWithNameAndMinimumItemLevel("First Item Fifth Row", 0));

            DropTableEntry tableEntry6 = new DropTableEntry(0.3, CreateJewelryWithNameAndMinimumItemLevel("First Item Third Row", 4));

            DropTableEntry tableEntry7 = new DropTableEntry(0.4, CreateJewelryWithNameAndMinimumItemLevel("First Item Second Row", 4));
            DropTableEntry tableEntry8 = new DropTableEntry(0.5, CreateJewelryWithNameAndMinimumItemLevel("Second Item Second Row", 1));

            DropTableRow row1 = new DropTableRow(0.00001);
            DropTableRow row2 = new DropTableRow(0.02);
            DropTableRow row3 = new DropTableRow(0.05);
            DropTableRow row4 = new DropTableRow(0.1);
            DropTableRow row5 = new DropTableRow(0.2);

            row2.DropTableEntries.Add(tableEntry7);
            row2.DropTableEntries.Add(tableEntry8);

            row3.DropTableEntries.Add(tableEntry6);

            row4.DropTableEntries.Add(tableEntry1);
            row4.DropTableEntries.Add(tableEntry2);
            row4.DropTableEntries.Add(tableEntry3);
            row4.DropTableEntries.Add(tableEntry4);

            row5.DropTableEntries.Add(tableEntry5);

            DropTable dropTable1 = new DropTable(100);
            DropTable dropTable2 = new DropTable(200);

            dropTable2.DropTableRows.Add(row1);
            dropTable2.DropTableRows.Add(row2);
            dropTable2.DropTableRows.Add(row3);
            dropTable2.DropTableRows.Add(row4);
            dropTable2.DropTableRows.Add(row5);

            List<DropTable> result = new List<DropTable>();
            result.Add(dropTable1);
            result.Add(dropTable2);

            return result;
        }

        private static Jewelry CreateJewelryWithNameAndMinimumItemLevel(string name, int minimumItemLevel)
        {
            Jewelry.Builder jewelryBuilder = new Jewelry.Builder();
            jewelryBuilder.SetName(name);
            jewelryBuilder.SetMinimumItemLevel(minimumItemLevel);

            return jewelryBuilder.Build();
        }
    }
}
