using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Interactors.Presentation;

namespace Org.Ethasia.Fundetected.Interactors
{
    public interface IEnemyMasterDataProvider
    {
        EnemyMasterData CreateEnemyMasterDataById(string id);
        EnemyMasterDataForRendering CreateEnemyMasterDataForRenderingById(string id);
    }
}