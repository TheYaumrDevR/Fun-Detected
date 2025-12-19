using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Combat
{
    public class MeleeAttack
    {
        private List<HitboxTilePosition> hitArcRightSwing;

        private Position positionOffsetRightSwingToPlayerCharacterCenter;

        private StopWatch lastStartOfAttackStopWatch;

        private double timeToHitFromStartOfAttack;

        public bool AttackWasCancelled
        {
            get;
            private set;
        }       

        private bool attackWasQueued; 

        private AsyncResponse<HashSet<Enemy>> enemiesHitResponse;

        private int originalAttackRange;

        private int additionalAttackRange;

        private double hitArcStartAngle;

        private double hitArcEndAngle;

        private MeleeAttack()
        {
            lastStartOfAttackStopWatch = new StopWatch();
        }

        public void SetAdditionalAttackRange(int value)
        {
            additionalAttackRange = value;
            CalculateHitArc();
        }

        public void Tick(double actionTime)
        {
            lastStartOfAttackStopWatch.Tick(actionTime);

            if (attackWasQueued)
            {
                if (lastStartOfAttackStopWatch.TimePassedSinceStart >= timeToHitFromStartOfAttack)
                {
                    attackWasQueued = false;

                    HashSet<Enemy> enemiesHit = Area.ActiveArea.GetEnemiesHit(hitArcRightSwing, positionOffsetRightSwingToPlayerCharacterCenter);
                    enemiesHitResponse.SetResponseObject(enemiesHit);
                }
            }
        }

        public AsyncResponse<HashSet<Enemy>> Start(double attacksPerSecond)
        {
            AsyncResponse<HashSet<Enemy>> result = new AsyncResponse<HashSet<Enemy>>();
            enemiesHitResponse = result;

            if (EnoughTimePassedForTheNextAttackToBeExecuted(attacksPerSecond))
            {
                lastStartOfAttackStopWatch.Reset();
                AttackWasCancelled = false;

                attackWasQueued = true;
            }

            return result;
        }

        public void Cancel()
        {
            AttackWasCancelled = true;
            attackWasQueued = false;
        }

        public bool EnoughTimePassedForTheNextAttackToBeExecuted(double attacksPerSecond)
        {
            double secondsPerAttack = 1.0 / attacksPerSecond;
            return !lastStartOfAttackStopWatch.WasReset || lastStartOfAttackStopWatch.TimePassedSinceStart >= secondsPerAttack || AttackWasCancelled;            
        }      

        private void CalculateHitArc()
        {
            BresenhamBasedHitArcGenerationAlgorithm hitArcGenerator = new BresenhamBasedHitArcGenerationAlgorithm();
            hitArcGenerator.CreateFilledCircleArc(hitArcStartAngle, hitArcEndAngle, originalAttackRange + additionalAttackRange);

            hitArcRightSwing = hitArcGenerator.HitboxTilePositionsRight;
        }

        public class MeleeAttackBuilder
        {
            private double timeToHitFromStartOfAttack;
            private Position positionOffsetRightSwingToPlayerCharacterCenter;
            private int originalAttackRange;
            private int additionalAttackRange;
            private double hitArcStartAngle;
            private double hitArcEndAngle;

            public MeleeAttackBuilder SetTimeToHitFromStartOfAttack(double value)
            {
                timeToHitFromStartOfAttack = value;
                return this;
            }

            public MeleeAttackBuilder SetPositionOffsetRightSwingToPlayerCharacterCenter(Position value)
            {
                positionOffsetRightSwingToPlayerCharacterCenter = value;
                return this;
            }

            public MeleeAttackBuilder SetOriginalAttackRange(int value)
            {
                originalAttackRange = value;
                return this;
            }

            public MeleeAttackBuilder SetAdditionalAttackRange(int value)
            {
                additionalAttackRange = value;
                return this;
            }

            public MeleeAttackBuilder SetHitArcStartAngle(double value)
            {
                hitArcStartAngle = value;
                return this;
            }

            public MeleeAttackBuilder SetHitArcEndAngle(double value)
            {
                hitArcEndAngle = value;
                return this;
            }

            public MeleeAttack Build()
            {
                MeleeAttack result = new MeleeAttack();

                result.timeToHitFromStartOfAttack = timeToHitFromStartOfAttack;
                result.positionOffsetRightSwingToPlayerCharacterCenter = positionOffsetRightSwingToPlayerCharacterCenter;
                result.originalAttackRange = originalAttackRange;
                result.additionalAttackRange = additionalAttackRange;
                result.hitArcStartAngle = hitArcStartAngle;
                result.hitArcEndAngle = hitArcEndAngle;

                result.CalculateHitArc();

                return result;
            }
        } 
    }
}