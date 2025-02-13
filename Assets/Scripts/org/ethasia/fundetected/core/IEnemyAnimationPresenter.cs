using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Core
{
    public interface IEnemyAnimationPresenter
    {
        void PlayIdleAnimation(StateMachine animationStateMachine);
        void PlayLeftStrikeAnimation(StateMachine animationStateMachine);
        void PlayRightStrikeAnimation(StateMachine animationStateMachine);
        void PlayDeathAnimation(StateMachine animationStateMachine);
        void PlayInstantDeathAnimation(StateMachine animationStateMachine);
    }
}