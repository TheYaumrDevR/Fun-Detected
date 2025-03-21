using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class EnemyAnimationPresenter : IEnemyAnimationPresenter
    {
        private const string IDLE_ANIMATION_NAME = "idle";
        private const string LEFT_STRIKE_ANIMATION_NAME = "strikeLeft";
        private const string RIGHT_STRIKE_ANIMATION_NAME = "strikeRight";
        private const string DIE_ANIMATION_NAME = "die";
        private const string INSTANT_DIE_ANIMATION_NAME = "dieInstantly";

        public void PlayIdleAnimation(StateMachine animationStateMachine)
        {
            animationStateMachine.ExecuteAction(IDLE_ANIMATION_NAME);
        }

        public void PlayLeftStrikeAnimation(StateMachine animationStateMachine)
        {
            animationStateMachine.ExecuteAction(LEFT_STRIKE_ANIMATION_NAME);
        }

        public void PlayRightStrikeAnimation(StateMachine animationStateMachine)
        {
            animationStateMachine.ExecuteAction(RIGHT_STRIKE_ANIMATION_NAME);
        }        

        public void PlayDeathAnimation(StateMachine animationStateMachine)
        {
            animationStateMachine.ExecuteAction(DIE_ANIMATION_NAME);
        }

        public void PlayInstantDeathAnimation(StateMachine animationStateMachine)
        {
            animationStateMachine.ExecuteAction(INSTANT_DIE_ANIMATION_NAME);
        }
    }
}