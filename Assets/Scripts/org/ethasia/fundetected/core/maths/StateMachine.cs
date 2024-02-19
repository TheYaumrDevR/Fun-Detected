namespace Org.Ethasia.Fundetected.Core.Maths
{
    public class StateMachine
    {
        private StateMachineNodeWithTransitions currentState;

        public StateMachine(StateMachineNodeWithTransitions startState)
        {
            currentState = startState;
            EnterCurrentState();
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

        public bool CanExecuteAction(string actionName)
        {
            StateMachineNodeWithTransitions nextState = currentState.GetNextStateForAction(actionName);
            return null != nextState;
        }

        private void EnterCurrentState()
        {
            currentState.OnEnterState();
        }
    }
}