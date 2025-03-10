namespace Org.Ethasia.Fundetected.Interactors
{
    public interface IMasterDataScalingStrategy
    {
        EnemyMasterData ScaleMasterData(EnemyMasterData masterData, int targetLevel);
    }
}