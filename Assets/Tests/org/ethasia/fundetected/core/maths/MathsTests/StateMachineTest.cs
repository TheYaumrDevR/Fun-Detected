using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Core.Maths.Tests
{
    public class StateMachineTest
    {
        [Test]
        public void TestStateMachineTwoStateTransitionLoop()
        {
            List<string> transitionTracker = new List<string>();
            StateMachineTestCommand transitionIdleStateCommand = new StateMachineTestCommand(transitionTracker, "idle");
            StateMachineTestCommand transitionWalkStateCommand = new StateMachineTestCommand(transitionTracker, "walk");

            StateMachineNodeWithTransitions idleNode = new StateMachineNodeWithTransitions
                .Builder()
                .SetStateEntryCommand(transitionIdleStateCommand)
                .Build();

            StateMachineNodeWithTransitions walkNode = new StateMachineNodeWithTransitions
                .Builder()
                .SetStateEntryCommand(transitionWalkStateCommand)
                .AddStateForAction("idle", idleNode)
                .Build();      

            idleNode.AddTransitionFunction("walk", walkNode);  

            StateMachine testCandidate = new StateMachine(idleNode);

            testCandidate.ExecuteAction("walk");
            testCandidate.ExecuteAction("idle");

            Assert.That(transitionTracker[0], Is.EqualTo("idle"));  
            Assert.That(transitionTracker[1], Is.EqualTo("walk"));
            Assert.That(transitionTracker[2], Is.EqualTo("idle"));  
        }

        public class StateMachineTestCommand : StateMachineCommand
        {
            private List<string> transitionTracker;
            private string transitionName;

            public StateMachineTestCommand(List<string> transitionTracker, string transitionName)
            {
                this.transitionTracker = transitionTracker;
                this.transitionName = transitionName;
            }

            public void Execute()
            {
                transitionTracker.Add(transitionName);
            }
        }
    }
}