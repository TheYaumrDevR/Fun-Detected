namespace Org.Ethasia.Fundetected.Interactors
{
    public interface IResourceBarPresenter
    {
        void PresentHealthBarBasedOnCurrentAndMaximumHealth(int currentHealth, int maximumHealth);
        void PresentManaBarBasedOnCurrentAndMaximumMana(int currentMana, int maximumMana);
    }
}