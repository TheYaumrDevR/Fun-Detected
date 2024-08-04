namespace Org.Ethasia.Fundetected.Interactors
{
    public abstract class InternalInteractorsFactory
    {
        private static InternalInteractorsFactory instance;

        public static void SetInstance(InternalInteractorsFactory value)
        {
            instance = value;
        }

        public static InternalInteractorsFactory GetInstance()
        {
            return instance;
        }  

        public abstract IPlayerAnimationPresenter GetPlayerAnimationPresenterInstance();
    }
}