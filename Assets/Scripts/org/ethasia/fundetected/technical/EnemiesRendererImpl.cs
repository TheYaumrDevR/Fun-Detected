using System.Collections.Generic;
using UnityEngine;

using Org.Ethasia.Fundetected.Core.Maths;
using Org.Ethasia.Fundetected.Ioadapters.Technical;
using Org.Ethasia.Fundetected.Technical.Animation;

namespace Org.Ethasia.Fundetected.Technical
{
    public class AnimatedCharactersRendererImpl : MonoBehaviour, IAnimatedCharactersRenderer
    {
        private static AnimatedCharactersRendererImpl instance;
        private static List<GameObjectProxy> startupRenderQueue;

        public static AnimatedCharactersRendererImpl GetInstance()
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
            foreach (GameObjectProxy animatedCharacter in startupRenderQueue)
            {
                RenderAnimatedCharacter(animatedCharacter);
            }      

            startupRenderQueue.Clear();      
        }  

        public void RenderAnimatedCharacter(GameObjectProxy animatedCharacterProxy)
        {
            GameObject animatedCharacter = new GameObject(animatedCharacterProxy.Name);
            animatedCharacter.transform.position = new Vector3(animatedCharacterProxy.PosX, animatedCharacterProxy.PosY, 0f);
            animatedCharacter.transform.localScale = new Vector3(animatedCharacterProxy.ScaleX, animatedCharacterProxy.ScaleY, 0f);

            SpriteRenderer spriteRenderer = animatedCharacter.AddComponent<SpriteRenderer>();
            spriteRenderer.sortingLayerName = "Sprites";

            Sprite2dAnimatorBehavior animatorBehavior = animatedCharacter.AddComponent<Sprite2dAnimatorBehavior>();

            StateMachine animationStateMachine = Animation2dPropertiesToSprite2dAnimationConverter.ConvertAnimation2dGraphNodePropertiesToStateMachine(animatedCharacterProxy.Animation2DGraphNodeProperties, spriteRenderer, animatorBehavior);

            animatedCharacter.transform.SetParent(this.transform);
        }    
    }
}