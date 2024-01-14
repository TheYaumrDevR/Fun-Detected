using UnityEngine;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class EnemiesRendererDelayedInitializationProxy : IEnemiesRenderer
    {
        private EnemiesRendererImpl proxiedRenderer;

        public EnemiesRendererDelayedInitializationProxy(EnemiesRendererImpl proxiedRenderer)
        {
            this.proxiedRenderer = proxiedRenderer;
        }

        public void RenderEnemy(GameObjectProxy enemy)
        {
            if (null != proxiedRenderer)
            {
                proxiedRenderer.RenderEnemy(enemy);
            }
            else
            {
                EnemiesRendererImpl.AddGameObjectToStartupRenderQueue(enemy);
            }
        }
    }
}