namespace Org.Ethasia.Fundetected.Core.Combat
{
    public interface EnemyAbility
    {
        void Tick(double actionTime);
        AsyncResponse<bool> Start(double attacksPerSecond);
    }
}