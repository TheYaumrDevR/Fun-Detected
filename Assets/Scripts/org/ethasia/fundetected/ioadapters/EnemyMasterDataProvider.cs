using System;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class EnemyMasterDataProvider : IEnemyMasterDataProvider
    {
        private static readonly Dictionary<string, Func<string, EnemyMasterData>> enemyIdByProductionFunction;
        private static readonly Dictionary<string, Func<string, EnemyMasterDataForRendering>> enemyIdByRenderMasterDataProductionFunction;

        private static DropTableMasterDataProvider dropTableMasterDataProvider;

        static EnemyMasterDataProvider()
        {
            dropTableMasterDataProvider = new DropTableMasterDataProvider();

            enemyIdByProductionFunction = new Dictionary<string, Func<string, EnemyMasterData>>();
            enemyIdByRenderMasterDataProductionFunction = new Dictionary<string, Func<string, EnemyMasterDataForRendering>>();

            enemyIdByProductionFunction["Drowned Zombie"] = CreateDrownedZombieMasterData;
            enemyIdByProductionFunction["Animated Thornbush"] = CreateAnimatedThornBushMasterData;

            enemyIdByRenderMasterDataProductionFunction["Drowned Zombie"] = CreateDrownedZombieMasterDataForRendering;
            enemyIdByRenderMasterDataProductionFunction["Animated Thornbush"] = CreateAnimatedThornBushMasterDataForRendering;
        }

        public EnemyMasterData CreateEnemyMasterDataById(string id)
        {
            if (null != enemyIdByProductionFunction[id])
            {
                return enemyIdByProductionFunction[id](id);
            }

            throw new AssetLoadFailureException("Could not load enemy data for enemy id: " + id);
        }

        public EnemyMasterDataForRendering CreateEnemyMasterDataForRenderingById(string id)
        {
            if (null != enemyIdByRenderMasterDataProductionFunction[id])
            {
                return enemyIdByRenderMasterDataProductionFunction[id](id);
            }

            throw new AssetLoadFailureException("Could not load enemy rendering data for enemy id: " + id);
        }

        private static EnemyMasterData CreateDrownedZombieMasterData(string id)
        {
            EnemyMasterData result = new EnemyMasterData();
            result.Id = id;
            result.Name = "Drowned Zombie";
            result.ScalableMasterData.MaxLife = 30;
            result.ScalableMasterData.Armor = 1;
            result.ScalableMasterData.EvasionRating = 98;

            return result;
        }

        private static EnemyMasterData CreateAnimatedThornBushMasterData(string id)
        {
            EnemyMasterData result = new EnemyMasterData();
            result.Id = id;
            result.Name = "Animated Thornbush";
            result.IsAggressiveOnSight = false;
            result.MinimumSpawnLevel = 1;
            result.ScalableMasterData.MaxLife = 21;
            result.ScalableMasterData.Armor = 3;
            result.ScalableMasterData.EvasionRating = 98;
            result.ScalableMasterData.AccuracyRating = 8;
            result.AttacksPerSecond = 1.2f;
            result.UnarmedStrikeRange = 12;
            result.CorpseMass = 4;
            result.ScalableMasterData.MinPhysicalDamage = 1;
            result.ScalableMasterData.MaxPhysicalDamage = 3;
            result.DistanceToLeftEdge = 7;
            result.DistanceToRightEdge = 7;
            result.DistanceToBottomEdge = 7;
            result.DistanceToTopEdge = 7;

            DropTableMasterData globalDropTable = dropTableMasterDataProvider.GetGlobalDropTable();

            UnarmedAsymmetricSwingAbilityMasterData unarmedAsymmetricSwingAbilityMasterData = new UnarmedAsymmetricSwingAbilityMasterData
            {
                AbilityName = "Branch Swing",
                LeftSwingData = new UnarmedSwingAbilityMasterData()
                {
                    HitArcStartAngle = -2.671575486, // -97,91
                    HitArcEndAngle = -1.7088518706, // -153,07
                    HitArcRadius = 12,
                    HitArcCenterXOffset = -1,
                    HitArcCenterYOffset = -6,
                    DefaultTimeToHit = 0.25f
                },
                RightSwingData = new UnarmedSwingAbilityMasterData()
                {
                    HitArcStartAngle = -1.4030701857, // -80,39
                    HitArcEndAngle = -0.637045177, // -36,5
                    HitArcRadius = 12,
                    HitArcCenterXOffset = 1,
                    HitArcCenterYOffset = -7,
                    DefaultTimeToHit = 0.25f
                }
            };

            IMasterDataScalingStrategy scalingStrategy = new FixedStatsPerLevelEnemyScalingMasterData       
            {
                AdditionsPerLevel = new ScalableEnemyMasterData
                {
                    MaxLife = 2,
                    Armor = 1,
                    FireResistance = 0,
                    IceResistance = 0,
                    LightningResistance = 0,
                    MagicResistance = 0,
                    MinPhysicalDamage = 1,
                    MaxPhysicalDamage = 2,
                    AccuracyRating = 1,
                    EvasionRating = 9
                }
            }; 

            result.AbilityMasterData = unarmedAsymmetricSwingAbilityMasterData;
            result.ScalingStrategy = scalingStrategy;

            result.DropTables = new List<DropTableMasterData>();
            result.DropTables.Add(globalDropTable);

            return result;
        }    

        private static EnemyMasterData CreateBloatedHorseFlySwarmMasterData(string id)
        {
            // Its attack is an ability which deals physical damage over time in a circle around it. It can apply bleeding to the player.
            EnemyMasterData result = new EnemyMasterData();

            return result;
        }        

        private static EnemyMasterDataForRendering CreateDrownedZombieMasterDataForRendering(string id)
        {
            EnemyMasterDataForRendering result = new EnemyMasterDataForRendering();

            return result;
        }

        private static EnemyMasterDataForRendering CreateAnimatedThornBushMasterDataForRendering(string id)
        {
            EnemyMasterDataForRendering result = new EnemyMasterDataForRendering();
            result.DistanceToLeftRenderEdge = 12;
            result.DistanceToRightRenderEdge = 12;
            result.DistanceToBottomRenderEdge = 12;
            result.DistanceToTopRenderEdge = 12;
            result.SpawnPointOffsetX = 0;
            result.SpawnPointOffsetY = 8;

            return result;
        }            
    }
}