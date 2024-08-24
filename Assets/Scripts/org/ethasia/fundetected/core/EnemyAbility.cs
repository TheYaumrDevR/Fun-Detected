namespace Org.Ethasia.Fundetected.Core
{
    public interface EnemyAbility
    {
        void Tick(double actionTime);
        AsyncResponse<bool> Start(double attacksPerSecond);
    }
}