using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public struct Animation2dGraphNodeProperties
    {
        public float AnimationSpeedMultiplier;
        public Animation2dProperties AnimationFrames;

        public bool IsRootNode
        {
            get;
            private set;
        }   

        public Dictionary<string, Animation2dGraphNodeProperties> Transitions
        {
            get;
            private set;
        }

        public Animation2dGraphNodeProperties(bool isRootNode)
        {
            IsRootNode = isRootNode;
            AnimationSpeedMultiplier = 1.0f;
            AnimationFrames = new Animation2dProperties("", false);
            Transitions = new Dictionary<string, Animation2dGraphNodeProperties>();
        }
    }
}