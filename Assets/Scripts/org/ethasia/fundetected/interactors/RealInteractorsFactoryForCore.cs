using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class RealInteractorsFactoryForCore : InteractorsFactoryForCore
    {
        private IPlayerDamageTakenInteractor playerDamageTakenInteractor;

        public override IPlayerDamageTakenInteractor GetPlayerDamageTakenInteractorInstance()
        {
            if (null == playerDamageTakenInteractor)
            {
                playerDamageTakenInteractor = new PlayerDamageTakenInteractor();
            }

            return playerDamageTakenInteractor;
        }
    }
}