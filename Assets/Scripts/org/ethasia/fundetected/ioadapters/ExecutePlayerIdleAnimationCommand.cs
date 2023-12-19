using Org.Ethasia.Fundetected.Core.Maths;
using UnityEngine;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class ExecutePlayerIdleAnimationCommand : StateMachineCommand
    {
        private Animator playerSpriteAnimator;

        public ExecutePlayerIdleAnimationCommand(Animator playerSpriteAnimator)
        {
            this.playerSpriteAnimator = playerSpriteAnimator;
        }

        public void Execute()
        {
            playerSpriteAnimator.Play("PlayerIdle");
        }
    }
}