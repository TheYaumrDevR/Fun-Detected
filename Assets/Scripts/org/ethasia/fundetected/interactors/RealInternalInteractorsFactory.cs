namespace Org.Ethasia.Fundetected.Interactors
{
    public class RealInternalInteractorsFactory : InternalInteractorsFactory
    {
        private static PlayerAnimationPresenter playerAnimationPresenterInstance;

        public override IPlayerAnimationPresenter GetPlayerAnimationPresenterInstance()
        {
            if (null == playerAnimationPresenterInstance)
            {
                playerAnimationPresenterInstance = new PlayerAnimationPresenter();
            }

            return playerAnimationPresenterInstance;
        }
    }
}