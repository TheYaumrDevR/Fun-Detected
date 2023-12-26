using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class EnemyMasterDataProvider : IEnemyMasterDataProvider
    {
        public EnemyMasterData CreateDrownedZombieMasterData()
        {
            EnemyMasterData result = new EnemyMasterData();
            result.Name = "Drowned Zombie";
            result.MaxLife = 30;
            result.Armor = 1;
            result.EvasionRating = 98;

            return result;
        }

        public EnemyMasterData CreateAnimatedThornBushMasterData()
        {
            EnemyMasterData result = new EnemyMasterData();
            result.Name = "Animated Thornbush";
            result.MaxLife = 21;
            result.Armor = 4;
            result.EvasionRating = 98;

            return result;
        }        
    }
}