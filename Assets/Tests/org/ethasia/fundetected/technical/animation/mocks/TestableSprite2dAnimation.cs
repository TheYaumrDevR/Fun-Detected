using System.Collections.Generic;

using Org.Ethasia.Fundetected.Technical.Animation;

namespace Org.Ethasia.Fundetected.Technical.Animation.Mocks
{
    public class TestableSprite2dAnimation : Sprite2dAnimation
    {
        public List<int> SpriteFramesSet
        {
            get;
            private set;
        }

        protected TestableSprite2dAnimation(List<Sprite2dAnimationFrame> sprites) : base(sprites) 
        {
            SpriteFramesSet = new List<int>();
        }

        protected override void UpdateSpriteFrame()
        {
            SpriteFramesSet.Add(currentFrameIndex);
        }       

        public new class Builder : Sprite2dAnimation.Builder
        {
            public new TestableSprite2dAnimation Build()
            {
                TestableSprite2dAnimation result = new TestableSprite2dAnimation(sprites);
                result.isLooping = isLooping;

                return result;
            } 
        } 
    }
}