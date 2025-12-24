namespace Org.Ethasia.Fundetected.Interactors.Combat
{
    public interface IMasterDataScalingStrategy
    {
        EnemyMasterData ScaleMasterData(EnemyMasterData masterData, int targetLevel);
    }
}