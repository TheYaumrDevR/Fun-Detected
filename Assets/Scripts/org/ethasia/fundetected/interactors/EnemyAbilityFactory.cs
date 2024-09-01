using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Maths;

using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class EnemyAbilityFactory
    {
        public static EnemyAbility FromMasterData(UnarmedAsymmetricSwingAbilityMasterData masterData, Enemy enemy)
        {
            EnemyStrikeAttack leftStrikeAttack = CreateEnemyStrikeAttackFromUnarmedSwingMasterData(masterData.LeftSwingData, enemy);
            EnemyStrikeAttack rightStrikeAttack = CreateEnemyStrikeAttackFromUnarmedSwingMasterData(masterData.RightSwingData, enemy);

            return new EnemyStrikeAttackWithAsymmetricLeftRight.EnemyStrikeAttackWithAsymmetricLeftRightBuilder()
                .SetAttacker(enemy)
                .SetLeftStrikeAttack(leftStrikeAttack)
                .SetRightStrikeAttack(rightStrikeAttack)
                .Build();
        }

        private static EnemyStrikeAttack CreateEnemyStrikeAttackFromUnarmedSwingMasterData(UnarmedSwingAbilityMasterData masterData, Enemy enemy)
        {
            List<HitboxTilePosition> hitBoxTilePositions = CreateHitBoxTilePositionsFromSwingAbilityMasterData(masterData);
            Position positionOffsetToAttackerCenter = new Position(masterData.HitArcCenterXOffset, masterData.HitArcCenterYOffset);

            return new EnemyStrikeAttack.EnemyStrikeAttackBuilder()
                .SetAttackHitArea(hitBoxTilePositions)
                .SetAttacker(enemy)
                .SetTimeToHitFromStartOfAttack(masterData.DefaultTimeToHit)
                .SetPositionOffsetToAttackerCenter(positionOffsetToAttackerCenter)
                .Build();
        }

        private static List<HitboxTilePosition> CreateHitBoxTilePositionsFromSwingAbilityMasterData(UnarmedSwingAbilityMasterData masterData)
        {
            BresenhamBasedHitArcGenerationAlgorithm hitArcGenerator = new BresenhamBasedHitArcGenerationAlgorithm();
            hitArcGenerator.CreateFilledCircleArc(masterData.HitArcStartAngle, masterData.HitArcEndAngle, masterData.HitArcRadius);   

            return hitArcGenerator.HitboxTilePositionsRight;     
        }
    }
}