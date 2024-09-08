using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Core.Combat
{
    public class EnemyStrikeAttack
    {
        private List<HitboxTilePosition> attackHitArea;
        private Enemy attacker;
        private Position positionOffsetToAttackerCenter;
        private StopWatch lastStartOfAttackStopWatch;
        private double timeToHitFromStartOfAttack;
        private bool attackWasQueued; 
        private AsyncResponse<bool> playerWasHitResponse;

        private EnemyStrikeAttack()
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

                    int playerX = Area.ActiveArea.GetPlayerPositionX();
                    int playerY = Area.ActiveArea.GetPlayerPositionY();
                    BoundingBox playerHitBox = Area.ActiveArea.Player.BoundingBox;

                    int hitArcCenterOffsetX = attacker.Position.X + positionOffsetToAttackerCenter.X;
                    int hitArcCenterOffsetY = attacker.Position.Y + positionOffsetToAttackerCenter.Y;

                    foreach (HitboxTilePosition hitArcTile in attackHitArea)
                    {               
                        HitboxTilePosition offSetHitArcTile = new HitboxTilePosition(hitArcTile.X + hitArcCenterOffsetX, hitArcTile.Y + hitArcCenterOffsetY);

                        if (offSetHitArcTile.X >= playerX - playerHitBox.DistanceToLeftEdge 
                            && offSetHitArcTile.X <= playerX + playerHitBox.DistanceToRightEdge 
                            && offSetHitArcTile.Y >= playerY - playerHitBox.DistanceToBottomEdge 
                            && offSetHitArcTile.Y <= playerY + playerHitBox.DistanceToTopEdge)
                        {
                            playerWasHitResponse.SetResponseObject(true);
                            return;
                        }
                    }     

                    playerWasHitResponse.SetResponseObject(false);
                }
            }
        }

        public AsyncResponse<bool> Start(double attacksPerSecond)
        {
            AsyncResponse<bool> result = new AsyncResponse<bool>();         

            if (EnoughTimePassedForTheNextAttackToBeExecuted(attacksPerSecond))
            {
                playerWasHitResponse = result;

                lastStartOfAttackStopWatch.Reset();

                attackWasQueued = true;
            }
            else
            {
                result.SetResponseObject(false);
            }

            return result;
        }

        public bool EnoughTimePassedForTheNextAttackToBeExecuted(double attacksPerSecond)
        {
            double secondsPerAttack = 1.0 / attacksPerSecond;
            return !lastStartOfAttackStopWatch.WasReset || lastStartOfAttackStopWatch.TimePassedSinceStart >= secondsPerAttack;            
        }          

        public class EnemyStrikeAttackBuilder
        {
            private List<HitboxTilePosition> attackHitArea;
            private Enemy attacker;
            private double timeToHitFromStartOfAttack;
            private Position positionOffsetToAttackerCenter;

            public EnemyStrikeAttackBuilder SetAttackHitArea(List<HitboxTilePosition> value)
            {
                attackHitArea = value;
                return this;
            }

            public EnemyStrikeAttackBuilder SetAttacker(Enemy value)
            {
                attacker = value;
                return this;
            }

            public EnemyStrikeAttackBuilder SetTimeToHitFromStartOfAttack(double value)
            {
                timeToHitFromStartOfAttack = value;
                return this;
            }

            public EnemyStrikeAttackBuilder SetPositionOffsetToAttackerCenter(Position value)
            {
                positionOffsetToAttackerCenter = value;
                return this;
            }

            public EnemyStrikeAttack Build()
            {
                EnemyStrikeAttack result = new EnemyStrikeAttack();

                result.attackHitArea = attackHitArea;
                result.attacker = attacker;
                result.timeToHitFromStartOfAttack = timeToHitFromStartOfAttack;
                result.positionOffsetToAttackerCenter = positionOffsetToAttackerCenter;

                return result;
            }
        }                          
    }
}