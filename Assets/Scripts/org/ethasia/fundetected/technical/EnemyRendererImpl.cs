using System.Collections.Generic;
using UnityEngine;

using Org.Ethasia.Fundetected.Ioadapters.Technical;
using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Technical
{
    public class EnemyRendererImpl : AnimatedCharactersRendererImpl
    {
        private static EnemyRendererImpl instance;
        private static List<GameObjectProxy> startupRenderQueue;

        public static EnemyRendererImpl GetInstance()
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

        protected override void AssignAnimationStateMachine(StateMachine animationStateMachine)
        {

        }

        protected override void AssignCharacterSpriteRendererAndTransform(SpriteRenderer spriteRenderer, Transform transform)
        {

        }
    }
}