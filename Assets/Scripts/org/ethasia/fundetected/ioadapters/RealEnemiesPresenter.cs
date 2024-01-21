using System.Collections.Generic;
using UnityEngine;

using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters.Animation;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class RealEnemiesPresenter : IEnemyPresenter
    {
        private static Animation2dGraphPropertiesGateway animation2dPropertiesGateway;
        private IEnemiesRenderer enemiesRenderer;

        public void PresentEnemies(List<EnemyRenderData> renderData)
        {
            enemiesRenderer = TechnicalFactory.GetInstance().GetEnemiesRendererInstance();

            foreach (EnemyRenderData enemyRenderData in renderData)
            {
                Animation2dGraphNodeProperties animation2dData = GetAnimation2dPropertiesGateway().LoadAnimation2dGraph(enemyRenderData.EnemyId);

                GameObjectProxy gameObjectProxy = new GameObjectProxy.Builder()
                    .SetName("Enemy" + enemyRenderData.EnemyId)
                    .SetPosX(enemyRenderData.PositionX / 10.0f)
                    .SetPosY(enemyRenderData.PositionY / 10.0f)
                    .SetScaleX(enemyRenderData.WidthX / 10.0f)
                    .SetScaleY(enemyRenderData.WidthY  / 10.0f)
                    .SetAnimationProperties(animation2dData)
                    .Build();

                enemiesRenderer.RenderEnemy(gameObjectProxy);
            }
        }

        public Animation2dGraphPropertiesGateway GetAnimation2dPropertiesGateway()
        {
            if (null != animation2dPropertiesGateway)
            {
                return animation2dPropertiesGateway;
            }

            animation2dPropertiesGateway = new Animation2dGraphPropertiesGatewayCacheProxy();
            return animation2dPropertiesGateway;
        }
    }
}