using UnityEngine;

using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected
{
    /**
     * Fun Detected - The Blasting ARPG (BRPG)
     */
    public class FunDetected : MonoBehaviour
    {
        private StartGameInteractor startGameInteractor;

        public FunDetected()
        {
        }

        void Awake()
        {
            Dependencies.Inject();
        }

        void Start()
        {
            startGameInteractor = new StartGameInteractor();
            startGameInteractor.CreateCharacterAndStartGame(CharacterClasses.STRONGMAN);
        }

        void Update()
        {
            
        }
    } 
}