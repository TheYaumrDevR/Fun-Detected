namespace Org.Ethasia.Fundetected.Core
{
    public class EnemyAI
    {
        private bool isAggressiveOnSight;

        public bool IsAggressiveOnSight
        {
            get
            {
                return isAggressiveOnSight;
            }

            private set
            {
                isAggressiveOnSight = value;

                if (isAggressiveOnSight)
                {
                    isAggressive = true;
                }
            }
        }

        public Enemy ManagedEnemy
        {
            get;
            private set;
        }

        private bool isAggressive; 

        public void Update(Area map)
        {
            if (isAggressive && !ManagedEnemy.IsDead())
            {
                PlayerCharacter enemyPlayer = Area.ActiveArea.Player;
                StrikePlayerIfInRangeOrIdle(enemyPlayer, map);
            }
        }

        public void OnHitTaken()
        {
            isAggressive = true;
        }

        private void StrikePlayerIfInRangeOrIdle(PlayerCharacter player, Area map)
        {
            if (PlayerBoundingBoxIsWithingStrikeRange(player, map))
            {
                if (map.GetPlayerPositionX() <= ManagedEnemy.Position.X)
                {
                    ManagedEnemy.StrikeLeft(player);
                } 
                else 
                {
                    ManagedEnemy.StrikeRight(player);
                }
            }
            else
            {
                ManagedEnemy.StartIdling();
            }
        }

        private bool PlayerBoundingBoxIsWithingStrikeRange(PlayerCharacter player, Area map)
        {
            return (map.GetPlayerPositionX() + player.BoundingBox.DistanceToRightEdge >= ManagedEnemy.Position.X - ManagedEnemy.UnarmedStrikeRange
                && map.GetPlayerPositionX() + player.BoundingBox.DistanceToRightEdge <= ManagedEnemy.Position.X + ManagedEnemy.UnarmedStrikeRange
                || map.GetPlayerPositionX() - player.BoundingBox.DistanceToLeftEdge >= ManagedEnemy.Position.X - ManagedEnemy.UnarmedStrikeRange
                && map.GetPlayerPositionX() - player.BoundingBox.DistanceToLeftEdge <= ManagedEnemy.Position.X + ManagedEnemy.UnarmedStrikeRange
                || map.GetPlayerPositionX() - player.BoundingBox.DistanceToLeftEdge < ManagedEnemy.Position.X - ManagedEnemy.UnarmedStrikeRange
                && map.GetPlayerPositionX() + player.BoundingBox.DistanceToRightEdge > ManagedEnemy.Position.X + ManagedEnemy.UnarmedStrikeRange)
                && (map.GetPlayerPositionY() + player.BoundingBox.DistanceToTopEdge >= ManagedEnemy.Position.Y - ManagedEnemy.UnarmedStrikeRange
                && map.GetPlayerPositionY() + player.BoundingBox.DistanceToTopEdge <= ManagedEnemy.Position.Y + ManagedEnemy.UnarmedStrikeRange
                || map.GetPlayerPositionY() - player.BoundingBox.DistanceToBottomEdge >= ManagedEnemy.Position.Y - ManagedEnemy.UnarmedStrikeRange
                && map.GetPlayerPositionY() - player.BoundingBox.DistanceToBottomEdge <= ManagedEnemy.Position.Y + ManagedEnemy.UnarmedStrikeRange
                || map.GetPlayerPositionY() - player.BoundingBox.DistanceToBottomEdge < ManagedEnemy.Position.Y - ManagedEnemy.UnarmedStrikeRange)
                && map.GetPlayerPositionY() + player.BoundingBox.DistanceToTopEdge > ManagedEnemy.Position.Y + ManagedEnemy.UnarmedStrikeRange;
        }

        public class Builder
        {
            private bool isAggressiveOnSight;
            private Enemy managedEnemy;

            public Builder IsAggressiveOnSight(bool value)
            {
                isAggressiveOnSight = value;
                return this;
            }

            public Builder ManagedEnemy(Enemy value)
            {
                managedEnemy = value;
                return this;
            }

            public EnemyAI Build()
            {
                EnemyAI result = new EnemyAI();
                
                result.IsAggressiveOnSight = isAggressiveOnSight;
                result.ManagedEnemy = managedEnemy;

                return result;
            }
        }
    }
}