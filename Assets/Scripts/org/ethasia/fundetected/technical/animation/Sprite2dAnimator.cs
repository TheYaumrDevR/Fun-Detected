using UnityEngine;

namespace Org.Ethasia.Fundetected.Technical.Animation
{
    public class Sprite2dAnimator : MonoBehaviour
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

        void Update()
        {
            if (null != Animation)
            {
                Animation.Update(Time.deltaTime * SpeedMultiplier);
            }
        }
    }
}