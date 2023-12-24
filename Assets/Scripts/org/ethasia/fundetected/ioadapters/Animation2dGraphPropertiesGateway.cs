using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Windows;

using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class Animation2dGraphPropertiesGateway
    {
        public Animation2dGraphNodeProperties LoadAnimation2dGraph(string animationGraphName)
        {
            // TODO: Build a proxy for this which caches loaded anims
            // TODO: Move the XML root node loading code into a new class
            // TODO: Give AssetLoadFailureException() a message of what failed to load
            Animation2dGraphNodeProperties result = new Animation2dGraphNodeProperties();

            if (File.Exists(Application.dataPath + "/Animations/" + animationGraphName + ".xml"))
            {
                XmlDocument animationPropertiesXml = new XmlDocument();
                animationPropertiesXml.Load(Application.dataPath + "/Animations/" + animationGraphName + ".xml");

                XmlElement animationPropertiesRoot = animationPropertiesXml.DocumentElement;

                if (null != animationPropertiesRoot)
                {
                    Dictionary<string, Animation2dGraphNodeProperties> animationGraphNodesById = CreateAnimationGraphNodes(animationPropertiesRoot);
                }
                else
                {
                    throw new AssetLoadFailureException();
                }                
            }
            else
            {
                throw new AssetLoadFailureException();
            }

            return result;
        }

        public Dictionary<string, Animation2dGraphNodeProperties> CreateAnimationGraphNodes(XmlElement animationPropertiesRoot)
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