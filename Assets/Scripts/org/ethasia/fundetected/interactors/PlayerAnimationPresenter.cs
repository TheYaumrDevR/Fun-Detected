using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class PlayerAnimationPresenter
    {
        private const string IDLE_ANIMATION_NAME = "idle";
        private const string WALK_ANIMATION_NAME = "walk";
        private const string RIGHT_ARM_SWING_ANIMATION_NAME = "rightArmSwing";
        private const string LEFT_ARM_SWING_ANIMATION_NAME = "leftArmSwing";

        private static StateMachine playerAnimationStateMachine;

        public static void SetStateMachine(StateMachine value)
        {
            playerAnimationStateMachine = value;
        }

        public static void StartWalkAnimation()
        {

            StartAnimation(WALK_ANIMATION_NAME);
        }

        public static void StartIdleAnimation()
        {
            StartAnimation(IDLE_ANIMATION_NAME);
        }        

        public static void StartRightArmSwingAnimation()
        {
            StartAnimation(RIGHT_ARM_SWING_ANIMATION_NAME);
        }

        public static void StartLeftArmSwingAnimation()
        {
            StartAnimation(LEFT_ARM_SWING_ANIMATION_NAME);
        }    

        private static void StartAnimation(string animationName)
        {
            if (null != playerAnimationStateMachine)
            {
                playerAnimationStateMachine.ExecuteAction(animationName);
            }
        }    
    }
}