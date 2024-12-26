using NUnit.Framework;
using System;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Ioadapters.Mocks;

namespace Org.Ethasia.Fundetected.Core.Combat.Tests
{
    public class EnemyStrikeAttackWithAsymmetricLeftRightTest
    {
        [OneTimeSetUp]
        public void SetupPlayerCharacter()
        {
            IoAdaptersFactoryForCore.SetInstance(new MockedIoAdaptersFactoryForCore());

            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetPlayerSpawnPosition(new Position(15, 20))
                .Build();

            Area.ActiveArea = testArea;       

            PlayerCharacterBaseStats baseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .SetAttacksPerSecond(1.0)
                .Build();

            PlayerCharacter playerCharacter = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(baseStats)
                .SetMeleeHitArcProperties(new MeleeHitArcProperties())
                .Build();  
                
            testArea.SpawnPlayer(playerCharacter);
        }

        [Test]
        public void TestStartNotEnoughTimeSinceLastAttackDoesNotAttack()
        {
            Position enemyPosition = new Position(20, 20);
            Enemy enemy = CreateEnemy(enemyPosition);

            EnemyStrikeAttackWithAsymmetricLeftRight.EnemyStrikeAttackWithAsymmetricLeftRightBuilder testCandidateBuilder = CreateTestCandidateBuilder(enemy);

            EnemyStrikeAttackMock leftStrikeAttackMock = new EnemyStrikeAttackMock();
            EnemyStrikeAttackMock rightStrikeAttackMock = new EnemyStrikeAttackMock();

            EnemyStrikeAttackWithAsymmetricLeftRight testCandidate = testCandidateBuilder
                .SetLeftStrikeAttack(leftStrikeAttackMock)
                .SetRightStrikeAttack(rightStrikeAttackMock)
                .Build();

            AsyncResponse<bool> result = testCandidate.Start(1.2);

            Assert.That(result.ResponseReceived, Is.True); 

            bool callBackResponse = true;

            result.OnResponseReceived((response) => 
            {
                callBackResponse = response;
            });

            Assert.That(callBackResponse, Is.False);
        }

        [Test]
        public void TestStartPlayerIsToTheLeftStrikesLeft()
        {
            Position enemyPosition = new Position(20, 20);

            Enemy enemy = CreateEnemy(enemyPosition);
            EnemyStrikeAttackWithAsymmetricLeftRight.EnemyStrikeAttackWithAsymmetricLeftRightBuilder testCandidateBuilder = CreateTestCandidateBuilder(enemy);

            EnemyStrikeAttackMock leftStrikeAttackMock = new EnemyStrikeAttackMock();
            EnemyStrikeAttackMock rightStrikeAttackMock = new EnemyStrikeAttackMock();

            leftStrikeAttackMock.EnoughTimePassedSinceLastAttack = true;
            rightStrikeAttackMock.EnoughTimePassedSinceLastAttack = true;

            bool leftStrikeWasStarted = false;
            bool rightStrikeWasStarted = false;

            leftStrikeAttackMock.OnStart(() => 
            {
                leftStrikeWasStarted = true;
            });

            rightStrikeAttackMock.OnStart(() => 
            {
                rightStrikeWasStarted = true;
            });            

            EnemyStrikeAttackWithAsymmetricLeftRight testCandidate = testCandidateBuilder
                .SetLeftStrikeAttack(leftStrikeAttackMock)
                .SetRightStrikeAttack(rightStrikeAttackMock)
                .Build();

            testCandidate.Start(1.2);

            Assert.That(leftStrikeWasStarted, Is.True);
            Assert.That(rightStrikeWasStarted, Is.False);
        } 

        [Test]
        public void TestStartPlayerIsToTheRightStrikesRight()
        {
            Position enemyPosition = new Position(5, 20);
            
            Enemy enemy = CreateEnemy(enemyPosition);
            EnemyStrikeAttackWithAsymmetricLeftRight.EnemyStrikeAttackWithAsymmetricLeftRightBuilder testCandidateBuilder = CreateTestCandidateBuilder(enemy);

            EnemyStrikeAttackMock leftStrikeAttackMock = new EnemyStrikeAttackMock();
            EnemyStrikeAttackMock rightStrikeAttackMock = new EnemyStrikeAttackMock();

            leftStrikeAttackMock.EnoughTimePassedSinceLastAttack = true;
            rightStrikeAttackMock.EnoughTimePassedSinceLastAttack = true;

            bool leftStrikeWasStarted = false;
            bool rightStrikeWasStarted = false;

            leftStrikeAttackMock.OnStart(() => 
            {
                leftStrikeWasStarted = true;
            });

            rightStrikeAttackMock.OnStart(() => 
            {
                rightStrikeWasStarted = true;
            });            

            EnemyStrikeAttackWithAsymmetricLeftRight testCandidate = testCandidateBuilder
                .SetLeftStrikeAttack(leftStrikeAttackMock)
                .SetRightStrikeAttack(rightStrikeAttackMock)
                .Build();

            testCandidate.Start(1.2);

            Assert.That(leftStrikeWasStarted, Is.False);
            Assert.That(rightStrikeWasStarted, Is.True);
        }               

        private Enemy CreateEnemy(Position enemyPosition)
        {
            return new Enemy
                .Builder()
                .SetLife(10)
                .SetPosition(enemyPosition)
                .SetUnarmedStrikeRange(5)
                .SetIsAggressiveOnSight(true)
                .SetAttacksPerSecond(1.2f)
                .SetMinToMaxPhysicalDamage(new DamageRange(1, 3))
                .Build();
        }         

        private EnemyStrikeAttackWithAsymmetricLeftRight.EnemyStrikeAttackWithAsymmetricLeftRightBuilder CreateTestCandidateBuilder(Enemy enemy)
        {
            HitboxTilePosition hitBoxTilePosition = new HitboxTilePosition(0, 0);

            List<HitboxTilePosition> hitBoxTilePositions = new List<HitboxTilePosition>();
            hitBoxTilePositions.Add(hitBoxTilePosition);

            return new EnemyStrikeAttackWithAsymmetricLeftRight
                .EnemyStrikeAttackWithAsymmetricLeftRightBuilder()
                .SetAttacker(enemy);       
        }         

        private class EnemyStrikeAttackMock : EnemyStrikeAttack
        {
            private Action startCallBack;
            public bool EnoughTimePassedSinceLastAttack;

            public void OnStart(Action callback)
            {
                startCallBack = callback;
            }

            public override AsyncResponse<bool> Start(double attacksPerSecond)
            {
                if (null != startCallBack)
                {
                    startCallBack();
                }

                return new AsyncResponse<bool>();
            }

            public override bool EnoughTimePassedForTheNextAttackToBeExecuted(double attacksPerSecond)
            {
                return EnoughTimePassedSinceLastAttack;
            }
        }
    }
}