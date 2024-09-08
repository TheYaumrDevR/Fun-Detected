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

        private MeleeAttack()
        {
            lastStartOfAttackStopWatch = new StopWatch();
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

        public class MeleeAttackBuilder
        {
            private List<HitboxTilePosition> hitArcRightSwing;
            private double timeToHitFromStartOfAttack;
            private Position positionOffsetRightSwingToPlayerCharacterCenter;

            public MeleeAttackBuilder SetHitArcRightSwing(List<HitboxTilePosition> value)
            {
                hitArcRightSwing = value;
                return this;
            }

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

            public MeleeAttack Build()
            {
                MeleeAttack result = new MeleeAttack();

                result.hitArcRightSwing = hitArcRightSwing;
                result.timeToHitFromStartOfAttack = timeToHitFromStartOfAttack;
                result.positionOffsetRightSwingToPlayerCharacterCenter = positionOffsetRightSwingToPlayerCharacterCenter;

                return result;
            }
        } 
    }
}