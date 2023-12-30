using System;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class EnemyMasterDataProvider : IEnemyMasterDataProvider
    {
        private static readonly Dictionary<string, Func<EnemyMasterData>> enemyIdByProductionFunction;

        static EnemyMasterDataProvider()
        {
            enemyIdByProductionFunction = new Dictionary<string, Func<EnemyMasterData>>();

            enemyIdByProductionFunction["Drowned Zombie"] = CreateDrownedZombieMasterData;
            enemyIdByProductionFunction["Animated Thornbush"] = CreateAnimatedThornBushMasterData;
        }

        public EnemyMasterData CreateEnemyMasterDataById(string id)
        {
            if (null != enemyIdByProductionFunction[id])
            {
                return enemyIdByProductionFunction[id]();
            }

            throw new AssetLoadFailureException("Could not load enemy data for enemy id: " + id);
        }

        private static EnemyMasterData CreateDrownedZombieMasterData()
        {
            EnemyMasterData result = new EnemyMasterData();
            result.Name = "Drowned Zombie";
            result.MaxLife = 30;
            result.Armor = 1;
            result.EvasionRating = 98;

            return result;
        }

        private static EnemyMasterData CreateAnimatedThornBushMasterData()
        {
            EnemyMasterData result = new EnemyMasterData();
            result.Name = "Animated Thornbush";
            result.MaxLife = 21;
            result.Armor = 3;
            result.EvasionRating = 98;

            return result;
        }        
    }
}