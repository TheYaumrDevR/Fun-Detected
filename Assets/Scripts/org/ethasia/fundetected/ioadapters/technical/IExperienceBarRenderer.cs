namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public interface IExperienceBarRenderer
    {
        void FillExperienceBarBasedOnExperiencePercentage(float experiencePercentage);
        void UpdateLevelText(int currentLevel);
    }
}