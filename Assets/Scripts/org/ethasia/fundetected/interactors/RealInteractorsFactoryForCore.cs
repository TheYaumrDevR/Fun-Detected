using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors.Combat;
using Org.Ethasia.Fundetected.Interactors.Map;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class RealInteractorsFactoryForCore : InteractorsFactoryForCore
    {
        private IPlayerDamageTakenInteractor playerDamageTakenInteractor;
        private IPortalTransitionInteractor portalTransitionInteractor;
        private IDropItemInteractor dropItemInteractor;

        public override IPlayerDamageTakenInteractor GetPlayerDamageTakenInteractorInstance()
        {
            if (null == playerDamageTakenInteractor)
            {
                playerDamageTakenInteractor = new PlayerDamageTakenInteractor();
            }

            return playerDamageTakenInteractor;
        }

        public override IPortalTransitionInteractor GetPortalTransitionInteractor()
        {
            if (null == portalTransitionInteractor)
            {
                portalTransitionInteractor = new PortalTransitionInteractor();
            }

            return portalTransitionInteractor;
        }

        public override IDropItemInteractor GetDropItemInteractorInstance()
        {
            if (null == dropItemInteractor)
            {
                dropItemInteractor = new DropItemInteractor();
            }

            return dropItemInteractor;
        }
    }
}