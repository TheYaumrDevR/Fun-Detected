using System.Collections.Generic;
using UnityEngine;

using Org.Ethasia.Fundetected.Ioadapters;
using Org.Ethasia.Fundetected.Ioadapters.Technical;
using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Technical
{
    public class PlayerCharacterRendererImpl : AnimatedCharactersRendererImpl
    {
        private static PlayerCharacterRendererImpl instance;
        private static List<GameObjectProxy> startupRenderQueue;
        private static InternalInteractorsFactory internalInteractorsFactory;

        public PlayerCharacterRendererImpl()
        {
            internalInteractorsFactory = InternalInteractorsFactory.GetInstance();
        }

        public static PlayerCharacterRendererImpl GetInstance()
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