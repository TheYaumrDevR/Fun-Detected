using UnityEngine;

namespace Org.Ethasia.Fundetected.Technical.Animation
{
    public class Sprite2dAnimatorBehavior : MonoBehaviour
    {
        public Sprite2dAnimator Animator
        {
            private get;
            set;
        }

        void Update()
        {
            if (null != Animator)
            {
                Animator.Update(Time.deltaTime);
            }
        }
    }
}