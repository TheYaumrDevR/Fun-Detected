using Org.Ethasia.Fundetected.Core.Combat;

namespace Org.Ethasia.Fundetected.Core.Map
{
    public class TombstoneLandedDeathNotificationObserver : IPhysicsBodyEventObserver
    {
        private int lostExperiencePoints;

        public TombstoneLandedDeathNotificationObserver(int lostExperiencePoints)
        {
            this.lostExperiencePoints = lostExperiencePoints;
        }

        public void OnEventTriggered()
        {
            IPlayerDeathInteractor playerDeathInteractor = InteractorsFactoryForCore.GetInstance().GetPlayerDeathInteractorInstance();
            playerDeathInteractor.NotifyPlayerDied(lostExperiencePoints);
        }
    }
}