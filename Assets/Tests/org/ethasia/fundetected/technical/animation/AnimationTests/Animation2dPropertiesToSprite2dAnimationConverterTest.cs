using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Ioadapters.Animation;

namespace Org.Ethasia.Fundetected.Technical.Animation.Tests
{
    public class Animation2dPropertiesToSprite2dAnimationConverterTest
    {

        [Test]
        public void TestConvertAnimation2dGraphToStateMachineNodesCreatesAllNodes()
        {
            // Arrange
            var idleNode = new Animation2dGraphNodeProperties(true);
            idleNode.Name = "idle";
            idleNode.Animation = new Animation2dProperties("EnemyIdle", true);
            idleNode.AnimationSpeedMultiplier = 1.0f;

            var walkNode = new Animation2dGraphNodeProperties(false);
            walkNode.Name = "walk";
            walkNode.Animation = new Animation2dProperties("EnemyWalk", true);
            walkNode.AnimationSpeedMultiplier = 1.0f;  

            var jumpNode = new Animation2dGraphNodeProperties(false);
            jumpNode.Name = "jump";
            jumpNode.Animation = new Animation2dProperties("EnemyJump", false);
            jumpNode.AnimationSpeedMultiplier = 1.0f;  

            idleNode.Transitions.Add("walk", walkNode);
            idleNode.Transitions.Add("jump", jumpNode);      
            walkNode.Transitions.Add("idle", idleNode);
            walkNode.Transitions.Add("jump", jumpNode);
            jumpNode.Transitions.Add("idle", idleNode);
            jumpNode.Transitions.Add("walk", walkNode);              

            var spriteRenderer = new SpriteRenderer();

            // Act
            var result = Animation2dPropertiesToSprite2dAnimationConverter.ConvertAnimation2dGraphToStateMachineNodes(idleNode, spriteRenderer);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result["idle"], Is.Not.Null);
            Assert.That(result["walk"], Is.Not.Null);
            Assert.That(result["jump"], Is.Not.Null);
        }
    }
}