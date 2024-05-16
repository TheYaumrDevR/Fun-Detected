using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Core
{
    public class MeleeAttack
    {
        private List<HitboxTilePosition> hitArc;

        private StopWatch lastStartOfAttackStopWatch;

        private double timeToHitFromStartOfAttack;

        public bool AttackWasCancelled
        {
            get;
            private set;
        }       

        private bool attackWasQueued; 

        private AsyncResponse<List<Enemy>> enemiesHitResponse;

        public MeleeAttack(List<HitboxTilePosition> hitArc, double timeToHitFromStartOfAttack)
        {
            lastStartOfAttackStopWatch = new StopWatch();

            this.hitArc = hitArc;
            this.timeToHitFromStartOfAttack = timeToHitFromStartOfAttack;
        }

        public void Tick(double actionTime)
        {
            lastStartOfAttackStopWatch.Tick(actionTime);

            if (attackWasQueued)
            {
                if (lastStartOfAttackStopWatch.TimePassedSinceStart >= timeToHitFromStartOfAttack)
                {
                    attackWasQueued = false;

                    List<Enemy> enemiesHit = Area.ActiveArea.GetEnemiesHit(hitArc);
                    enemiesHitResponse.SetResponseObject(enemiesHit);
                }
            }
        }

        public AsyncResponse<List<Enemy>> Start(double attacksPerSecond)
        {
            AsyncResponse<List<Enemy>> result = new AsyncResponse<List<Enemy>>();
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
    }
}