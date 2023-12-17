using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Core.Maths
{
    public class StateMachineNodeWithTransitions
    {
        private Dictionary<string, StateMachineNodeWithTransitions> transitionFunctions;

        public StateMachineNodeWithTransitions GetNextStateForAction(string actionName)
        {
            return transitionFunctions[actionName];
        }

        public class Builder
        {
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

            public StateMachineNodeWithTransitions Build()
            {
                StateMachineNodeWithTransitions result = new StateMachineNodeWithTransitions();
                result.transitionFunctions = transitionFunctions;

                return result;
            }
        }
    }
}