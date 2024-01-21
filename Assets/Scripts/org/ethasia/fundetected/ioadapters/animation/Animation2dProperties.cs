using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Ioadapters.Animation
{
    public struct Animation2dProperties
    {
        public List<Animation2dFrameProperties> AnimationFrames
        {
            get;
            private set;
        }

        public string SpriteImageName
        {
            get;
            private set;
        }

        public bool IsLooping
        {
            get;
            private set;
        }

        public Animation2dProperties(string spriteImageName, bool isLooping)
        {
            SpriteImageName = spriteImageName;
            IsLooping = isLooping;
            AnimationFrames = new List<Animation2dFrameProperties>();
        }
    }
}