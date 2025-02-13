using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class AnimationStateMachineAssignmentFunction : IAnimationStateMachineAssignmentFunction
    {
        public Enemy Enemy
        {
            private get;
            set;
        }

        public void AssignActionStateMachineToEnemy(StateMachine actionStateMachine)
        {
            Enemy.ActionStateMachine = actionStateMachine;
            Enemy.OnActionStateMachineAssigned();
        }
    }
}