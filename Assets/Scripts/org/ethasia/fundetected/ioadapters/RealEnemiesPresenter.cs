using System.Collections.Generic;
using UnityEngine;

using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters.Animation;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class RealEnemiesPresenter : AbstractAnimationPresenter, IEnemyPresenter
    {
        private IAnimatedCharactersRenderer enemyRenderer;

        public void PresentEnemies(List<EnemyRenderData> renderData)
        {
            enemyRenderer = TechnicalFactory.GetInstance().GetEnemyRendererInstance();

            foreach (EnemyRenderData enemyRenderData in renderData)
            {
                Animation2dGraphNodeProperties animation2dData = GetAnimation2dPropertiesGateway().LoadAnimation2dGraph(enemyRenderData.EnemyId);

                GameObjectProxy gameObjectProxy = new GameObjectProxy.Builder()
                    .SetName("Enemy " + enemyRenderData.EnemyId)
                    .SetPosX(enemyRenderData.PositionX / 10.0f)
                    .SetPosY(enemyRenderData.PositionY / 10.0f)
                    .SetScaleX(enemyRenderData.WidthX / 10.0f)
                    .SetScaleY(enemyRenderData.WidthY  / 10.0f)
                    .SetAnimationProperties(animation2dData)
                    .SetAnimationStateMachineAssignmentFunction(enemyRenderData.AnimationStateMachineAssignmentFunction)
                    .Build();

                enemyRenderer.RenderAnimatedCharacter(gameObjectProxy);
            }
        }
    }
}