using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{
    public class EnemyMasterDataProviderMock : IEnemyMasterDataProvider
    {
        public EnemyMasterData CreateEnemyMasterDataById(string id)
        {
            EnemyMasterData result = new EnemyMasterData();
            result.Id = id;
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

        public EnemyMasterDataForRendering CreateEnemyMasterDataForRenderingById(string id)
        {
            EnemyMasterDataForRendering result = new EnemyMasterDataForRendering();
            result.DistanceToLeftRenderEdge = 7;
            result.DistanceToRightRenderEdge = 7;
            result.DistanceToBottomRenderEdge = 7;
            result.DistanceToTopRenderEdge = 7;         

            return result;
        }        
    }
}