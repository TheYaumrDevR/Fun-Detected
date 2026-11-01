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

        public void NotifyPlayerDied(int lostExperiencePoints)
        {
            LastLostExperiencePoints = lostExperiencePoints;
        }
    }
}