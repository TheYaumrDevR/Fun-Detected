namespace Org.Ethasia.Fundetected.Core.Map
{
    public abstract class InteractorsFactoryForCore
    {
        private static InteractorsFactoryForCore instance;

        public static void SetInstance(InteractorsFactoryForCore value)
        {
            instance = value;
        }

        public static InteractorsFactoryForCore GetInstance()
        {
            return instance;
        } 

        public abstract IPlayerDamageTakenInteractor GetPlayerDamageTakenInteractorInstance();
    }
}