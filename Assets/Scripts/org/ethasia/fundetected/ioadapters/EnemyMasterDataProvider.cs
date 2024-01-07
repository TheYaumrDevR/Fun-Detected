using System;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class EnemyMasterDataProvider : IEnemyMasterDataProvider
    {
        private static readonly Dictionary<string, Func<string, EnemyMasterData>> enemyIdByProductionFunction;

        static EnemyMasterDataProvider()
        {
            enemyIdByProductionFunction = new Dictionary<string, Func<string, EnemyMasterData>>();

            enemyIdByProductionFunction["Drowned Zombie"] = CreateDrownedZombieMasterData;
            enemyIdByProductionFunction["Animated Thornbush"] = CreateAnimatedThornBushMasterData;
        }

        public EnemyMasterData CreateEnemyMasterDataById(string id)
        {
            if (null != enemyIdByProductionFunction[id])
            {
                return enemyIdByProductionFunction[id](id);
            }

            throw new AssetLoadFailureException("Could not load enemy data for enemy id: " + id);
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
            result.MaxLife = 21;
            result.Armor = 3;
            result.EvasionRating = 98;
            result.DistanceToLeftEdge = 7;
            result.DistanceToRightEdge = 7;
            result.DistanceToBottomEdge = 7;
            result.DistanceToTopEdge = 7;

            return result;
        }        
    }
}