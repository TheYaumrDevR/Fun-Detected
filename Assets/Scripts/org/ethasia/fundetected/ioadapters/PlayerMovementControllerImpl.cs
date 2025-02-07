using UnityEngine;

using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{

    public class PlayerMovementControllerImpl : MonoBehaviour, IPlayerMovementController, ICharacterTranslator
    {
        private static PlayerMovementControllerImpl instance;

        private Transform playerTransform;

        [SerializeField]
        private Transform cameraTransform;

        private SpriteRenderer spriteRenderer;        

        void Awake()
        {
            instance = this;
        }

        public void SetCharacterTransform(Transform transform)
        {
            playerTransform = transform;
        }

        public void SetSpriteRenderer(SpriteRenderer spriteRenderer)
        {
            this.spriteRenderer = spriteRenderer;
        }

        public void MoveUnitsLeft(int units)
        {
            if (units > 0)
            {
                playerTransform.Translate(-0.1f * units, 0, 0);
                cameraTransform.Translate(-0.1f * units, 0, 0);

                spriteRenderer.flipX = true;
            }
        }

        public void MoveUnitsRight(int units)
        {
            if (units > 0)
            {
                playerTransform.Translate(0.1f * units, 0, 0);
                cameraTransform.Translate(0.1f * units, 0, 0);

                spriteRenderer.flipX = false;
            }
        }

        public void MoveUnitsDown(int units)
        {
            if (units > 0)
            {
                playerTransform.Translate(0, -0.1f * units, 0);
                cameraTransform.Translate(0, -0.1f * units, 0);
            }
        }

        public void MoveUnitsUp(int units)
        {
            if (units > 0)
            {
                playerTransform.Translate(0, 0.1f * units, 0);
                cameraTransform.Translate(0, 0.1f * units, 0);
            }            
        }

        public void TeleportPlayerTo(int x, int y)
        {
            float playerPosX = x / 10.0f;
            float playerPosY = y / 10.0f + 0.4f;

            playerTransform.position = new Vector3(playerPosX, playerPosY, 0);
            cameraTransform.position = new Vector3(playerPosX, playerPosY, -1);
        }

        public static PlayerMovementControllerImpl GetInstance()
        {
            return instance;
        }
    }
}