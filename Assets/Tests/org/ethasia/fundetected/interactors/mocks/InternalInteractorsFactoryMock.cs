using Org.Ethasia.Fundetected.Interactors.Presentation;

namespace Org.Ethasia.Fundetected.Interactors.Mocks
{
    public class InternalInteractorsFactoryMock : InternalInteractorsFactory
    {
        public override IPlayerAnimationPresenter GetPlayerAnimationPresenterInstance()
        {
            return new PlayerAnimationPresenterMock();
        }
    }
}