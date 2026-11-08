using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Map;

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
            Area.ActiveArea.AddTombstoneAtPlayerPosition();            
        }

        public void NotifyPlayerTombstoneLanded(int lostExperiencePoints)
        {
            LastLostExperiencePoints = lostExperiencePoints;
        }

        public bool IsPlayerDead()
        {
            return false;
        }
    }
}