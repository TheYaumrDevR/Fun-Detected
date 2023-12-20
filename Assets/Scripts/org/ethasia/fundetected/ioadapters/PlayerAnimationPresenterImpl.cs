using Org.Ethasia.Fundetected.Core.Maths;
using Org.Ethasia.Fundetected.Interactors;

using UnityEngine;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class PlayerAnimationPresenterImpl : MonoBehaviour, PlayerAnimationPresenter
    {
        private static PlayerAnimationPresenter instance;

        private const string IDLE_ANIMATION_NAME = "idle";
        private const string WALK_ANIMATION_NAME = "walk";

        [SerializeField]
        private Animator playerSpriteAnimator;

        private StateMachine playerAnimationStateMachine;

        void Awake()
        {
            instance = this;

            StateMachineNodeWithTransitions idleState = new StateMachineNodeWithTransitions.Builder()
                .SetStateEntryCommand(new ExecutePlayerIdleAnimationCommand(playerSpriteAnimator))
                .Build();

            StateMachineNodeWithTransitions walkState = new StateMachineNodeWithTransitions.Builder()
                .AddStateForAction(IDLE_ANIMATION_NAME, idleState)
                .SetStateEntryCommand(new ExecutePlayerWalkAnimationCommand(playerSpriteAnimator))
                .Build();                

            idleState.AddTransitionFunction(WALK_ANIMATION_NAME, walkState);

            playerAnimationStateMachine = new StateMachine(idleState);
        }

        public void StartWalkAnimation()
        {
            playerAnimationStateMachine.ExecuteAction(WALK_ANIMATION_NAME);
        }

        public void StartIdleAnimation()
        {
            playerAnimationStateMachine.ExecuteAction(IDLE_ANIMATION_NAME);
        }

        public static PlayerAnimationPresenter GetInstance()
        {
            return instance;
        }                
    }
}