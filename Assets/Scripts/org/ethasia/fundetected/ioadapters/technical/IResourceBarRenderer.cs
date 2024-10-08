namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public interface IResourceBarRenderer
    {
        void FillHealthBarBasedOnHealthPercentage(float healthPercentage);
        void UpdateHealthText(int currentHealth, int maxHealth);

        void FillManaBarBasedOnManaPercentage(float manaPercentage);
        void UpdateManaText(int currentMana, int maxMana);
    }
}