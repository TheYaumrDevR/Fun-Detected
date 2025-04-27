using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Core.Map
{
    public class PlayerLevelingSystem
    {
        private const int MAX_LEVEL = 100;

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
                ExperiencePoints += experiencePointsToAdd;

                while (ExperiencePoints >= GetExperiencePointsForNextLevel() && Level < MAX_LEVEL)
                {
                    LevelUp();
                }
            }
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