using UnityEngine;
using UnityEngine.InputSystem;

using Org.Ethasia.Fundetected.Core.Maths;
using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private static InternalInteractorsFactory internalInteractorsFactory;

        private PlayerSkillInteractor playerSkillInteractor;
        private EnvironmentInteractionInteractor environmentInteractionInteractor;
        private PlayerMovementInteractor playerMovementInteractor;

        private bool leftMoveButtonIsHeld;
        private bool rightMoveButtonIsHeld;

        public PlayerInputHandler()
        {
            playerSkillInteractor = new PlayerSkillInteractor();
            environmentInteractionInteractor = new EnvironmentInteractionInteractor();
            playerMovementInteractor = new PlayerMovementInteractor();
            internalInteractorsFactory = InternalInteractorsFactory.GetInstance();
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
                IPlayerAnimationPresenter playerAnimationPresenter = internalInteractorsFactory.GetPlayerAnimationPresenterInstance();
                playerAnimationPresenter.StartIdleAnimation();
            }
        }

        public void OnPrimaryAction(InputAction.CallbackContext callBackContext)
        {
            if (!callBackContext.started)
            {
                return;
            }

            Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, 0));

            int mousePositionX = FastMath.Floor(mouseWorldPosition.x * 10);
            int mousePositionY = FastMath.Floor(mouseWorldPosition.y * 10);

            if (!environmentInteractionInteractor.InteractWithEnvironment(mousePositionX, mousePositionY))
            {
                playerSkillInteractor.ExecutePrimaryPlayerAction();
            }
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