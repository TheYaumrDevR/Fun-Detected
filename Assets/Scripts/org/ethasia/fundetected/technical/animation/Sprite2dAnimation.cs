using System.Collections.Generic;
using UnityEngine;

namespace Org.Ethasia.Fundetected.Technical.Animation
{
    public class Sprite2dAnimation
    {
        private SpriteRenderer spriteRenderer;
        private List<Sprite2dAnimationFrame> sprites;
        private bool isLooping;

        private float accumulatedDeltaTime;
        private int currentFrameIndex;

        private Sprite2dAnimation(List<Sprite2dAnimationFrame> sprites)
        {
            this.sprites = sprites;

            if (sprites.Count > 0 && sprites[0].HasSprite)
            {
                spriteRenderer.sprite = sprites[0].Sprite;
            }
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
                UpdateSpriteFrame(currentFrameIndex);
            }
            else if (currentFrameIndex < sprites.Count)
            {
                UpdateSpriteFrame(currentFrameIndex);
            }
            else
            {
                currentFrameIndex--;
            }           
        }

        private void UpdateSpriteFrame(int currentFrameIndex)
        {
            Sprite2dAnimationFrame newFrame = sprites[currentFrameIndex];

            if (newFrame.HasSprite && null != newFrame.Sprite)
            {   
                spriteRenderer.sprite = newFrame.Sprite;
            }
        }

        public class Builder
        {
            private List<Sprite2dAnimationFrame> sprites;
            private bool isLooping;

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

            public Sprite2dAnimation Build()
            {
                Sprite2dAnimation result = new Sprite2dAnimation(sprites);
                result.isLooping = isLooping;

                return result;
            }         
        }
    }
}