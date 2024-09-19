using System.Collections.Generic;
using UnityEngine;

using Org.Ethasia.Fundetected.Core.Maths;
using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters.Technical;
using Org.Ethasia.Fundetected.Technical.Animation;

namespace Org.Ethasia.Fundetected.Technical
{
    public abstract class AnimatedCharactersRendererImpl : MonoBehaviour, IAnimatedCharactersRenderer
    {
        void Awake()
        {
            AssignInstance();
        }        

        void Start()
        {
            List<GameObjectProxy> startupRenderQueue = GetStartupRenderQueue();

            foreach (GameObjectProxy animatedCharacter in startupRenderQueue)
            {
                RenderAnimatedCharacter(animatedCharacter);
            }      

            startupRenderQueue.Clear();      
        }  

        public void RenderAnimatedCharacter(GameObjectProxy animatedCharacterProxy)
        {
            CharacterWithSpriteFactory.CharacterWithSpriteFactoryProduct createdCharacterEngineObjects = CharacterWithSpriteFactory.CreateCharacterWithSprite(animatedCharacterProxy, GetSortingOrderOfRendererInLayer(), this.transform);

            StateMachine animationStateMachine = Animation2dPropertiesToSprite2dAnimationConverter.ConvertAnimation2dGraphNodePropertiesToStateMachine(animatedCharacterProxy.Animation2DGraphNodeProperties, createdCharacterEngineObjects.CharacterSpriteRenderer, createdCharacterEngineObjects.CharacterAnimatorBehavior);
                        
            AssignAnimationStateMachine(animationStateMachine, animatedCharacterProxy);
            AssignCharacterSpriteRendererAndTransform(createdCharacterEngineObjects.CharacterSpriteRenderer, createdCharacterEngineObjects.CharacterGameObject.transform);
        }  

        protected abstract void AssignInstance();

        protected abstract List<GameObjectProxy> GetStartupRenderQueue();

        protected abstract int GetSortingOrderOfRendererInLayer();

        protected abstract void AssignAnimationStateMachine(StateMachine animationStateMachine, GameObjectProxy animatedCharacterProxy);

        protected abstract void AssignCharacterSpriteRendererAndTransform(SpriteRenderer spriteRenderer, Transform transform);       
    }
}