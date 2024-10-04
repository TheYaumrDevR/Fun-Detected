namespace Org.Ethasia.Fundetected.Core.Map
{
    public interface IPlayerDamageTakenInteractor
    {
        void NotifyPlayerOfDamageTaken(PlayerDamageContext context);

        public class PlayerDamageContext
        {
            public int DamageTaken;
            public int CurrentHealth;
            public int MaximumHealth;
        }
    }
}