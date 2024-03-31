using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class PlayerAnimationPresenter
    {
        private const string IDLE_ANIMATION_NAME = "idle";
        private const string WALK_ANIMATION_NAME = "walk";

        private static StateMachine playerAnimationStateMachine;

        public static void SetStateMachine(StateMachine value)
        {
            playerAnimationStateMachine = value;
        }

        public static void StartWalkAnimation()
        {
            playerAnimationStateMachine.ExecuteAction(WALK_ANIMATION_NAME);
        }

        public static void StartIdleAnimation()
        {
            playerAnimationStateMachine.ExecuteAction(IDLE_ANIMATION_NAME);
        }        
    }
}