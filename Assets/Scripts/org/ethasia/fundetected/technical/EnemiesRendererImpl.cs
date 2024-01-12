using UnityEngine;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class EnemiesRendererImpl : MonoBehaviour, IEnemiesRenderer
    {
        private static EnemiesRendererImpl instance;

        void Awake()
        {
            instance = this;
        }        

        public static EnemiesRendererImpl GetInstance()
        {
            return instance;
        }    

        public void RenderEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(this.transform);
        }    
    }
}