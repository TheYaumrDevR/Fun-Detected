using System.Collections.Generic;
using UnityEngine;

using Org.Ethasia.Fundetected.Ioadapters.Technical;
using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Technical
{
    public class EnemyInitializerImpl : AnimatedCharactersInitializerImpl
    {
        private static EnemyInitializerImpl instance;
        private static List<GameObjectProxy> startupRenderQueue;

        public static EnemyInitializerImpl GetInstance()
        {
            return instance;
        }          

        public static void AddGameObjectToStartupRenderQueue(GameObjectProxy value)
        {
            if (null == startupRenderQueue)
            {
                startupRenderQueue = new List<GameObjectProxy>();
            }

            startupRenderQueue.Add(value);
        }       

        protected override void AssignInstance()
        {
            instance = this;
        } 

        protected override List<GameObjectProxy> GetStartupRenderQueue()
        {
            return startupRenderQueue;
        }

        protected override int GetSortingOrderOfRendererInLayer()
        {
            return 0;
        }

        protected override void AssignAnimationStateMachine(StateMachine animationStateMachine, GameObjectProxy animatedCharacterProxy)
        {
            animatedCharacterProxy.AnimationStateMachineAssignmentFunction.AssignActionStateMachineToEnemy(animationStateMachine);
        }

        protected override void AssignCharacterSpriteRendererAndTransform(SpriteRenderer spriteRenderer, Transform transform)
        {

        }
    }
}