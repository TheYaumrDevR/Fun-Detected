using UnityEngine;
using UnityEngine.InputSystem;

using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private PlayerSkillInteractor playerSkillInteractor;

        public PlayerInputHandler()
        {
            playerSkillInteractor = new PlayerSkillInteractor();
        }

        public void OnPrimaryAction(InputAction.CallbackContext callBackContext)
        {
            if (!callBackContext.started)
            {
                return;
            }

            playerSkillInteractor.ExecutePrimaryPlayerAction();
        }
    }
}