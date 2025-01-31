using System.Collections.Generic;
using UnityEngine;

using Org.Ethasia.Fundetected.Core.Maths;
using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters.Technical;
using Org.Ethasia.Fundetected.Technical.Animation;

namespace Org.Ethasia.Fundetected.Technical
{
    public abstract class AnimatedCharactersInitializerImpl : MonoBehaviour, IAnimatedCharactersInitializer
    {
        void Awake()
        {
            AssignInstance();
        }        

        void Start()
        {
            List<GameObjectProxy> startupRenderQueue = GetStartupRenderQueue();

            if (null != startupRenderQueue)
            {
                foreach (GameObjectProxy animatedCharacter in startupRenderQueue)
                {
                    InitializeAnimatedCharacter(animatedCharacter);
                }      

                startupRenderQueue.Clear();    
            }
        }  

        public void InitializeAnimatedCharacter(GameObjectProxy animatedCharacterProxy)
        {
            CharacterWithSpriteFactory.CharacterWithSpriteFactoryProduct createdCharacterEngineObjects = CharacterWithSpriteFactory.CreateCharacterWithSprite(animatedCharacterProxy, GetSortingOrderOfRendererInLayer(), this.transform);

            Animation2dPropertiesToSprite2dAnimationConverter.StateMachineConversionContext stateMachineConversionContext = new Animation2dPropertiesToSprite2dAnimationConverter.StateMachineConversionContext();
            stateMachineConversionContext.ToConvert = animatedCharacterProxy.Animation2DGraphNodeProperties;
            stateMachineConversionContext.SpriteRenderer = createdCharacterEngineObjects.CharacterSpriteRenderer;
            stateMachineConversionContext.Sprite2dAnimatorContainer = createdCharacterEngineObjects.CharacterAnimatorBehavior;
            stateMachineConversionContext.AnimatedObjectId = animatedCharacterProxy.IndividualId;

            StateMachine animationStateMachine = Animation2dPropertiesToSprite2dAnimationConverter.ConvertAnimation2dGraphNodePropertiesToStateMachine(stateMachineConversionContext);
                        
            AssignAnimationStateMachine(animationStateMachine, animatedCharacterProxy);
            AssignCharacterSpriteRendererAndTransform(createdCharacterEngineObjects.CharacterSpriteRenderer, createdCharacterEngineObjects.CharacterGameObject.transform);
            AssignAudioSource(animatedCharacterProxy.IndividualId, createdCharacterEngineObjects.CharacterAudioSource);
        }  

        public void ClearAnimatedCharacters()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }            
        }

        protected void AssignAudioSource(string audioSourceId, AudioSource audioSource)
        {
            SoundPlayer.GetInstance().AddAudioSource(audioSourceId, audioSource);
        }

        protected abstract void AssignInstance();

        protected abstract List<GameObjectProxy> GetStartupRenderQueue();

        protected abstract int GetSortingOrderOfRendererInLayer();

        protected abstract void AssignAnimationStateMachine(StateMachine animationStateMachine, GameObjectProxy animatedCharacterProxy);

        protected abstract void AssignCharacterSpriteRendererAndTransform(SpriteRenderer spriteRenderer, Transform transform);       
    }
}