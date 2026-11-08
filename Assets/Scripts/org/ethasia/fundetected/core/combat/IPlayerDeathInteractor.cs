namespace Org.Ethasia.Fundetected.Core.Combat
{
    public interface IPlayerDeathInteractor
    {
        void NotifyPlayerDied(int lostExperiencePoints);
        void NotifyPlayerTombstoneLanded(int lostExperiencePoints);
        bool IsPlayerDead();
    }
}