using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Interactors.Presentation;
using Org.Ethasia.Fundetected.Ioadapters.Animation;
using Org.Ethasia.Fundetected.Technical.Mocks;

namespace Org.Ethasia.Fundetected.Technical.Animation.Tests
{
    public class Animation2dPropertiesToSprite2dAnimationConverterTest
    {
        private List<GameObject> createdGameObjects = new List<GameObject>();
        private InternalTechnicalFactory previousInternalTechnicalFactory;
        private ResourceLoaderMock resourceLoaderMock;
        private Material customMaterial;

        [SetUp]
        public void SetUpMaterialMocks()
        {
            previousInternalTechnicalFactory = InternalTechnicalFactory.GetInstance();

            customMaterial = new Material(Shader.Find("Sprites/Default"));
            resourceLoaderMock = new ResourceLoaderMock();
            resourceLoaderMock.AddMaterial("Materials/PlayerGhost", customMaterial);

            InternalTechnicalFactory.SetInstance(new InternalTechnicalMockFactory(resourceLoaderMock));
        }

        [TearDown]
        public void TearDown()
        {
            foreach (GameObject gameObject in createdGameObjects)
            {
                Object.DestroyImmediate(gameObject);
            }

            createdGameObjects.Clear();
        }

        [TearDown]
        public void TearDownMaterialMocks()
        {
            InternalTechnicalFactory.SetInstance(previousInternalTechnicalFactory);
            Object.DestroyImmediate(customMaterial);
        }

        [Test]
        public void TestConvertAnimation2dGraphToStateMachineNodesCreatesAllNodes()
        {
            // Arrange
            var idleNode = CreateNode("idle", true, "EnemyIdle", true, 1.0f, 3);
            var walkNode = CreateNode("walk", false, "EnemyWalk", true, 1.0f, 3);
            var jumpNode = CreateNode("jump", false, "EnemyJump", false, 1.0f, 3);

            idleNode.Transitions.Add("walk", walkNode);
            idleNode.Transitions.Add("jump", jumpNode);      
            walkNode.Transitions.Add("idle", idleNode);
            walkNode.Transitions.Add("jump", jumpNode);
            jumpNode.Transitions.Add("idle", idleNode);
            jumpNode.Transitions.Add("walk", walkNode);              

            var spriteRenderer = CreateSpriteRenderer();

            var stateMachineConversionContext = CreateConversionContext(idleNode, spriteRenderer);        

            // Act
            var result = Animation2dPropertiesToSprite2dAnimationConverter.ConvertAnimation2dGraphNodePropertiesToStateMachine(stateMachineConversionContext);

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

        [Test]
        public void TestConvertAnimation2dGraphNodePropertiesToStateMachineAppliesAttackSpeedBinding()
        {
            // Arrange
            var idleNode = CreateNode("idle", true, "EnemyIdle", true, 1.0f, 1);
            var attackNode = CreateNode("attack", false, "EnemyAttack", false, 2.0f, 1);
            attackNode.AnimationSpeedMultiplierBinding = AnimationSpeedStatBindings.ATTACK_SPEED_RIGHT;

            idleNode.Transitions.Add("attack", attackNode);
            attackNode.Transitions.Add("idle", idleNode);

            var spriteRenderer = CreateSpriteRenderer();
            var animatorContainer = new Sprite2dAnimatorBehavior();

            Animation2dPropertiesToSprite2dAnimationConverter.StateMachineConversionContext stateMachineConversionContext = new Animation2dPropertiesToSprite2dAnimationConverter.StateMachineConversionContext();
            stateMachineConversionContext.ToConvert = idleNode;
            stateMachineConversionContext.SpriteRenderer = spriteRenderer;
            stateMachineConversionContext.Sprite2dAnimatorContainer = animatorContainer;
            stateMachineConversionContext.AnimatedObjectId = "";
            stateMachineConversionContext.AnimationSpeedMultiplierFromStatBindingProvider = (binding) =>
            {
                if (binding == AnimationSpeedStatBindings.ATTACK_SPEED_RIGHT)
                {
                    return 3.0f;
                }

                return 1.0f;
            };

            // Act
            var result = Animation2dPropertiesToSprite2dAnimationConverter.ConvertAnimation2dGraphNodePropertiesToStateMachine(stateMachineConversionContext);
            result.ExecuteAction("attack");

            // Assert
            Assert.That(animatorContainer.AnimatorHasSpeedMultiplier(6.0f), Is.True);
        }

        [Test]
        public void TestConvertAnimation2dGraphNodePropertiesToStateMachineDefaultsToMultiplierOfOneWhenNoStatBindingSet()
        {
            // Arrange
            var idleNode = CreateNode("idle", true, "EnemyIdle", true, 1.0f, 1);
            var attackNode = CreateNode("attack", false, "EnemyAttack", false, 2.0f, 1);

            idleNode.Transitions.Add("attack", attackNode);
            attackNode.Transitions.Add("idle", idleNode);

            var spriteRenderer = CreateSpriteRenderer();
            var animatorContainer = new Sprite2dAnimatorBehavior();

            Animation2dPropertiesToSprite2dAnimationConverter.StateMachineConversionContext stateMachineConversionContext = new Animation2dPropertiesToSprite2dAnimationConverter.StateMachineConversionContext();
            stateMachineConversionContext.ToConvert = idleNode;
            stateMachineConversionContext.SpriteRenderer = spriteRenderer;
            stateMachineConversionContext.Sprite2dAnimatorContainer = animatorContainer;
            stateMachineConversionContext.AnimatedObjectId = "";
            stateMachineConversionContext.AnimationSpeedMultiplierFromStatBindingProvider = (binding) =>
            {
                return 5.0f;
            };

            // Act
            var result = Animation2dPropertiesToSprite2dAnimationConverter.ConvertAnimation2dGraphNodePropertiesToStateMachine(stateMachineConversionContext);
            result.ExecuteAction("attack");

            // Assert
            Assert.That(animatorContainer.AnimatorHasSpeedMultiplier(2.0f), Is.True);
        }

        [Test]
        public void TestConvertAnimation2dGraphNodePropertiesToStateMachineCreatesMaterialApplierThatAppliesAndRestoresMaterials()
        {
            // Arrange
            var idleNode = CreateNode("idle", true, "EnemyIdle", true, 1.0f, 1);
            var deadNode = CreateNode("dead", false, "EnemyIdle", true, 1.0f, 1);
            deadNode.MaterialName = "Materials/PlayerGhost";

            idleNode.Transitions.Add("dead", deadNode);
            deadNode.Transitions.Add("idle", idleNode);

            var spriteRenderer = CreateSpriteRenderer();
            Material defaultMaterial = spriteRenderer.sharedMaterial;

            var context = CreateConversionContext(idleNode, spriteRenderer);

            // Act
            var result = Animation2dPropertiesToSprite2dAnimationConverter.ConvertAnimation2dGraphNodePropertiesToStateMachine(context);

            // Assert
            Assert.That(spriteRenderer.sharedMaterial, Is.EqualTo(defaultMaterial));

            result.ExecuteAction("dead");
            Assert.That(spriteRenderer.sharedMaterial, Is.EqualTo(customMaterial));

            result.ExecuteAction("idle");
            Assert.That(spriteRenderer.sharedMaterial, Is.EqualTo(defaultMaterial));
        }

        [Test]
        public void TestConvertAnimation2dGraphNodePropertiesToStateMachineAppliesMaterialOfInitialNode()
        {
            // Arrange
            var idleNode = CreateNode("idle", true, "EnemyIdle", true, 1.0f, 1);
            idleNode.MaterialName = "Materials/PlayerGhost";

            var spriteRenderer = CreateSpriteRenderer();

            var context = CreateConversionContext(idleNode, spriteRenderer);

            // Act
            Animation2dPropertiesToSprite2dAnimationConverter.ConvertAnimation2dGraphNodePropertiesToStateMachine(context);

            // Assert
            Assert.That(spriteRenderer.sharedMaterial, Is.EqualTo(customMaterial));
        }

        [Test]
        public void TestConvertAnimation2dGraphNodePropertiesToStateMachineFallsBackToDefaultMaterialWhenMaterialPathIsWrong()
        {
            // Arrange
            var idleNode = CreateNode("idle", true, "EnemyIdle", true, 1.0f, 1);
            var deadNode = CreateNode("dead", false, "EnemyIdle", true, 1.0f, 1);
            deadNode.MaterialName = "Materials/DoesNotExist";

            idleNode.Transitions.Add("dead", deadNode);
            deadNode.Transitions.Add("idle", idleNode);

            var spriteRenderer = CreateSpriteRenderer();
            Material defaultMaterial = spriteRenderer.sharedMaterial;

            var context = CreateConversionContext(idleNode, spriteRenderer);

            // Act
            var result = Animation2dPropertiesToSprite2dAnimationConverter.ConvertAnimation2dGraphNodePropertiesToStateMachine(context);
            result.ExecuteAction("dead");

            // Assert
            Assert.That(spriteRenderer.sharedMaterial, Is.EqualTo(defaultMaterial));
        }

        private Animation2dPropertiesToSprite2dAnimationConverter.StateMachineConversionContext CreateConversionContext(Animation2dGraphNodeProperties initialNode, SpriteRenderer spriteRenderer, Sprite2dAnimatorBehavior animatorContainer = null)
        {
            Animation2dPropertiesToSprite2dAnimationConverter.StateMachineConversionContext result = new Animation2dPropertiesToSprite2dAnimationConverter.StateMachineConversionContext();
            result.ToConvert = initialNode;
            result.SpriteRenderer = spriteRenderer;
            result.Sprite2dAnimatorContainer = animatorContainer ?? new Sprite2dAnimatorBehavior();
            result.AnimatedObjectId = "";

            return result;
        }

        private SpriteRenderer CreateSpriteRenderer()
        {
            GameObject gameObject = new GameObject();
            createdGameObjects.Add(gameObject);

            return gameObject.AddComponent<SpriteRenderer>();
        }

        private static Animation2dGraphNodeProperties CreateNode(string animationName, bool isDefault, string spriteImageName, bool loops, float animationSpeedMultiplier, int frameCount)
        {
            var node = new Animation2dGraphNodeProperties(isDefault);
            node.Name = animationName;
            node.Animation = new Animation2dProperties(spriteImageName, loops);
            node.AnimationSpeedMultiplier = animationSpeedMultiplier;

            for (int i = 0; i < frameCount; i++)
            {
                node.Animation.AnimationFrames.Add(new Animation2dFrameProperties(i, false));
            }

            return node;
        }
    }
}