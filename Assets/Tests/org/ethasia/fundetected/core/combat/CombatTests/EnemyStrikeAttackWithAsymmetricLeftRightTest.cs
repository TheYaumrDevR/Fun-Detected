using NUnit.Framework;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Combat.Tests
{
    public class EnemyStrikeAttackWithAsymmetricLeftRightTest
    {
        [Test]
        public void TestStartNotEnoughTimeSinceLastAttackDoesNotAttack()
        {
            Enemy enemy = CreateEnemy();
            EnemyStrikeAttackWithAsymmetricLeftRight testCandidate = CreateTestCandidate(enemy);

            AsyncResponse<bool> firstResult = testCandidate.Start(1.2);
            AsyncResponse<bool> secondResult = testCandidate.Start(1.2);

            Assert.That(firstResult.ResponseReceived, Is.False); 

            secondResult.OnResponseReceived((response) => 
            {
                Assert.That(response, Is.False);
            });
        }

        private Enemy CreateEnemy()
        {
            Position enemyPosition = new Position(20, 20);            

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

        private EnemyStrikeAttackWithAsymmetricLeftRight CreateTestCandidate(Enemy enemy)
        {
            HitboxTilePosition hitBoxTilePosition = new HitboxTilePosition(0, 0);

            List<HitboxTilePosition> hitBoxTilePositions = new List<HitboxTilePosition>();
            hitBoxTilePositions.Add(hitBoxTilePosition);
            
            EnemyStrikeAttack leftStrikeAttack = new EnemyStrikeAttack
                .EnemyStrikeAttackBuilder()
                .SetAttacker(enemy)
                .SetAttackHitArea(hitBoxTilePositions)
                .SetPositionOffsetToAttackerCenter(new Position(0, 0))
                .Build();

            EnemyStrikeAttack rightStrikeAttack = new EnemyStrikeAttack    
                .EnemyStrikeAttackBuilder()
                .SetAttacker(enemy)
                .SetAttackHitArea(hitBoxTilePositions)
                .SetPositionOffsetToAttackerCenter(new Position(0, 0))
                .Build();

            return new EnemyStrikeAttackWithAsymmetricLeftRight
                .EnemyStrikeAttackWithAsymmetricLeftRightBuilder()
                .SetAttacker(enemy)
                .SetLeftStrikeAttack(leftStrikeAttack)
                .SetRightStrikeAttack(rightStrikeAttack)
                .Build();            
        }         
    }
}