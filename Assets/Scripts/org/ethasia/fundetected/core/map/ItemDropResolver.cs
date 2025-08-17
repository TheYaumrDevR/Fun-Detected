using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Core.Map
{
    public class ItemDropResolver
    {
        private static IRandomNumberGenerator randomNumberGenerator;

        static ItemDropResolver()
        {
            randomNumberGenerator = IoAdaptersFactoryForCore.GetInstance().GetRandomNumberGeneratorInstance();
        }

        public static DropTableEntry? ResolveItemDrop(List<DropTable> dropTables)
        {
            DropTable? dropTable = ChooseDropTable(dropTables);

            if (dropTable == null)
            {
                return null;
            }

            DropTableRow? dropTableRow = ChooseDropTableRow(dropTable.Value);

            if (dropTableRow == null)
            {
                return null;
            }

            DropTableEntry? dropTableEntry = ChooseDropTableEntry(dropTableRow.Value);

            if (dropTableEntry == null)
            {
                return null;
            }

            return dropTableEntry.Value;
        }

        private static DropTable? ChooseDropTable(List<DropTable> dropTables)
        {
            int totalWeight = CalculateTotalWeight(dropTables);
            int dropTableRoll = randomNumberGenerator.GenerateRandomPositiveInteger(totalWeight);
            return SelectDropTableFromRollByWeight(dropTables, dropTableRoll);
        }

        private static int CalculateTotalWeight(List<DropTable> dropTables)
        {
            int result = 0;

            foreach (var dropTable in dropTables)
            {
                result += dropTable.DropWeight;
            }

            return result;
        }

        private static DropTable? SelectDropTableFromRollByWeight(List<DropTable> dropTables, int dropTableRoll)
        {
            int currentWeight = 0;
            foreach (var dropTable in dropTables)
            {
                currentWeight += dropTable.DropWeight;

                if (dropTableRoll < currentWeight)
                {
                    return dropTable;
                }
            }

            return null;
        }

        private static DropTableRow? ChooseDropTableRow(DropTable dropTable)
        {
            for (int i = 0; i < dropTable.DropTableRows.Count; i++)
            {
                if (i == dropTable.DropTableRows.Count - 1)
                {
                    return dropTable.DropTableRows[i];
                }

                DropTableRow row = dropTable.DropTableRows[i];

                if (randomNumberGenerator.CheckProbabilityIsHit(row.DropChance))
                {
                    return row;
                }
            }

            return null;
        }

        private static DropTableEntry? ChooseDropTableEntry(DropTableRow dropTableRow)
        {
            for (int i = 0; i < dropTableRow.DropTableEntries.Count; i++)
            {
                DropTableEntry entry = dropTableRow.DropTableEntries[i];

                if (randomNumberGenerator.CheckProbabilityIsHit(entry.DropChance))
                {
                    return entry;
                }

                if (i == dropTableRow.DropTableEntries.Count - 1)
                {
                    i = -1;
                }
            }

            return null;
        }
    }
}