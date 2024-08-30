using System;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class EnemyMasterDataProvider : IEnemyMasterDataProvider
    {
        private static readonly Dictionary<string, Func<string, EnemyMasterData>> enemyIdByProductionFunction;
        private static readonly Dictionary<string, Func<string, EnemyMasterDataForRendering>> enemyIdByRenderMasterDataProductionFunction;

        static EnemyMasterDataProvider()
        {
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
            result.MaxLife = 30;
            result.Armor = 1;
            result.EvasionRating = 98;

            return result;
        }

        private static EnemyMasterData CreateAnimatedThornBushMasterData(string id)
        {
            EnemyMasterData result = new EnemyMasterData();
            result.Id = id;
            result.Name = "Animated Thornbush";
            result.IsAggressiveOnSight = false;
            result.MaxLife = 21;
            result.Armor = 3;
            result.EvasionRating = 98;
            result.AttacksPerSecond = 1.2f;
            result.UnarmedStrikeRange = 10;
            result.CorpseMass = 4;
            result.MinPhysicalDamage = 1;
            result.MaxPhysicalDamage = 3;
            result.DistanceToLeftEdge = 7;
            result.DistanceToRightEdge = 7;
            result.DistanceToBottomEdge = 7;
            result.DistanceToTopEdge = 7;

            UnarmedAsymmetricSwingAbilityMasterData unarmedAsymmetricSwingAbilityMasterData = new UnarmedAsymmetricSwingAbilityMasterData
            {
                AbilityName = "Branch Swing",
                LeftSwingData = new UnarmedSwingAbilityMasterData()
                {
                    HitArcStartAngle = -1.7088518706, // -97,91
                    HitArcEndAngle = -2.671575486, // -153,07
                    HitArcRadius = 10,
                    HitArcCenterXOffset = 0,
                    HitArcCenterYOffset = 0,
                    DefaultTimeToHit = 0.25f
                },
                RightSwingData = new UnarmedSwingAbilityMasterData()
                {
                    HitArcStartAngle = -1.4030701857, // -80,39
                    HitArcEndAngle = -0.637045177, // -36,5
                    HitArcRadius = 10,
                    HitArcCenterXOffset = 0,
                    HitArcCenterYOffset = 0,
                    DefaultTimeToHit = 0.25f
                }
            };

            result.AbilityMasterData = unarmedAsymmetricSwingAbilityMasterData;

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

            return result;
        }            
    }
}