namespace Org.Ethasia.Fundetected.Technical.Animation
{
    public class Sprite2dAnimator
    {
        public Sprite2dAnimation Animation
        {
            private get;
            set;
        }

        public float SpeedMultiplier
        {
            private get;
            set;            
        }

        public Sprite2dAnimator(Sprite2dAnimation initialAnimation, float initialAnimationSpeed)
        {
            Animation = initialAnimation;
            SpeedMultiplier = initialAnimationSpeed;
        }

        public void Update(float deltaTime)
        {
            if (null != Animation)
            {
                Animation.Update(deltaTime * SpeedMultiplier);
            }
        }
    }
}