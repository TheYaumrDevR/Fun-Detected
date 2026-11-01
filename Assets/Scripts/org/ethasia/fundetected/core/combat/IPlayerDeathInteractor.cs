namespace Org.Ethasia.Fundetected.Core.Combat
{
    public interface IPlayerDeathInteractor
    {
        void NotifyPlayerDied(int lostExperiencePoints);
    }
}