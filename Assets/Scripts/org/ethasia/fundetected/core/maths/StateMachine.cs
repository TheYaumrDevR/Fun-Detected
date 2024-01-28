namespace Org.Ethasia.Fundetected.Core.Maths
{
    public class StateMachine
    {
        private StateMachineNodeWithTransitions currentState;

        public StateMachine(StateMachineNodeWithTransitions startState)
        {
            currentState = startState;
        }

        public void ExecuteAction(string actionName)
        {
            StateMachineNodeWithTransitions newState = currentState.GetNextStateForAction(actionName);

            if (null != newState)
            {
                currentState = newState;
                EnterCurrentState();
            }
        }

        public void EnterCurrentState()
        {
            currentState.OnEnterState();
        }
    }
}