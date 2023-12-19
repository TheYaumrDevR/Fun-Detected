using Org.Ethasia.Fundetected.Core.Maths;
using UnityEngine;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class ExecutePlayerWalkAnimationCommand : StateMachineCommand
    {
        private Animator playerSpriteAnimator;

        public ExecutePlayerWalkAnimationCommand(Animator playerSpriteAnimator)
        {
            this.playerSpriteAnimator = playerSpriteAnimator;
        }

        public void Execute()
        {
            playerSpriteAnimator.Play("PlayerWalking");
        }
    }
}