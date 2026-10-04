using System;

using Org.Ethasia.Fundetected.Ioadapters.Animation;

namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct AnimationPresentationContext
    {
        public Func<AnimationSpeedStatBindings, float> AnimationSpeedMultiplierStatProvider { get; set; }
    }
}