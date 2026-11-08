using Org.Ethasia.Fundetected.Core.Combat;

namespace Org.Ethasia.Fundetected.Interactors.Mocks
{
    public class PlayerDeathInteractorMock : IPlayerDeathInteractor
    {
        public int LastLostExperiencePoints
        {
            get;
            private set;
        }

        public void NotifyPlayerDied()
        {
        }

        public void NotifyPlayerTombstoneLanded(int lostExperiencePoints)
        {
            LastLostExperiencePoints = lostExperiencePoints;
        }
    }
}