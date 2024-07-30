using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Core
{
    public interface IEnemyAnimationPresenter
    {
        void PlayIdleAnimation(StateMachine animationStateMachine);
        void PlayAttackAnimation(StateMachine animationStateMachine);
        void PlayDeathAnimation(StateMachine animationStateMachine);
    }
}