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

        public static DropTableEntry? ResolveItemDrop(List<DropTable> dropTables, int itemDropLevel)
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

            DropTableEntry? dropTableEntry = ChooseDropTableEntry(dropTableRow.Value, itemDropLevel);

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
            double roll = randomNumberGenerator.GenerateDoubleBetweenZeroAndOne();

            for (int i = 0; i < dropTable.DropTableRows.Count; i++)
            {
                if (i == dropTable.DropTableRows.Count - 1)
                {
                    return dropTable.DropTableRows[i];
                }

                DropTableRow row = dropTable.DropTableRows[i];

                if (roll <= row.DropChance)
                {
                    return row;
                }
            }

            return null;
        }

        private static DropTableEntry? ChooseDropTableEntry(DropTableRow dropTableRow, int itemDropLevel)
        {
            List<DropTableEntry> possibleDrops = null;

            while (possibleDrops == null || possibleDrops.Count == 0)
            {
                double roll = randomNumberGenerator.GenerateDoubleBetweenZeroAndOne();
                double lowestDropChanceHittingRoll = FindLowestDropChanceGreaterThanRollAndMinimumItemLevelLowerOrEqualTo(dropTableRow, roll, itemDropLevel);
                possibleDrops = GetEntriesWithSameChanceAndItemLevelLowerOrEqualTo(dropTableRow, lowestDropChanceHittingRoll, itemDropLevel);
            }

            if (possibleDrops.Count == 1)
            {
                return possibleDrops[0];
            }

            if (possibleDrops.Count > 1)
            {
                int index = randomNumberGenerator.GenerateRandomPositiveInteger(possibleDrops.Count - 1);
                return possibleDrops[index];
            }

            return null;
        }

        private static double FindLowestDropChanceGreaterThanRollAndMinimumItemLevelLowerOrEqualTo(DropTableRow dropTableRow, double roll, int itemDropLevel)
        {
            double lowestDropChance = 1.0;

            foreach (var entry in dropTableRow.DropTableEntries)
            {
                if (entry.DropChance >= roll && entry.DropChance < lowestDropChance && entry.Item.MinimumItemLevel <= itemDropLevel)
                {
                    lowestDropChance = entry.DropChance;
                }
            }

            return lowestDropChance;
        }

        private static List<DropTableEntry> GetEntriesWithSameChanceAndItemLevelLowerOrEqualTo(DropTableRow dropTableRow, double chance, int itemDropLevel)
        {
            List<DropTableEntry> result = new List<DropTableEntry>();

            foreach (var entry in dropTableRow.DropTableEntries)
            {
                if (entry.DropChance == chance && entry.Item.MinimumItemLevel <= itemDropLevel)
                {
                    result.Add(entry);
                }
            }

            return result;
        }
    }
}