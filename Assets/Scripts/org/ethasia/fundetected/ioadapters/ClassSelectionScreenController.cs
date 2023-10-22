using UnityEngine;
using UnityEngine.SceneManagement;

using Org.Ethasia.Fundetected.Core;
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
            startGameInteractor.CreateCharacterAndStartGame(CharacterClasses.BATTLE_MAGE);
            SceneManager.LoadScene("Hill");
        }

        public void OnStrongmanSelected()
        {
            startGameInteractor.CreateCharacterAndStartGame(CharacterClasses.STRONGMAN);
            SceneManager.LoadScene("Hill");
        }

        public void OnDuelistSelected()
        {
            startGameInteractor.CreateCharacterAndStartGame(CharacterClasses.DUELIST);
            SceneManager.LoadScene("Hill");
        }

        public void OnZoomerSelected()
        {
            startGameInteractor.CreateCharacterAndStartGame(CharacterClasses.ZOOMER);
            SceneManager.LoadScene("Hill");
        }

        public void OnCuckSelected()
        {
            startGameInteractor.CreateCharacterAndStartGame(CharacterClasses.CUCK);
            SceneManager.LoadScene("Hill");
        }

        public void OnMagicianSelected()
        {
            startGameInteractor.CreateCharacterAndStartGame(CharacterClasses.MAGICIAN);
            SceneManager.LoadScene("Hill");
        }
    }
}
