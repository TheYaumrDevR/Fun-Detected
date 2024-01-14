using System.Collections.Generic;
using UnityEngine;

using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class RealEnemiesPresenter : IEnemyPresenter
    {
        private IEnemiesRenderer enemiesRenderer;

        public void PresentEnemies(List<EnemyRenderData> renderData)
        {
            enemiesRenderer = TechnicalFactory.GetInstance().GetEnemiesRendererInstance();

            foreach (EnemyRenderData enemyRenderData in renderData)
            {
                GameObjectProxy gameObjectProxy = new GameObjectProxy.Builder()
                    .SetName("Enemy" + enemyRenderData.EnemyId)
                    .SetPosX(enemyRenderData.PositionX / 10.0f)
                    .SetPosY(enemyRenderData.PositionY / 10.0f)
                    .SetScaleX(enemyRenderData.WidthX / 10.0f)
                    .SetScaleY(enemyRenderData.WidthY  / 10.0f)
                    .Build();

                enemiesRenderer.RenderEnemy(gameObjectProxy);
            }
        }
    }
}