using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Core.Map
{
    public class PlayerLevelingSystem
    {
        private const int MAX_LEVEL = 100;
        private const int DEATH_PENALTY_EXPERIENCE_PERCENT = 10;

        public int Level
        {
            get;
            private set;
        }

        public int ExperiencePoints
        {
            get;
            private set;
        }

        public PlayerLevelingSystem(int level, int experiencePoints)
        {
            Level = level;
            ExperiencePoints = experiencePoints;
        }

        public void AddExperiencePoints(int experiencePointsToAdd)
        {
            if (Level < MAX_LEVEL)
            {
                int oldLevel = Level;

                ExperiencePoints += experiencePointsToAdd;

                while (ExperiencePoints >= GetExperiencePointsForNextLevel() && Level < MAX_LEVEL)
                {
                    LevelUp();
                }

                NotifyLevelInformationChanged(Level > oldLevel);
            }
        }

        public int ApplyDeathPenalty()
        {
            int penalty = GetExperiencePointsForNextLevel() * DEATH_PENALTY_EXPERIENCE_PERCENT / 100;
            int lostExperiencePoints = penalty > ExperiencePoints ? ExperiencePoints : penalty;

            ExperiencePoints -= lostExperiencePoints;

            NotifyLevelInformationChanged(false);

            return lostExperiencePoints;
        }

        private void NotifyLevelInformationChanged(bool hasLeveledUp)
        {
            IPlayerLevelUpInteractor interactor = InteractorsFactoryForCore.GetInstance().GetPlayerLevelUpInteractorInstance();

            interactor.NotifyPlayerLevelInformationChanged(new IPlayerLevelUpInteractor.PlayerLevelContext
            {
                CurrentLevel = Level,
                CurrentExperience = ExperiencePoints,
                HasLeveledUp = hasLeveledUp
            });
        }

        private int GetExperiencePointsForNextLevel()
        {
            return Formulas.GetExperiencePointsForNextLevel(Level + 1);
        }

        private void LevelUp()
        {
            if (Level < MAX_LEVEL)
            {
                ExperiencePoints -= GetExperiencePointsForNextLevel();
                Level++;
            }
        }
    }
}