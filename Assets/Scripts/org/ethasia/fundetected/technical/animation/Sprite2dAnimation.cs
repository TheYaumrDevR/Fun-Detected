using System.Collections.Generic;
using UnityEngine;

namespace Org.Ethasia.Fundetected.Technical.Animation
{
    public class Sprite2dAnimation
    {
        private SpriteRenderer spriteRenderer;
        private List<Sprite2dAnimationFrame> sprites;
        protected bool isLooping;

        private float accumulatedDeltaTime;
        protected int currentFrameIndex;

        protected Sprite2dAnimation(List<Sprite2dAnimationFrame> sprites)
        {
            this.sprites = sprites;
        }

        public void Reset()
        {
            accumulatedDeltaTime = 0.0f;
            currentFrameIndex = 0;

            UpdateSpriteFrame();
        }

        public void Update(float deltaTime)
        {
            accumulatedDeltaTime += deltaTime;

            while (accumulatedDeltaTime >= 1.0f)
            {
                accumulatedDeltaTime -= 1.0f;
                currentFrameIndex++;

                AdjustCurrentFrameIndexAndUpdateSpriteIfNecessary();
            }
        }

        private void AdjustCurrentFrameIndexAndUpdateSpriteIfNecessary()
        {
            if (currentFrameIndex == sprites.Count && isLooping)
            {
                currentFrameIndex = 0;
                UpdateSpriteFrame();
            }
            else if (currentFrameIndex < sprites.Count)
            {
                UpdateSpriteFrame();
            }
            else
            {
                currentFrameIndex--;
            }           
        }

        protected virtual void UpdateSpriteFrame()
        {
            Sprite2dAnimationFrame newFrame = sprites[currentFrameIndex];

            if (newFrame.HasSprite && null != newFrame.Sprite)
            {   
                spriteRenderer.sprite = newFrame.Sprite;
            }
        }

        public class Builder
        {
            protected List<Sprite2dAnimationFrame> sprites;
            protected bool isLooping;
            private SpriteRenderer spriteRenderer;

            public Builder()
            {
                sprites = new List<Sprite2dAnimationFrame>();
            }

            public Builder AddAnimationFrame(Sprite sprite)
            {
                Sprite2dAnimationFrame spriteAnimationFrame = new Sprite2dAnimationFrame(sprite);
                sprites.Add(spriteAnimationFrame);

                return this;
            }

            public Builder AddEmptyAnimationFrame()
            {
                Sprite2dAnimationFrame spriteAnimationFrame = new Sprite2dAnimationFrame();
                sprites.Add(spriteAnimationFrame);

                return this;
            }            

            public Builder SetIsLooping(bool value)
            {
                isLooping = value;
                return this;
            }   

            public Builder SetSpriteRenderer(SpriteRenderer value)
            {
                spriteRenderer = value;
                return this;
            }

            public Sprite2dAnimation Build()
            {
                Sprite2dAnimation result = new Sprite2dAnimation(sprites);
                result.isLooping = isLooping;
                result.spriteRenderer = spriteRenderer;

                result.UpdateSpriteFrame();

                return result;
            }         
        }
    }
}