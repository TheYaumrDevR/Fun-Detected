using System;
using UnityEngine;
using UnityEngine.InputSystem;

using Org.Ethasia.Fundetected.Core.Maths;
using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Interactors.Combat;
using Org.Ethasia.Fundetected.Interactors.Map;
using Org.Ethasia.Fundetected.Interactors.Presentation;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class PlayerInputHandler : MonoBehaviour, IPlayerInputOnOffSwitch
    {
        private static PlayerInputHandler instance;
        private static InternalInteractorsFactory internalInteractorsFactory;

        private PlayerSkillInteractor playerSkillInteractor;
        private EnvironmentInteractionInteractor environmentInteractionInteractor;
        private PlayerMovementInteractor playerMovementInteractor;
        private PlayerRespawnInteractor playerRespawnInteractor;
        private PlayerDeathInteractor playerDeathInteractor;

        private bool leftMoveButtonIsHeld;
        private bool rightMoveButtonIsHeld;

        private bool isInputEnabled;
        private bool isPlayerNotControllable;

        public static PlayerInputHandler GetInstance()
        {
            return instance;
        }

        public PlayerInputHandler()
        {
            playerSkillInteractor = new PlayerSkillInteractor();
            environmentInteractionInteractor = new EnvironmentInteractionInteractor();
            playerMovementInteractor = new PlayerMovementInteractor();
            playerRespawnInteractor = new PlayerRespawnInteractor();
            playerDeathInteractor = new PlayerDeathInteractor();
            internalInteractorsFactory = InternalInteractorsFactory.GetInstance();
            isInputEnabled = true;
        }

        public void MakePlayerNotControllable()
        {
            isPlayerNotControllable = true;
        }

        public void MakePlayerControllable()
        {
            isPlayerNotControllable = false;
        }

        public void DisableInput()
        {
            isInputEnabled = false;
        }

        public void EnableInput()
        {
            isInputEnabled = true;
        }

        void Awake()
        {
            instance = this;
        }

        public void Update()
        {
            if (isInputEnabled && !isPlayerNotControllable)
            {
                if (leftMoveButtonIsHeld && !rightMoveButtonIsHeld)
                {
                    playerMovementInteractor.MovePlayerLeft(Time.deltaTime);
                }

                if (rightMoveButtonIsHeld && !leftMoveButtonIsHeld)
                {
                    playerMovementInteractor.MovePlayerRight(Time.deltaTime);
                }
            }

            if (ShouldPlayIdleAnimation())
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

            if (isInputEnabled && !isPlayerNotControllable)
            {
                Tuple<int, int> mousePosition = GetMousePositionInWorldCoordinates();

                if (!environmentInteractionInteractor.InteractWithEnvironment(mousePosition.Item1, mousePosition.Item2))
                {
                    playerSkillInteractor.ExecutePrimaryPlayerAction();
                }
            }
        }

        public void OnSecondaryAction(InputAction.CallbackContext callBackContext)
        {
            if (!callBackContext.started)
            {
                return;
            }

            if (isInputEnabled && !isPlayerNotControllable)
            {
                Tuple<int, int> mousePosition = GetMousePositionInWorldCoordinates();
                environmentInteractionInteractor.SecondaryInteractWithEnvironment(mousePosition.Item1, mousePosition.Item2);
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

        public void OnAbort(InputAction.CallbackContext callBackContext)
        {
            if (callBackContext.performed)
            {
                IGuiWindowsController guiWindowsController = TechnicalFactory.GetInstance().GetGuiWindowsControllerInstance();
                
                if (guiWindowsController.IsDeathOverlayVisible() && playerRespawnInteractor.IsPlayerDead())
                {
                    RespawnAfterDeath(guiWindowsController);
                    return;
                }
                
                guiWindowsController.CloseCurrentlyOpenWindow();
                EnableInput();
            }
        }   

        public void OnToggleInventory(InputAction.CallbackContext callBackContext)
        {
            if (callBackContext.performed)
            {
                IGuiWindowsController guiWindowsController = TechnicalFactory.GetInstance().GetGuiWindowsControllerInstance();
                guiWindowsController.ToggleInventoryWindow();
            }
        }

        private bool ShouldPlayIdleAnimation()
        {
            if (playerDeathInteractor.IsPlayerDead())
            {
                return false;
            }

            bool isIdleByInactivity = PlayerIsStill() && !playerSkillInteractor.PlayerCharacterIsExecutingAction();
            bool isIdleByDisabledControl = !isInputEnabled || isPlayerNotControllable;

            return isIdleByInactivity || isIdleByDisabledControl;
        }

        private bool PlayerIsStill()
        {
            return leftMoveButtonIsHeld && rightMoveButtonIsHeld || !leftMoveButtonIsHeld && !rightMoveButtonIsHeld;
        }   

        private void RespawnAfterDeath(IGuiWindowsController guiWindowsController)
        {
            guiWindowsController.HideDeathOverlay();
            playerRespawnInteractor.RespawnInNearestTown();

            MakePlayerControllable();
            EnableInput();
        }   

        private Tuple<int, int> GetMousePositionInWorldCoordinates()
        {
            Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, 0));

            int mousePositionX = FastMath.Floor(mouseWorldPosition.x * 10);
            int mousePositionY = FastMath.Floor(mouseWorldPosition.y * 10);

            return new Tuple<int, int>(mousePositionX, mousePositionY);
        }  
    }
}