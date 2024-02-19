using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using UnityEngine;
using UnityEngine.Windows;

using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters.Animation
{
    public class Animation2dGraphPropertiesGatewayImpl : Animation2dGraphPropertiesGateway
    {
        private XmlFiles xmlFiles;

        public Animation2dGraphPropertiesGatewayImpl()
        {
            xmlFiles = TechnicalFactory.GetInstance().CreateXmlFiles();
        }

        public Animation2dGraphNodeProperties LoadAnimation2dGraph(string animationGraphName)
        {
            string fileName = animationGraphName.Replace(" ", "") + "Animations";
            Animation2dGraphNodeProperties result = new Animation2dGraphNodeProperties();

            XmlElement animationPropertiesRoot = xmlFiles.TryToLoadXmlRoot("/Animations/" + fileName + ".xml");

            if (null != animationPropertiesRoot)
            {
                Dictionary<string, Animation2dGraphNodeProperties> animationGraphNodesById = CreateAnimationGraphNodes(animationPropertiesRoot);
                CreateAnimationNodeTransitions(animationGraphNodesById, animationPropertiesRoot);

                result = animationGraphNodesById["entryAnimation"];
            }
            else
            {
                throw new AssetLoadFailureException("XML root node for animation definition " + animationPropertiesRoot + " does not exist");
            }                

            return result;
        }

        private Dictionary<string, Animation2dGraphNodeProperties> CreateAnimationGraphNodes(XmlElement animationPropertiesRoot)
        {
            Dictionary<string, Animation2dGraphNodeProperties> result = new Dictionary<string, Animation2dGraphNodeProperties>();

            XmlElement entryNodeXml = animationPropertiesRoot["entryAnimation"];

            if (null != entryNodeXml)
            {
                CreateAnimationGraphNode(result, entryNodeXml);
                result["entryAnimation"] = result[entryNodeXml.GetAttribute("id")];
            }
            else
            {
                throw new AssetLoadFailureException("Entry animation in animation graph is not defined");
            }

            XmlNodeList otherAnimations = animationPropertiesRoot.GetElementsByTagName("animation");
            foreach (XmlElement otherAnimationXml in otherAnimations)
            {
                CreateAnimationGraphNode(result, otherAnimationXml);               
            }            

            return result;
        }

        private void CreateAnimationNodeTransitions(Dictionary<string, Animation2dGraphNodeProperties> animationGraphNodesById, XmlElement animationPropertiesRoot)
        {
            XmlElement entryNodeXml = animationPropertiesRoot["entryAnimation"];
            CreateAnimationNodeTransition(animationGraphNodesById, entryNodeXml);   

            XmlNodeList otherAnimations = animationPropertiesRoot.GetElementsByTagName("animation");
            foreach (XmlElement otherAnimationXml in otherAnimations)
            {
                CreateAnimationNodeTransition(animationGraphNodesById, otherAnimationXml);               
            }              
        }

        private void CreateAnimationGraphNode(Dictionary<string, Animation2dGraphNodeProperties> animationGraphNodesById, XmlElement animationXml)
        {
            string speedMultiplierText = animationXml.GetAttribute("speedMultiplier");
            string nodeId = animationXml.GetAttribute("id");

            Animation2dGraphNodeProperties animationNode = new Animation2dGraphNodeProperties(false);
            animationNode.Name = nodeId;

            if (Single.TryParse(speedMultiplierText, NumberStyles.Float, CultureInfo.InvariantCulture, out float speedMultiplier))
            {
                animationNode.AnimationSpeedMultiplier = speedMultiplier;
            }                

            Animation2dProperties animation = CreateAnimation2dProperties(animationXml);
            animationNode.Animation = animation;

            if (null != nodeId)
            {
                animationGraphNodesById[nodeId] = animationNode;
            }
            else
            {
                throw new AssetLoadFailureException("At least one animation graph node in the animation XML has no ID");
            }              
        }

        private void CreateAnimationNodeTransition(Dictionary<string, Animation2dGraphNodeProperties> animationGraphNodesById, XmlElement animationNodeXml)
        {
            XmlElement transitionsXml = animationNodeXml["transitions"];
            string currentAnimationId = animationNodeXml.GetAttribute("id");

            if (null != transitionsXml)
            {
                XmlNodeList transitionsListXml = transitionsXml.GetElementsByTagName("transition");

                if (null != transitionsListXml)
                {
                    foreach (XmlElement transitionXml in transitionsListXml)
                    {
                        string transitionTargetId = transitionXml.GetAttribute("target");

                        if (null != transitionTargetId)
                        {
                            animationGraphNodesById[currentAnimationId].Transitions[transitionTargetId] = animationGraphNodesById[transitionTargetId];
                        }
                    }
                }
            }              
        }

        private Animation2dProperties CreateAnimation2dProperties(XmlElement animationGraphNodeXml)
        {
            Animation2dProperties result = new Animation2dProperties("", false);

            XmlElement animationFramesXml = animationGraphNodeXml["animationFrames"];
            string spriteImageName = animationFramesXml.GetAttribute("spriteImageName");
            string isLoopingText = animationFramesXml.GetAttribute("isLooping");

            if (null != animationFramesXml && null != spriteImageName)
            {
                if (Boolean.TryParse(isLoopingText, out bool isLooping))
                {
                    result = new Animation2dProperties(spriteImageName, isLooping);
                }
                else
                {
                    result = new Animation2dProperties(spriteImageName, false);
                }

                List<Animation2dFrameProperties> animation2dFrames = CreateAnimation2dFrames(animationFramesXml);
                result.AnimationFrames.AddRange(animation2dFrames);             
            }
            else
            {
                throw new AssetLoadFailureException("At least one animation in the animation graph XML has no sprite image name or animation frames defined");
            }

            return result;
        }

        private List<Animation2dFrameProperties> CreateAnimation2dFrames(XmlElement animationFramesXml)
        {
            XmlNodeList frames = animationFramesXml.GetElementsByTagName("animationFrame");
            List<Animation2dFrameProperties> result = new List<Animation2dFrameProperties>();

            foreach (XmlElement frame in frames)
            {
                string indexText = frame.GetAttribute("index");
                Animation2dFrameProperties animationFrame;

                if (int.TryParse(indexText, out int index))
                {
                    animationFrame = new Animation2dFrameProperties(index, true);
                }
                else
                {
                    animationFrame = new Animation2dFrameProperties(-1, false);
                }

                result.Add(animationFrame);
            } 

            return result;             
        }
    }
}