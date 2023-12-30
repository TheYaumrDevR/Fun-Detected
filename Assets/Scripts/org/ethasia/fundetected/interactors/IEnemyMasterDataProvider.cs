using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected.Interactors
{
    public interface IEnemyMasterDataProvider
    {
        EnemyMasterData CreateEnemyMasterDataById(string id);
    }
}