using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Windows;

using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class Animation2dGraphPropertiesGateway
    {
        private XmlFiles xmlFiles;

        public Animation2dGraphPropertiesGateway()
        {
            xmlFiles = TechnicalFactory.GetInstance().CreateXmlFiles();
        }

        public Animation2dGraphNodeProperties LoadAnimation2dGraph(string animationGraphName)
        {
            // TODO: Build a proxy for this which caches loaded anims
            // TODO: Give AssetLoadFailureException() a message of what failed to load
            Animation2dGraphNodeProperties result = new Animation2dGraphNodeProperties();

            XmlElement animationPropertiesRoot = xmlFiles.TryToLoadXmlRoot("/Animations/" + animationGraphName + ".xml");

            if (null != animationPropertiesRoot)
            {
                Dictionary<string, Animation2dGraphNodeProperties> animationGraphNodesById = CreateAnimationGraphNodes(animationPropertiesRoot);
                CreateAnimationNodeTransitions(animationGraphNodesById, animationPropertiesRoot);
            }
            else
            {
                throw new AssetLoadFailureException();
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
            }
            else
            {
                throw new AssetLoadFailureException();
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

            if (Single.TryParse(speedMultiplierText, out float speedMultiplier))
            {
                animationNode.AnimationSpeedMultiplier = speedMultiplier;
            }                

            Animation2dProperties animationFrames = CreateAnimation2dProperties(animationXml);
            animationNode.AnimationFrames = animationFrames;

            if (null != nodeId)
            {
                animationGraphNodesById[nodeId] = animationNode;
            }
            else
            {
                throw new AssetLoadFailureException();
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
            string spriteImageName = animationGraphNodeXml.GetAttribute("spriteImageName");
            string isLoopingText = animationGraphNodeXml.GetAttribute("isLooping");

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
                throw new AssetLoadFailureException();
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