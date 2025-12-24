using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors.Items;

namespace Org.Ethasia.Fundetected.Interactors.Combat
{
    public class EnemyMasterDataToEnemyConverter
    {
        public static Enemy CreateEnemyFromMasterData(EnemyCreationContext enemyCreationContext)
        {
            BoundingBox enemyBoundingBox = new BoundingBox.Builder()
                .SetDistanceToRightEdge(enemyCreationContext.EnemyMasterData.DistanceToRightEdge)
                .SetDistanceToLeftEdge(enemyCreationContext.EnemyMasterData.DistanceToLeftEdge)
                .SetDistanceToBottomEdge(enemyCreationContext.EnemyMasterData.DistanceToBottomEdge)
                .SetDistanceToTopEdge(enemyCreationContext.EnemyMasterData.DistanceToTopEdge)
                .Build();

            Enemy result = new Enemy.Builder()
                .SetIndividualId(enemyCreationContext.EnemyMasterData.Id + enemyCreationContext.SpawnId)
                .SetTypeId(enemyCreationContext.EnemyMasterData.Id)
                .SetName(enemyCreationContext.EnemyMasterData.Name)
                .SetIsAggressiveOnSight(enemyCreationContext.EnemyMasterData.IsAggressiveOnSight)
                .SetDropChance(enemyCreationContext.EnemyMasterData.DropChance)
                .SetDropLevelOfItems(enemyCreationContext.EnemyLevel)
                .SetAttacksPerSecond(enemyCreationContext.EnemyMasterData.AttacksPerSecond)
                .SetUnarmedStrikeRange(enemyCreationContext.EnemyMasterData.UnarmedStrikeRange)
                .SetCorpseMass(enemyCreationContext.EnemyMasterData.CorpseMass)
                .SetMinToMaxPhysicalDamage(new DamageRange(enemyCreationContext.EnemyMasterData.ScalableMasterData.MinPhysicalDamage, enemyCreationContext.EnemyMasterData.ScalableMasterData.MaxPhysicalDamage))
                .SetLife(enemyCreationContext.EnemyMasterData.ScalableMasterData.MaxLife)
                .SetArmor(enemyCreationContext.EnemyMasterData.ScalableMasterData.Armor)
                .SetAccuracyRating(enemyCreationContext.EnemyMasterData.ScalableMasterData.AccuracyRating)
                .SetEvasionRating(enemyCreationContext.EnemyMasterData.ScalableMasterData.EvasionRating)
                .SetBoundingBox(enemyBoundingBox)
                .SetPosition(enemyCreationContext.SpawnLocation.MapLocation)
                .Build();

            EnemyAbility enemyAbility = enemyCreationContext.EnemyMasterData.AbilityMasterData.CreateAbilityForEnemy(result);
            string abilityName = enemyCreationContext.EnemyMasterData.AbilityMasterData.GetAbilityName();

            result.AddAbilityByName(abilityName, enemyAbility);

            AddDropTablesToEnemy(result, enemyCreationContext.EnemyMasterData);

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

        public struct EnemyCreationContext
        {
            public EnemyMasterData EnemyMasterData;
            public EnemySpawnLocation SpawnLocation;
            public int SpawnId;
            public int EnemyLevel;
        }
    }
}