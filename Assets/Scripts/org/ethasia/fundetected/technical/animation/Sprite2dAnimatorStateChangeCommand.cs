using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Technical.Animation
{
    public class Sprite2dAnimatorStateChangeCommand : StateMachineCommand
    {
        private Sprite2dAnimator animator;
        private Sprite2dAnimation animation;
        private float animationSpeedMultiplier;

        public void Execute()
        {
            animator.Animation = animation;
            animator.SpeedMultiplier = animationSpeedMultiplier;
        }

        public class Builder
        {
            private Sprite2dAnimator animator;
            private Sprite2dAnimation animation;
            private float animationSpeedMultiplier;           

            public Builder SetAnimator(Sprite2dAnimator value)
            {
                animator = value;
                return this;
            } 

            public Builder SetAnimation(Sprite2dAnimation value)
            {
                animation = value;
                return this;
            }   

            public Builder SetAnimationSpeedMultiplier(float value)
            {
                animationSpeedMultiplier = value;
                return this;
            }     

            public Sprite2dAnimatorStateChangeCommand Build()
            {
                Sprite2dAnimatorStateChangeCommand result = new Sprite2dAnimatorStateChangeCommand();

                result.animator = animator;
                result.animation = animation;
                result.animationSpeedMultiplier = animationSpeedMultiplier;

                return result;
            }                  
        }
    }
}