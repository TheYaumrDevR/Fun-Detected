using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{
    public class EnemyMasterDataProviderMock : IEnemyMasterDataProvider
    {
        public EnemyMasterData CreateEnemyMasterDataById(string id)
        {
            EnemyMasterData result = new EnemyMasterData();
            result.Name = "Drowned Zombie";
            result.MaxLife = 30;
            result.Armor = 1;
            result.EvasionRating = 98;

            return result;
        }
    }
}