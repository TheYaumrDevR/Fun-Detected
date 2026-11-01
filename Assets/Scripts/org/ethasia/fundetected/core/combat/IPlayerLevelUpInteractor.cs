namespace Org.Ethasia.Fundetected.Core.Combat
{
    public interface IPlayerLevelUpInteractor
    {
        void NotifyPlayerLevelInformationChanged(PlayerLevelContext context);

        public class PlayerLevelContext
        {
            public int CurrentLevel;
            public int CurrentExperience;
            public bool HasLeveledUp;
        }
    }
}