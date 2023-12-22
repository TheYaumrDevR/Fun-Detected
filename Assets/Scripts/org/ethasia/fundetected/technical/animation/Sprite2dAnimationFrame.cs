using UnityEngine;

namespace Org.Ethasia.Fundetected.Technical.Animation
{
    public class Sprite2dAnimationFrame
    {
        public Sprite Sprite
        {
            get;
            private set;
        }

        public bool HasSprite
        {
            get;
            private set;
        }

        public Sprite2dAnimationFrame() 
        {
            HasSprite = false;
        } 

        public Sprite2dAnimationFrame(Sprite sprite)
        {
            Sprite = sprite;
            HasSprite = true;
        }
    }
}