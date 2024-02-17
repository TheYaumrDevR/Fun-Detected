using System.Collections.Generic;
using UnityEngine;

using Org.Ethasia.Fundetected.Core.Maths;
using Org.Ethasia.Fundetected.Ioadapters.Technical;
using Org.Ethasia.Fundetected.Technical.Animation;

namespace Org.Ethasia.Fundetected.Technical
{
    public class EnemiesRendererImpl : MonoBehaviour, IEnemiesRenderer
    {
        private static EnemiesRendererImpl instance;
        private static List<GameObjectProxy> startupRenderQueue;

        public static EnemiesRendererImpl GetInstance()
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

        void Awake()
        {
            instance = this;
        }        

        void Start()
        {
            foreach (GameObjectProxy enemyObject in startupRenderQueue)
            {
                RenderEnemy(enemyObject);
            }      

            startupRenderQueue.Clear();      
        }  

        public void RenderEnemy(GameObjectProxy enemyProxy)
        {
            GameObject enemy = new GameObject(enemyProxy.Name);
            enemy.transform.position = new Vector3(enemyProxy.PosX, enemyProxy.PosY, 0f);
            enemy.transform.localScale = new Vector3(enemyProxy.ScaleX, enemyProxy.ScaleY, 0f);

            SpriteRenderer spriteRenderer = enemy.AddComponent<SpriteRenderer>();
            spriteRenderer.sortingLayerName = "Sprites";

            Sprite2dAnimatorBehavior animatorBehavior = enemy.AddComponent<Sprite2dAnimatorBehavior>();

            StateMachine animationStateMachine = Animation2dPropertiesToSprite2dAnimationConverter.ConvertAnimation2dGraphNodePropertiesToStateMachine(enemyProxy.Animation2DGraphNodeProperties, spriteRenderer, animatorBehavior);

            enemy.transform.SetParent(this.transform);
        }    
    }
}