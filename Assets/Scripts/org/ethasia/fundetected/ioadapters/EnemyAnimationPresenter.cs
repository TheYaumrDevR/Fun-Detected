using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class EnemyAnimationPresenter : IEnemyAnimationPresenter
    {
        private const string IDLE_ANIMATION_NAME = "idle";
        private const string ATTACK_ANIMATION_NAME = "attack";
        private const string DIE_ANIMATION_NAME = "die";

        public void PlayIdleAnimation(StateMachine animationStateMachine)
        {
            animationStateMachine.ExecuteAction(IDLE_ANIMATION_NAME);
        }

        public void PlayAttackAnimation(StateMachine animationStateMachine)
        {
            animationStateMachine.ExecuteAction(ATTACK_ANIMATION_NAME);
        }

        public void PlayDeathAnimation(StateMachine animationStateMachine)
        {
            animationStateMachine.ExecuteAction(DIE_ANIMATION_NAME);
        }
    }
}