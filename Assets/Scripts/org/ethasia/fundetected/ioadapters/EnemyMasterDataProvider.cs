using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class EnemyMasterDataProvider : IEnemyMasterDataProvider
    {
        public EnemyMasterData CreateDrownedZombieMasterData()
        {
            EnemyMasterData result = new EnemyMasterData();
            result.Name = "";
            result.MaxLife = 30;
            result.Armor = 1;

            return result;
        }
    }
}