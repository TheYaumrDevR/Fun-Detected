using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Core.Maths
{
    public class StateMachineNodeWithTransitions
    {
        private StateMachineCommand stateEntryCommand;
        private Dictionary<string, StateMachineNodeWithTransitions> transitionFunctions;

        public void AddTransitionFunction(string actionName, StateMachineNodeWithTransitions nextState)
        {
            transitionFunctions[actionName] = nextState;
        }

        public StateMachineNodeWithTransitions GetNextStateForAction(string actionName)
        {
            return transitionFunctions[actionName];
        }

        public void OnEnterState()
        {
            if (null != stateEntryCommand)
            {
                stateEntryCommand.Execute();
            }
        }

        public class Builder
        {
            private StateMachineCommand stateEntryCommand;
            private Dictionary<string, StateMachineNodeWithTransitions> transitionFunctions;

            public Builder()
            {
                transitionFunctions = new Dictionary<string, StateMachineNodeWithTransitions>();
            }

            public Builder AddStateForAction(string actionName, StateMachineNodeWithTransitions nextState)
            {
                transitionFunctions[actionName] = nextState;
                return this;
            }

            public Builder SetStateEntryCommand(StateMachineCommand value)
            {
                stateEntryCommand = value;
                return this;
            }

            public StateMachineNodeWithTransitions Build()
            {
                StateMachineNodeWithTransitions result = new StateMachineNodeWithTransitions();
                result.transitionFunctions = transitionFunctions;
                result.stateEntryCommand = stateEntryCommand;

                return result;
            }
        }
    }
}