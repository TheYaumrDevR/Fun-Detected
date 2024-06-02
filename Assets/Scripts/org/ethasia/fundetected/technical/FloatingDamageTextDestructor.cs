using UnityEngine;

namespace Org.Ethasia.Fundetected.Technical
{
    public class FloatingDamageTextDestructor : MonoBehaviour
    {
        public float DestructionTimeInSeconds;
        private float timeAlive;

        void Start()
        {
            timeAlive = 0.0f;
        }

        void Update()
        {
            timeAlive += Time.deltaTime;

            if (timeAlive >= DestructionTimeInSeconds)
            {
                Destroy(gameObject);
            }
        }
    }
}