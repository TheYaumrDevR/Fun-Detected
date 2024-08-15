using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{
    public class EnemyAnimationPresenterMock : IEnemyAnimationPresenter
    {
        public int TimesPlayLeftStrikeAnimationWasCalled
        {
            get;
            private set;
        }

        public int TimesPlayRightStrikeAnimationWasCalled
        {
            get;
            private set;
        }

        public void PlayIdleAnimation(StateMachine animationStateMachine)
        {

        }

        public void PlayLeftStrikeAnimation(StateMachine animationStateMachine)
        {
            TimesPlayLeftStrikeAnimationWasCalled++;
        }

        public void PlayRightStrikeAnimation(StateMachine animationStateMachine)
        {
            TimesPlayRightStrikeAnimationWasCalled++;
        }    

        public void PlayDeathAnimation(StateMachine animationStateMachine)
        {

        }

        public void Reset()
        {
            TimesPlayLeftStrikeAnimationWasCalled = 0;
            TimesPlayRightStrikeAnimationWasCalled = 0;
        }
    }
}