using Org.Ethasia.Fundetected.Ioadapters.Technical;

using UnityEngine;

namespace Org.Ethasia.Fundetected.Technical
{
    public class HitboxDebugShapeRendererImpl : MonoBehaviour, IHitboxDebugShapeRenderer
    {
        private static HitboxDebugShapeRendererImpl instance;
        public GameObject hitboxDebugShapePrefab;

        public static HitboxDebugShapeRendererImpl GetInstance()
        {
            return instance;
        }

        void Awake()
        {
            instance = this;
        }

        public void RenderHitboxDebugShape(float posX, float posY)
        {
            Vector3 position = new Vector3(posX, posY, 0.0f);
            GameObject.Instantiate(hitboxDebugShapePrefab, position, Quaternion.identity);
        }        
    }
}