using UnityEngine;
using UnityEngine.SceneManagement;

using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class ClassSelectionScreenController : MonoBehaviour
    {     
        private StartGameInteractor startGameInteractor;

        public void Start()
        {
            startGameInteractor = new StartGameInteractor();
        }

        public void OnBattleMageSelected()
        {
            SceneManager.LoadScene("Hill");
            startGameInteractor.CreateCharacterAndStartGame(CharacterClasses.BATTLE_MAGE);
        }

        public void OnJockSelected()
        {
            SceneManager.LoadScene("Hill");
            startGameInteractor.CreateCharacterAndStartGame(CharacterClasses.JOCK);
        }

        public void OnDuelistSelected()
        {
            SceneManager.LoadScene("Hill");
            startGameInteractor.CreateCharacterAndStartGame(CharacterClasses.DUELIST);
        }

        public void OnZoomerSelected()
        {
            SceneManager.LoadScene("Hill");
            startGameInteractor.CreateCharacterAndStartGame(CharacterClasses.ZOOMER);
        }

        public void OnCuckSelected()
        {
            SceneManager.LoadScene("Hill");
            startGameInteractor.CreateCharacterAndStartGame(CharacterClasses.CUCK);
        }

        public void OnMagicianSelected()
        {
            SceneManager.LoadScene("Hill");
            startGameInteractor.CreateCharacterAndStartGame(CharacterClasses.MAGICIAN);
        }
    }
}
