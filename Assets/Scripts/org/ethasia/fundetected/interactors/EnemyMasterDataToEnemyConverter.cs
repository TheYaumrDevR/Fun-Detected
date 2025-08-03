using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class EnemyMasterDataToEnemyConverter
    {
        public static Enemy CreateEnemyFromMasterData(EnemyMasterData enemyMasterData, EnemySpawnLocation spawnLocationData, int spawnId)
        {
            BoundingBox enemyBoundingBox = new BoundingBox.Builder()
                .SetDistanceToRightEdge(enemyMasterData.DistanceToRightEdge)
                .SetDistanceToLeftEdge(enemyMasterData.DistanceToLeftEdge)
                .SetDistanceToBottomEdge(enemyMasterData.DistanceToBottomEdge)
                .SetDistanceToTopEdge(enemyMasterData.DistanceToTopEdge)
                .Build();

            Enemy result = new Enemy.Builder()
                .SetIndividualId(enemyMasterData.Id + spawnId)
                .SetTypeId(enemyMasterData.Id)
                .SetName(enemyMasterData.Name)
                .SetIsAggressiveOnSight(enemyMasterData.IsAggressiveOnSight)
                .SetAttacksPerSecond(enemyMasterData.AttacksPerSecond)
                .SetUnarmedStrikeRange(enemyMasterData.UnarmedStrikeRange)
                .SetCorpseMass(enemyMasterData.CorpseMass)
                .SetMinToMaxPhysicalDamage(new DamageRange(enemyMasterData.ScalableMasterData.MinPhysicalDamage, enemyMasterData.ScalableMasterData.MaxPhysicalDamage))
                .SetLife(enemyMasterData.ScalableMasterData.MaxLife)
                .SetArmor(enemyMasterData.ScalableMasterData.Armor)
                .SetAccuracyRating(enemyMasterData.ScalableMasterData.AccuracyRating)
                .SetEvasionRating(enemyMasterData.ScalableMasterData.EvasionRating)
                .SetBoundingBox(enemyBoundingBox)
                .SetPosition(spawnLocationData.MapLocation)
                .Build();

            EnemyAbility enemyAbility = enemyMasterData.AbilityMasterData.CreateAbilityForEnemy(result);
            string abilityName = enemyMasterData.AbilityMasterData.GetAbilityName();

            result.AddAbilityByName(abilityName, enemyAbility);

            AddDropTablesToEnemy(result, enemyMasterData);

            return result;
        }

        private static void AddDropTablesToEnemy(Enemy enemy, EnemyMasterData enemyMasterData)
        {
            foreach (DropTableMasterData dropTableMasterData in enemyMasterData.DropTables)
            {
                DropTable dropTable = ConvertDropTableMasterDataToDropTable(dropTableMasterData);
                enemy.AddDropTable(dropTable);
            }
        }

        private static DropTable ConvertDropTableMasterDataToDropTable(DropTableMasterData masterData)
        {
            DropTable result = new DropTable(masterData.DropWeight);

            foreach (DropTableRowMasterData row in masterData.DropTableRows)
            {
                result.DropTableRows.Add(ConvertDropTableRowMasterDataToDropTableRow(row));
            }

            result.DropTableRows.Sort((a, b) => a.DropChance.CompareTo(b.DropChance));

            return result;
        }

        private static DropTableRow ConvertDropTableRowMasterDataToDropTableRow(DropTableRowMasterData masterData)
        {
            DropTableRow result = new DropTableRow(masterData.DropChance);

            foreach (DropTableEntryMasterData entry in masterData.DropTableEntries)
            {
                result.DropTableEntries.Add(ConvertDropTableEntryMasterDataToDropTableEntry(entry));
            }

            foreach (DropTableEntryEqualChanceGroupMasterData group in masterData.DropTableEntryEqualChanceGroups)
            {
                foreach (DropTableEntryMasterData entry in group.DropTableEntries)
                {
                    result.DropTableEntries.Add(ConvertDropTableEntryMasterDataToDropTableEntry(entry, group.DropChance));
                }
            }

            result.DropTableEntries.Sort((a, b) => a.DropChance.CompareTo(b.DropChance));

            return result;
        }        

        private static DropTableEntry ConvertDropTableEntryMasterDataToDropTableEntry(DropTableEntryMasterData masterData)
        {
            return new DropTableEntry(masterData.DropChance, masterData.Item.ToItem());
        }
        
        private static DropTableEntry ConvertDropTableEntryMasterDataToDropTableEntry(DropTableEntryMasterData masterData, double dropChance)
        {
            return new DropTableEntry(dropChance, masterData.Item.ToItem());
        }
    }
}