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
            idleNode.Animation.AnimationFrames.Add(new Animation2dFrameProperties(0, false));
            idleNode.Animation.AnimationFrames.Add(new Animation2dFrameProperties(1, false));
            idleNode.Animation.AnimationFrames.Add(new Animation2dFrameProperties(2, false));

            var walkNode = new Animation2dGraphNodeProperties(false);
            walkNode.Name = "walk";
            walkNode.Animation = new Animation2dProperties("EnemyWalk", true);
            walkNode.AnimationSpeedMultiplier = 1.0f;  
            walkNode.Animation.AnimationFrames.Add(new Animation2dFrameProperties(0, false));
            walkNode.Animation.AnimationFrames.Add(new Animation2dFrameProperties(1, false));
            walkNode.Animation.AnimationFrames.Add(new Animation2dFrameProperties(2, false));

            var jumpNode = new Animation2dGraphNodeProperties(false);
            jumpNode.Name = "jump";
            jumpNode.Animation = new Animation2dProperties("EnemyJump", false);
            jumpNode.AnimationSpeedMultiplier = 1.0f;  
            jumpNode.Animation.AnimationFrames.Add(new Animation2dFrameProperties(0, false));
            jumpNode.Animation.AnimationFrames.Add(new Animation2dFrameProperties(1, false));
            jumpNode.Animation.AnimationFrames.Add(new Animation2dFrameProperties(2, false));

            idleNode.Transitions.Add("walk", walkNode);
            idleNode.Transitions.Add("jump", jumpNode);      
            walkNode.Transitions.Add("idle", idleNode);
            walkNode.Transitions.Add("jump", jumpNode);
            jumpNode.Transitions.Add("idle", idleNode);
            jumpNode.Transitions.Add("walk", walkNode);              

            var spriteRenderer = new SpriteRenderer();

            // Act
            var result = Animation2dPropertiesToSprite2dAnimationConverter.ConvertAnimation2dGraphNodePropertiesToStateMachine(idleNode, spriteRenderer, new Sprite2dAnimatorBehavior());

            // Assert
            Assert.That(result.CanExecuteAction("walk"), Is.True);
            Assert.That(result.CanExecuteAction("jump"), Is.True);

            result.ExecuteAction("walk");

            Assert.That(result.CanExecuteAction("idle"), Is.True);
            Assert.That(result.CanExecuteAction("jump"), Is.True);

            result.ExecuteAction("jump");

            Assert.That(result.CanExecuteAction("idle"), Is.True);
            Assert.That(result.CanExecuteAction("walk"), Is.True);

            result.ExecuteAction("idle");
        }
    }
}