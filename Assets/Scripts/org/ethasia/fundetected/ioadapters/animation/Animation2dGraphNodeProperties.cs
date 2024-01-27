using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Ioadapters.Animation
{
    public struct Animation2dGraphNodeProperties
    {
        public string Name;
        public float AnimationSpeedMultiplier;
        public Animation2dProperties Animation;

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
            Name = "";
            IsRootNode = isRootNode;
            AnimationSpeedMultiplier = 1.0f;
            Animation = new Animation2dProperties("", false);
            Transitions = new Dictionary<string, Animation2dGraphNodeProperties>();
        }
    }
}