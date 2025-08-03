using System.Collections.Generic;

using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{
    public class EnemyMasterDataProviderMock : IEnemyMasterDataProvider
    {
        private Dictionary<string, EnemyMasterData> enemyMasterDataById;

        public EnemyMasterDataProviderMock()
        {
            enemyMasterDataById = new Dictionary<string, EnemyMasterData>();
            enemyMasterDataById["Drowned Zombie"] = CreateDrownedZombieMasterData();
            enemyMasterDataById["Wolf"] = CreateWolfMasterData();
            enemyMasterDataById["Fire Mage"] = CreateFireMageMasterData();
            enemyMasterDataById["Animated Thornbush"] = CreateAnimatedThornbushMasterData();
        }

        public EnemyMasterData CreateEnemyMasterDataById(string id)
        {
            return enemyMasterDataById[id];
        }

        public EnemyMasterDataForRendering CreateEnemyMasterDataForRenderingById(string id)
        {
            EnemyMasterDataForRendering result = new EnemyMasterDataForRendering();
            result.DistanceToLeftRenderEdge = 7;
            result.DistanceToRightRenderEdge = 7;
            result.DistanceToBottomRenderEdge = 7;
            result.DistanceToTopRenderEdge = 7;

            return result;
        }

        private EnemyMasterData CreateDrownedZombieMasterData()
        {
            EnemyMasterData result = new EnemyMasterData();
            result.Id = "DrownedZombie";
            result.Name = "Drowned Zombie";
            result.ScalableMasterData.MaxLife = 30;
            result.ScalableMasterData.Armor = 1;
            result.ScalableMasterData.EvasionRating = 98;

            AbilityMasterData mockAbilityMasterData = new UnarmedSwingAbilityMasterData
            {
                AbilityName = "Mock Ability"
            };
            result.AbilityMasterData = mockAbilityMasterData;
            result.DropTables = new List<DropTableMasterData>();
            result.DropTables.Add(GetGlobalDropTable());

            return result;
        }

        private EnemyMasterData CreateWolfMasterData()
        {
            EnemyMasterData result = new EnemyMasterData();
            result.Id = "Wolf";
            result.Name = "Wolf";
            result.ScalableMasterData.MaxLife = 40;
            result.ScalableMasterData.Armor = 1;
            result.ScalableMasterData.EvasionRating = 98;
            result.MinimumSpawnLevel = 1;

            AbilityMasterData mockAbilityMasterData = new UnarmedSwingAbilityMasterData
            {
                AbilityName = "Mock Ability"
            };
            result.AbilityMasterData = mockAbilityMasterData;

            FixedStatsPerLevelEnemyScalingMasterData scalingStrategy = new FixedStatsPerLevelEnemyScalingMasterData();

            ScalableEnemyMasterData additionsPerLevel = new ScalableEnemyMasterData();
            additionsPerLevel.MaxLife = 5;
            additionsPerLevel.Armor = 4;
            additionsPerLevel.FireResistance = 3;
            additionsPerLevel.IceResistance = 3;
            additionsPerLevel.LightningResistance = 3;
            additionsPerLevel.MagicResistance = 3;
            additionsPerLevel.MinPhysicalDamage = 1;
            additionsPerLevel.MaxPhysicalDamage = 5;
            additionsPerLevel.AccuracyRating = 6;
            additionsPerLevel.EvasionRating = 2;

            scalingStrategy.AdditionsPerLevel = additionsPerLevel;

            result.ScalingStrategy = scalingStrategy;

            result.DropTables = new List<DropTableMasterData>();
            result.DropTables.Add(GetGlobalDropTable());

            return result;
        }

        private EnemyMasterData CreateFireMageMasterData()
        {
            EnemyMasterData result = new EnemyMasterData();
            result.Id = "FireMage";
            result.Name = "Fire Mage";
            result.ScalableMasterData.MaxLife = 25;
            result.ScalableMasterData.Armor = 1;
            result.ScalableMasterData.EvasionRating = 98;
            result.MinimumSpawnLevel = 3;

            AbilityMasterData mockAbilityMasterData = new UnarmedSwingAbilityMasterData
            {
                AbilityName = "Fire Ball"
            };
            result.AbilityMasterData = mockAbilityMasterData;

            FixedStatsPerLevelEnemyScalingMasterData scalingStrategy = new FixedStatsPerLevelEnemyScalingMasterData();

            ScalableEnemyMasterData additionsPerLevel = new ScalableEnemyMasterData();
            scalingStrategy.AdditionsPerLevel = additionsPerLevel;

            result.ScalingStrategy = scalingStrategy;

            result.DropTables = new List<DropTableMasterData>();
            result.DropTables.Add(GetGlobalDropTable());

            return result;
        }

        private EnemyMasterData CreateAnimatedThornbushMasterData()
        {
            EnemyMasterData result = new EnemyMasterData();
            result.Id = "AnimatedThornbush";
            result.Name = "Animated Thornbush";
            result.ScalableMasterData.MaxLife = 25;
            result.ScalableMasterData.Armor = 2;
            result.ScalableMasterData.EvasionRating = 98;
            result.MinimumSpawnLevel = 1;

            AbilityMasterData mockAbilityMasterData = new UnarmedSwingAbilityMasterData
            {
                AbilityName = "Mock Ability"
            };
            result.AbilityMasterData = mockAbilityMasterData;

            FixedStatsPerLevelEnemyScalingMasterData scalingStrategy = new FixedStatsPerLevelEnemyScalingMasterData();

            ScalableEnemyMasterData additionsPerLevel = new ScalableEnemyMasterData();
            scalingStrategy.AdditionsPerLevel = additionsPerLevel;

            result.ScalingStrategy = scalingStrategy;

            result.DropTables = new List<DropTableMasterData>();
            result.DropTables.Add(GetGlobalDropTable());

            return result;
        }   

        public DropTableMasterData GetGlobalDropTable()
        {
            return new DropTableMasterData(100);
        }                                   
    }
}