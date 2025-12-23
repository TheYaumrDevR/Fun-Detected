using System.Collections.Generic;
using UnityEngine;

using Org.Ethasia.Fundetected.Interactors.Presentation;
using Org.Ethasia.Fundetected.Ioadapters.Animation;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class RealEnemiesPresenter : AbstractAnimationPresenter, IEnemyPresenter
    {
        private IAnimatedCharactersInitializer enemyInitializer;

        public void PresentEnemies(List<EnemyRenderData> renderData)
        {
            foreach (EnemyRenderData enemyRenderData in renderData)
            {
                Animation2dGraphNodeProperties animation2dData = GetAnimation2dPropertiesGateway().LoadAnimation2dGraph(enemyRenderData.TypeId);

                GameObjectProxy gameObjectProxy = new GameObjectProxy.Builder()
                    .SetIndividualId(enemyRenderData.IndividualId)
                    .SetName("Enemy " + enemyRenderData.TypeId)
                    .SetPosX(enemyRenderData.PositionX / 10.0f)
                    .SetPosY(enemyRenderData.PositionY / 10.0f)
                    .SetScaleX(enemyRenderData.WidthX / 10.0f)
                    .SetScaleY(enemyRenderData.WidthY  / 10.0f)
                    .SetAnimationProperties(animation2dData)
                    .SetAnimationStateMachineAssignmentFunction(enemyRenderData.AnimationStateMachineAssignmentFunction)
                    .Build();

                GetEnemyInitializer().InitializeAnimatedCharacter(gameObjectProxy);
            }
        }

        public void PresentNothing()
        {
            GetEnemyInitializer().ClearAnimatedCharacters();
        }

        private IAnimatedCharactersInitializer GetEnemyInitializer()
        {
            if (null == enemyInitializer)
            {
                enemyInitializer = TechnicalFactory.GetInstance().GetEnemyInitializerInstance();
            }

            return enemyInitializer;
        }
    }
}