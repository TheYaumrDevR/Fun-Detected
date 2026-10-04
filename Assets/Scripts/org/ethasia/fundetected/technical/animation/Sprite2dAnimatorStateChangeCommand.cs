using System;

using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Technical.Animation
{
    public class Sprite2dAnimatorStateChangeCommand : StateMachineCommand
    {
        private Sprite2dAnimator animator;
        private Sprite2dAnimation animation;
        private Func<float> animationSpeedMultiplierProvider;

        public void Execute()
        {
            animation.Reset();
            animator.Animation = animation;
            animator.SpeedMultiplier = null != animationSpeedMultiplierProvider
                ? animationSpeedMultiplierProvider()
                : 1f;
        }

        public class Builder
        {
            private Sprite2dAnimator animator;
            private Sprite2dAnimation animation;
            private Func<float> animationSpeedMultiplierProvider;        

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
                animationSpeedMultiplierProvider = () => value;
                return this;
            }   

            public Builder SetAnimationSpeedMultiplierProvider(Func<float> value)
            {
                animationSpeedMultiplierProvider = value;
                return this;
            }  

            public Sprite2dAnimatorStateChangeCommand Build()
            {
                Sprite2dAnimatorStateChangeCommand result = new Sprite2dAnimatorStateChangeCommand();

                result.animator = animator;
                result.animation = animation;
                result.animationSpeedMultiplierProvider = animationSpeedMultiplierProvider;

                return result;
            }                  
        }
    }
}