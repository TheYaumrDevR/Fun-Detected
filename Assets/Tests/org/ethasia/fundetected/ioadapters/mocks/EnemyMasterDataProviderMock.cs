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
            result.MaxLife = 30;
            result.Armor = 1;
            result.EvasionRating = 98;

            AbilityMasterData mockAbilityMasterData = new UnarmedSwingAbilityMasterData
            {
                AbilityName = "Mock Ability"
            };
            result.AbilityMasterData = mockAbilityMasterData;        

            return result;
        }    

        private EnemyMasterData CreateWolfMasterData()
        {
            EnemyMasterData result = new EnemyMasterData();
            result.Id = "Wolf";
            result.Name = "Wolf";
            result.MaxLife = 40;
            result.Armor = 1;
            result.EvasionRating = 98;
            result.MinimumSpawnLevel = 1;

            AbilityMasterData mockAbilityMasterData = new UnarmedSwingAbilityMasterData
            {
                AbilityName = "Mock Ability"
            };
            result.AbilityMasterData = mockAbilityMasterData;        

            return result;
        }      

        private EnemyMasterData CreateFireMageMasterData()
        {
            EnemyMasterData result = new EnemyMasterData();
            result.Id = "FireMage";
            result.Name = "Fire Mage";
            result.MaxLife = 25;
            result.Armor = 1;
            result.EvasionRating = 98;
            result.MinimumSpawnLevel = 3;

            AbilityMasterData mockAbilityMasterData = new UnarmedSwingAbilityMasterData
            {
                AbilityName = "Fire Ball"
            };
            result.AbilityMasterData = mockAbilityMasterData;        

            return result;
        }   

        private EnemyMasterData CreateAnimatedThornbushMasterData()
        {
            EnemyMasterData result = new EnemyMasterData();
            result.Id = "AnimatedThornbush";
            result.Name = "Animated Thornbush";
            result.MaxLife = 25;
            result.Armor = 2;
            result.EvasionRating = 98;
            result.MinimumSpawnLevel = 1;

            AbilityMasterData mockAbilityMasterData = new UnarmedSwingAbilityMasterData
            {
                AbilityName = "Mock Ability"
            };
            result.AbilityMasterData = mockAbilityMasterData;        

            return result;
        }                              
    }
}