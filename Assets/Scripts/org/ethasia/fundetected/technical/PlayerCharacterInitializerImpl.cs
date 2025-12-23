using System.Collections.Generic;
using UnityEngine;

using Org.Ethasia.Fundetected.Core.Maths;
using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Interactors.Presentation;
using Org.Ethasia.Fundetected.Ioadapters;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class PlayerCharacterInitializerImpl : AnimatedCharactersInitializerImpl
    {
        private static PlayerCharacterInitializerImpl instance;
        private static List<GameObjectProxy> startupRenderQueue;
        private static InternalInteractorsFactory internalInteractorsFactory;

        public PlayerCharacterInitializerImpl()
        {
            internalInteractorsFactory = InternalInteractorsFactory.GetInstance();
        }

        public static PlayerCharacterInitializerImpl GetInstance()
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

        protected override void AssignAudioSource(string audioSourceId, AudioSource audioSource)
        {
            SoundPlayer.GetInstance().AddPermanentAudioSource(audioSourceId, audioSource);
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
            return 1;
        }        

        protected override void AssignAnimationStateMachine(StateMachine animationStateMachine, GameObjectProxy animatedCharacterProxy)
        {
            IPlayerAnimationPresenter playerAnimationPresenter = internalInteractorsFactory.GetPlayerAnimationPresenterInstance();
            playerAnimationPresenter.SetStateMachine(animationStateMachine);
        }

        protected override void AssignCharacterSpriteRendererAndTransform(SpriteRenderer spriteRenderer, Transform transform)
        {
            RealIoAdaptersFactoryForInteractors ioAdaptersFactory = new RealIoAdaptersFactoryForInteractors();

            ICharacterTranslator playerCharacterTranslator = ioAdaptersFactory.GetCharacterTranslatorInstance();

            playerCharacterTranslator.SetSpriteRenderer(spriteRenderer);
            playerCharacterTranslator.SetCharacterTransform(transform);
        }
    }
}