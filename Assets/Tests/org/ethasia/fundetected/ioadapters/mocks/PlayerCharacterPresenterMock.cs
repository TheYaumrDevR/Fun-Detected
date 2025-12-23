using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors.Presentation;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{
    public class PlayerCharacterPresenterMock : IPlayerCharacterPresenter
    {
        private static bool playerWasPresented;

        public static bool PlayerWasPresented()
        {
            return playerWasPresented;
        }

        public void PresentPlayer(string playerName, Position playerPosition)
        {
            playerWasPresented = true;
        }

        public string GetPlayerCharacterIdPrefix()
        {
            return "PlayerCharacter ";
        }
    }
}