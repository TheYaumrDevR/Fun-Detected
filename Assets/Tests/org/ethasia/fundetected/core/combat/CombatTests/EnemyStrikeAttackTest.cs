using NUnit.Framework;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Ioadapters.Mocks;

namespace Org.Ethasia.Fundetected.Core.Combat.Tests
{
    public class EnemyStrikeAttackTest
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
        public void TestTickStrikeHitsWhenHitTileIsInsidePlayerHitBox()
        {
            Area.ActiveArea = CreateArea();
            Area.ActiveArea.SpawnPlayer(CreatePlayerCharacter());

            Position positionOffsetToAttackerCenter = new Position(2, 1);

            EnemyStrikeAttack testCandidate = new EnemyStrikeAttack
                .EnemyStrikeAttackBuilder()
                .SetAttackHitArea(CreateEnemyHitArc())
                .SetAttacker(CreateEnemy())
                .SetPositionOffsetToAttackerCenter(positionOffsetToAttackerCenter)
                .SetTimeToHitFromStartOfAttack(0.4)
                .Build();
            
            AsyncResponse<bool> enemyHitResponse = testCandidate.Start(2.0);

            enemyHitResponse.OnResponseReceived((playerWasHit) => 
            {
                Assert.IsTrue(playerWasHit);
            });

            testCandidate.Tick(0.6);            
        }

        [Test]
        public void TestTickStrikeDoesNotHitWhenHitTileIsOutsidePlayerHitBox()
        {
            Area.ActiveArea = CreateArea();
            Area.ActiveArea.SpawnPlayer(CreatePlayerCharacter());

            Position positionOffsetToAttackerCenter = new Position(1, 1);

            EnemyStrikeAttack testCandidate = new EnemyStrikeAttack
                .EnemyStrikeAttackBuilder()
                .SetAttackHitArea(CreateEnemyHitArc())
                .SetAttacker(CreateEnemy())
                .SetPositionOffsetToAttackerCenter(positionOffsetToAttackerCenter)
                .SetTimeToHitFromStartOfAttack(0.4)
                .Build();
            
            AsyncResponse<bool> enemyHitResponse = testCandidate.Start(2.0);

            enemyHitResponse.OnResponseReceived((playerWasHit) => 
            {
                Assert.IsFalse(playerWasHit);
            });

            testCandidate.Tick(0.6);            
        }        

        [Test]
        public void TestTickTimeToHitHasNotPassedPlayerIsNotHit()
        {
            Area.ActiveArea = CreateArea();
            Area.ActiveArea.SpawnPlayer(CreatePlayerCharacter());

            Position positionOffsetToAttackerCenter = new Position(2, 1);

            EnemyStrikeAttack testCandidate = new EnemyStrikeAttack
                .EnemyStrikeAttackBuilder()
                .SetAttackHitArea(CreateEnemyHitArc())
                .SetAttacker(CreateEnemy())
                .SetPositionOffsetToAttackerCenter(positionOffsetToAttackerCenter)
                .SetTimeToHitFromStartOfAttack(0.4)
                .Build();
            
            AsyncResponse<bool> enemyHitResponse = testCandidate.Start(2.0);

            bool hitCalculationWasDone = false;

            enemyHitResponse.OnResponseReceived((playerWasHit) => 
            {
                hitCalculationWasDone = true;
            });

            testCandidate.Tick(0.3);    

            Assert.That(hitCalculationWasDone, Is.False);   
        }        

        [Test]
        public void TestTickAttackTwiceInARowSecondAttackDoesNotLandIfTimeBetweenAttacksIsShorterThanAttackSpeed()
        {
            Area.ActiveArea = CreateArea();
            Area.ActiveArea.SpawnPlayer(CreatePlayerCharacter());

            Position positionOffsetToAttackerCenter = new Position(2, 1);

            EnemyStrikeAttack testCandidate = new EnemyStrikeAttack
                .EnemyStrikeAttackBuilder()
                .SetAttackHitArea(CreateEnemyHitArc())
                .SetAttacker(CreateEnemy())
                .SetPositionOffsetToAttackerCenter(positionOffsetToAttackerCenter)
                .SetTimeToHitFromStartOfAttack(0.4)
                .Build();
            
            AsyncResponse<bool> enemyFirstHitResponse = testCandidate.Start(1.0);

            enemyFirstHitResponse.OnResponseReceived((playerWasHit) => 
            {
                Assert.IsTrue(playerWasHit);
            });

            testCandidate.Tick(0.6);    

            AsyncResponse<bool> enemySecondHitResponse = testCandidate.Start(1.0);

            enemySecondHitResponse.OnResponseReceived((playerWasHit) => 
            {
                Assert.IsFalse(playerWasHit);
            });

            testCandidate.Tick(0.1);    
        }

        private PlayerCharacter CreatePlayerCharacter()
        {
            BoundingBox playerHitBox = new BoundingBox
                .Builder()
                .SetDistanceToLeftEdge(0)
                .SetDistanceToRightEdge(0)
                .SetDistanceToBottomEdge(0)
                .SetDistanceToTopEdge(0)
                .Build();

            PlayerCharacterBaseStats baseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .SetAttacksPerSecond(1.0)
                .Build();

            MeleeHitArcProperties meleeHitArcProperties = new MeleeHitArcProperties();

            meleeHitArcProperties.HitArcRadius = 1;             

            return new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(baseStats)
                .SetMeleeHitArcProperties(meleeHitArcProperties)
                .Build();  
        }

        private Area CreateArea()
        {
            return new Area.Builder()
                .SetWidthAndHeight(30, 50)
                .SetPlayerSpawnPosition(new Position(9, 4))
                .Build();
        }

        private Enemy CreateEnemy()
        {
            return new Enemy
                .Builder()
                .SetPosition(new Position(7, 3))
                .SetLife(12)
                .SetAttacksPerSecond(2.0f)
                .Build();
        }

        private List<HitboxTilePosition> CreateEnemyHitArc()
        {
            List<HitboxTilePosition> result = new List<HitboxTilePosition>();

            result.Add(new HitboxTilePosition(0, 0));

            return result;
        }
    }
}