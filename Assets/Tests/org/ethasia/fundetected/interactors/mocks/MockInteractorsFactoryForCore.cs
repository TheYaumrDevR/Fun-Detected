using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors.Mocks
{
    public class MockInteractorsFactoryForCore : InteractorsFactoryForCore
    {
        public override IPlayerDamageTakenInteractor GetPlayerDamageTakenInteractorInstance()
        {
            return new PlayerDamageTakenInteractorMock();
        }

        public override IPortalTransitionInteractor GetPortalTransitionInteractor()
        {
            return null;
        }
    }
}