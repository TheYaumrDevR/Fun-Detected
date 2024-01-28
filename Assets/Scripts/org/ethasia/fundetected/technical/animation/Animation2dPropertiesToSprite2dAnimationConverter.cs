using System.Collections.Generic;
using UnityEngine;

using Org.Ethasia.Fundetected.Core.Maths;
using Org.Ethasia.Fundetected.Ioadapters.Animation;

namespace Org.Ethasia.Fundetected.Technical.Animation
{
    public class Animation2dPropertiesToSprite2dAnimationConverter
    {   
        public static StateMachine ConvertAnimation2dGraphNodePropertiesToStateMachine(Animation2dGraphNodeProperties toConvert, SpriteRenderer spriteRenderer)
        {
            Dictionary<string, StateMachineNodeWithTransitions> stateMachineNodesById = ConvertAnimation2dGraphToStateMachineNodes(toConvert, spriteRenderer);
            ConnectStateMachineNodes(stateMachineNodesById, toConvert);

            return new StateMachine(stateMachineNodesById[toConvert.Name]);
        }

        private static void ConnectStateMachineNodes(Dictionary<string, StateMachineNodeWithTransitions> stateMachineNodesById, Animation2dGraphNodeProperties sourceGraph)
        {
            HashSet<Animation2dGraphNodeProperties> alreadyConnectedAnimation2dGraphNodes = new HashSet<Animation2dGraphNodeProperties>();

            Animation2dGraphConnectionMethodContext recursiveMethodContext = new Animation2dGraphConnectionMethodContext();
            recursiveMethodContext.StateMachineNodesById = stateMachineNodesById;
            recursiveMethodContext.SourceGraph = sourceGraph;
            recursiveMethodContext.AlreadyConnectedAnimation2dGraphNodes = alreadyConnectedAnimation2dGraphNodes;

            ConnectStateMachineNodesRecursive(recursiveMethodContext);
        }

        private static void ConnectStateMachineNodesRecursive(Animation2dGraphConnectionMethodContext parameters)
        {
            Dictionary<string, StateMachineNodeWithTransitions> stateMachineNodesById = parameters.StateMachineNodesById;
            Animation2dGraphNodeProperties sourceGraph = parameters.SourceGraph;
            HashSet<Animation2dGraphNodeProperties> alreadyConnectedAnimation2dGraphNodes = parameters.AlreadyConnectedAnimation2dGraphNodes;

            if (!alreadyConnectedAnimation2dGraphNodes.Contains(sourceGraph))
            {
                alreadyConnectedAnimation2dGraphNodes.Add(sourceGraph);

                foreach (KeyValuePair<string, Animation2dGraphNodeProperties> transition in sourceGraph.Transitions)
                {
                    StateMachineNodeWithTransitions sourceNode = stateMachineNodesById[sourceGraph.Name];
                    StateMachineNodeWithTransitions targetNode = stateMachineNodesById[transition.Key];

                    sourceNode.AddTransitionFunction(transition.Value.Name, targetNode);

                    parameters.SourceGraph = transition.Value;

                    ConnectStateMachineNodesRecursive(parameters);
                }
            }
        }

        public static Dictionary<string, StateMachineNodeWithTransitions> ConvertAnimation2dGraphToStateMachineNodes(Animation2dGraphNodeProperties toConvert, SpriteRenderer spriteRenderer)
        {
            HashSet<Animation2dGraphNodeProperties> alreadyConvertedAnimation2dGraphNodes = new HashSet<Animation2dGraphNodeProperties>();            
            Dictionary<string, StateMachineNodeWithTransitions> result = new Dictionary<string, StateMachineNodeWithTransitions>();
            alreadyConvertedAnimation2dGraphNodes.Add(toConvert);

            Sprite2dAnimation initialAnimation = ConvertAnimation2dPropertiesToSprite2dAnimation(toConvert.Animation, spriteRenderer);
            Sprite2dAnimator sprite2dAnimator = new Sprite2dAnimator(initialAnimation, toConvert.AnimationSpeedMultiplier);

            Animation2dGraphNodeConversionContext conversionContext = new Animation2dGraphNodeConversionContext();
            conversionContext.AlreadyConvertedAnimation2dGraphNodes = alreadyConvertedAnimation2dGraphNodes;
            conversionContext.Sprite2dAnimator = sprite2dAnimator;
            conversionContext.SpriteRenderer = spriteRenderer;
            conversionContext.ToConvert = toConvert;           

            StateMachineNodeWithTransitions stateMachineNode = CreateStateMachineNode(conversionContext);

            result.Add(toConvert.Name, stateMachineNode);

            conversionContext.AlreadyExistingStatesByName = result;

            ProcessAnimationTransitions(toConvert.Transitions, conversionContext);

            return result;
        }

        private static void ProcessAnimationTransitions(Dictionary<string, Animation2dGraphNodeProperties> transitions, Animation2dGraphNodeConversionContext recursiveContext)
        {
            foreach (KeyValuePair<string, Animation2dGraphNodeProperties> transition in transitions)
            {
                recursiveContext.ToConvert = transition.Value;
                ConvertAnimation2dGraphNodePropertiesToStateMachineNode(recursiveContext);
            }
        }

        private static void ConvertAnimation2dGraphNodePropertiesToStateMachineNode(Animation2dGraphNodeConversionContext context)
        {
            var toConvert = context.ToConvert;
            var alreadyConvertedAnimation2dGraphNodes = context.AlreadyConvertedAnimation2dGraphNodes;
            var alreadyExistingStatesByName = context.AlreadyExistingStatesByName;

            if (!alreadyConvertedAnimation2dGraphNodes.Contains(toConvert))
            {
                StateMachineNodeWithTransitions stateMachineNode = CreateStateMachineNode(context);                  

                alreadyConvertedAnimation2dGraphNodes.Add(toConvert);
                alreadyExistingStatesByName.Add(toConvert.Name, stateMachineNode);

                ProcessAnimationTransitions(toConvert.Transitions, context);
            }
        }       

        private static StateMachineNodeWithTransitions CreateStateMachineNode(Animation2dGraphNodeConversionContext conversionContext)
        {
            Animation2dGraphNodeProperties toConvert = conversionContext.ToConvert;
            Sprite2dAnimator sprite2dAnimator = conversionContext.Sprite2dAnimator;

            Sprite2dAnimation animation = ConvertAnimation2dPropertiesToSprite2dAnimation(toConvert.Animation, conversionContext.SpriteRenderer);

            Sprite2dAnimatorStateChangeCommand stateEntryCommand = new Sprite2dAnimatorStateChangeCommand.Builder()
                .SetAnimator(sprite2dAnimator)
                .SetAnimation(animation)
                .SetAnimationSpeedMultiplier(toConvert.AnimationSpeedMultiplier)
                .Build();            

            StateMachineNodeWithTransitions stateMachineNode = new StateMachineNodeWithTransitions.Builder()
                .SetStateEntryCommand(stateEntryCommand)
                .Build();

            return stateMachineNode;
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

        private struct Animation2dGraphNodeConversionContext
        {
            public Animation2dGraphNodeProperties ToConvert { get; set; }
            public HashSet<Animation2dGraphNodeProperties> AlreadyConvertedAnimation2dGraphNodes { get; set; }
            public Sprite2dAnimator Sprite2dAnimator { get; set; }
            public SpriteRenderer SpriteRenderer { get; set; }
            public Dictionary<string, StateMachineNodeWithTransitions> AlreadyExistingStatesByName { get; set; }
        }

        private struct Animation2dGraphConnectionMethodContext
        {
            public Dictionary<string, StateMachineNodeWithTransitions> StateMachineNodesById;
            public Animation2dGraphNodeProperties SourceGraph;
            public HashSet<Animation2dGraphNodeProperties> AlreadyConnectedAnimation2dGraphNodes;
        }        
    }
}