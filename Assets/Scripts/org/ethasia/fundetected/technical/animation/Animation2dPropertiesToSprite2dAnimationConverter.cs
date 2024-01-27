using System.Collections.Generic;
using UnityEngine;

using Org.Ethasia.Fundetected.Core.Maths;
using Org.Ethasia.Fundetected.Ioadapters.Animation;

namespace Org.Ethasia.Fundetected.Technical.Animation
{
    public class Animation2dPropertiesToSprite2dAnimationConverter
    {
        public static Dictionary<string, StateMachineNodeWithTransitions> ConvertAnimation2dGraphToStateMachine(Animation2dGraphNodeProperties toConvert, SpriteRenderer spriteRenderer)
        {
            HashSet<Animation2dGraphNodeProperties> alreadyConvertedAnimation2dGraphNodes = new HashSet<Animation2dGraphNodeProperties>();            
            Dictionary<string, StateMachineNodeWithTransitions> result = new Dictionary<string, StateMachineNodeWithTransitions>();
            alreadyConvertedAnimation2dGraphNodes.Add(toConvert);

            Sprite2dAnimation initialAnimation = ConvertAnimation2dPropertiesToSprite2dAnimation(toConvert.Animation, spriteRenderer);
            Sprite2dAnimator sprite2dAnimator = new Sprite2dAnimator(initialAnimation, toConvert.AnimationSpeedMultiplier);

            Sprite2dAnimatorStateChangeCommand initialStateEnterCommand = new Sprite2dAnimatorStateChangeCommand.Builder()
                .SetAnimator(sprite2dAnimator)
                .SetAnimation(initialAnimation)
                .SetAnimationSpeedMultiplier(toConvert.AnimationSpeedMultiplier)
                .Build();            

            StateMachineNodeWithTransitions stateMachineNode = new StateMachineNodeWithTransitions.Builder()
                .SetStateEntryCommand(initialStateEnterCommand)
                .Build();

            result.Add(toConvert.Name, stateMachineNode);

            Animation2dGraphNodeConversionContext conversionContext = new Animation2dGraphNodeConversionContext();
            conversionContext.AlreadyConvertedAnimation2dGraphNodes = alreadyConvertedAnimation2dGraphNodes;
            conversionContext.Sprite2dAnimator = sprite2dAnimator;
            conversionContext.SpriteRenderer = spriteRenderer;
            conversionContext.AlreadyExistingStatesByName = result;

            ProcessAnimationTransitions(toConvert.Transitions, conversionContext);

            return result;
        }

        private static void ProcessAnimationTransitions(Dictionary<string, Animation2dGraphNodeProperties> transitions, Animation2dGraphNodeConversionContext recursiveContext)
        {
            foreach (KeyValuePair<string, Animation2dGraphNodeProperties> transition in transitions)
            {
                recursiveContext.ToConvert = transition.Value;
                ConvertAnimation2dGraphNodePropertiesToSprite2dAnimatorStateChangeCommand(recursiveContext);
            }
        }

        private static void ConvertAnimation2dGraphNodePropertiesToStateMachineNode(Animation2dGraphNodeConversionContext context)
        {
            var toConvert = context.ToConvert;
            var alreadyConvertedAnimation2dGraphNodes = context.AlreadyConvertedAnimation2dGraphNodes;
            var sprite2dAnimator = context.Sprite2dAnimator;
            var alreadyExistingStatesByName = context.AlreadyExistingStatesByName;

            if (!alreadyConvertedAnimation2dGraphNodes.Contains(toConvert))
            {
                Sprite2dAnimation convertedAnimation = ConvertAnimation2dPropertiesToSprite2dAnimation(toConvert.Animation, context.SpriteRenderer);

                Sprite2dAnimatorStateChangeCommand stateChangeCommand = new Sprite2dAnimatorStateChangeCommand.Builder()
                    .SetAnimator(sprite2dAnimator)
                    .SetAnimation(convertedAnimation)
                    .SetAnimationSpeedMultiplier(toConvert.AnimationSpeedMultiplier)
                    .Build();

                StateMachineNodeWithTransitions stateMachineNode = new StateMachineNodeWithTransitions.Builder()
                    .SetStateEntryCommand(stateChangeCommand)
                    .Build();                    

                alreadyConvertedAnimation2dGraphNodes.Add(toConvert);
                alreadyExistingStatesByName.Add(toConvert.Name, stateMachineNode);

                ProcessAnimationTransitions(toConvert.Transitions, context);
            }
        }       

        private static Sprite2dAnimation ConvertAnimation2dPropertiesToSprite2dAnimation(Animation2dProperties toConvert, SpriteRenderer spriteRenderer)
        {
            Sprite2dAnimation.Builder resultBuilder = new Sprite2dAnimation.Builder()
                .SetIsLooping(toConvert.IsLooping)
                .SetSpriteRenderer(spriteRenderer);

            ConvertAnimation2dFramesToSprite2dAnimationFrames(toConvert, resultBuilder);

            return resultBuilder.Build();
        }

        private static void ConvertAnimation2dFramesToSprite2dAnimationFrames(Animation2dProperties toConvert, Sprite2dAnimation.Builder resultBuilder)
        {
            foreach (Animation2dFrameProperties animationFrameProperties in toConvert.AnimationFrames)
            {
                if (!animationFrameProperties.HasImage)
                {
                    resultBuilder.AddEmptyAnimationFrame();
                }
                else
                {
                    Sprite frameSprite = Resources.Load<Sprite>(toConvert.SpriteImageName + "_" + animationFrameProperties.FrameIndex);
                    resultBuilder.AddAnimationFrame(frameSprite);
                }
            }
        }

        public struct Animation2dGraphNodeConversionContext
        {
            public Animation2dGraphNodeProperties ToConvert { get; set; }
            public HashSet<Animation2dGraphNodeProperties> AlreadyConvertedAnimation2dGraphNodes { get; set; }
            public Sprite2dAnimator Sprite2dAnimator { get; set; }
            public SpriteRenderer SpriteRenderer { get; set; }
            public Dictionary<string, StateMachineNodeWithTransitions> AlreadyExistingStatesByName { get; set; }
        }
    }
}