using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors.Mocks
{
    public class MockInteractorsFactoryForCore : InteractorsFactoryForCore
    {
        private DropItemInteractorMock dropItemInteractorMockInstance;

        public override IPlayerDamageTakenInteractor GetPlayerDamageTakenInteractorInstance()
        {
            return new PlayerDamageTakenInteractorMock();
        }

        public override IPortalTransitionInteractor GetPortalTransitionInteractor()
        {
            return null;
        }

        public override IDropItemInteractor GetDropItemInteractorInstance()
        {
            if (dropItemInteractorMockInstance == null)
            {
                dropItemInteractorMockInstance = new DropItemInteractorMock();
            }

            return dropItemInteractorMockInstance;
        }

        public override IPlayerLevelUpInteractor GetPlayerLevelUpInteractorInstance()
        {
            return new PlayerLevelUpInteractorMock();
        }

        public override IPlayerDeathInteractor GetPlayerDeathInteractorInstance()
        {
            return new PlayerDeathInteractorMock();
        }
    }
}