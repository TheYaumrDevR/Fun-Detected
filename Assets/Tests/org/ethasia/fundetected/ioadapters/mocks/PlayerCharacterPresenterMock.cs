using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{
    public class PlayerCharacterPresenterMock : IPlayerCharacterPresenter
    {
        private static bool playerWasPresented;

        public static bool PlayerWasPresented()
        {
            return playerWasPresented;
        }

        public void PresentPlayer()
        {
            playerWasPresented = true;
        }
    }
}