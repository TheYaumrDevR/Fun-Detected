using UnityEngine;

using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{

    public class PlayerMovementControllerImpl : MonoBehaviour, IPlayerMovementController
    {
        private static IPlayerMovementController instance;

        [SerializeField]
        private Transform playerTransform;

        [SerializeField]
        private Transform cameraTransform;

        [SerializeField]
        private SpriteRenderer spriteRenderer;        

        void Awake()
        {
            instance = this;
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

        public static IPlayerMovementController GetInstance()
        {
            return instance;
        }
    }
}