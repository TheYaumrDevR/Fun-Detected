using UnityEngine;
using UnityEngine.InputSystem;

using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private PlayerSkillInteractor playerSkillInteractor;
        private PlayerMovementInteractor playerMovementInteractor;

        private bool leftMoveButtonIsHeld;
        private bool rightMoveButtonIsHeld;

        public PlayerInputHandler()
        {
            playerSkillInteractor = new PlayerSkillInteractor();
            playerMovementInteractor = new PlayerMovementInteractor();
        }

        public void Update()
        {
            if (leftMoveButtonIsHeld && !rightMoveButtonIsHeld)
            {
                playerMovementInteractor.MovePlayerLeft(Time.deltaTime);
            }

            if (rightMoveButtonIsHeld && !leftMoveButtonIsHeld)
            {
                playerMovementInteractor.MovePlayerRight(Time.deltaTime);
            }

            if (PlayerIsStill() && !playerSkillInteractor.PlayerCharacterIsExecutingAction())
            {
                PlayerAnimationPresenter.StartIdleAnimation();
            }
        }

        public void OnPrimaryAction(InputAction.CallbackContext callBackContext)
        {
            if (!callBackContext.started)
            {
                return;
            }

            playerSkillInteractor.ExecutePrimaryPlayerAction();
        }

        public void OnMoveLeft(InputAction.CallbackContext callBackContext)
        {
            if (callBackContext.performed)
            {
                leftMoveButtonIsHeld = true;
            }
            else
            {
                leftMoveButtonIsHeld = false;
            }
        }

        public void OnMoveRight(InputAction.CallbackContext callBackContext)
        {
            if (callBackContext.performed)
            {
                rightMoveButtonIsHeld = true;
            }
            else
            {
                rightMoveButtonIsHeld = false;
            }
        }        

        private bool PlayerIsStill()
        {
            return leftMoveButtonIsHeld && rightMoveButtonIsHeld || !leftMoveButtonIsHeld && !rightMoveButtonIsHeld;
        }        
    }
}