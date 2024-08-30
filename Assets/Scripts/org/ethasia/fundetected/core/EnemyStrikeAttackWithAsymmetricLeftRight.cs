namespace Org.Ethasia.Fundetected.Core
{
    public class EnemyStrikeAttackWithAsymmetricLeftRight : EnemyAbility
    {   
        private Enemy attacker;
        private EnemyStrikeAttack leftStrikeAttack;
        private EnemyStrikeAttack rightStrikeAttack;
        private EnemyStrikeAttack currentStrikeAttack;

        public void Tick(double actionTime)
        {
            if (null != currentStrikeAttack)
            {
                currentStrikeAttack.Tick(actionTime);
            }
        }

        public AsyncResponse<bool> Start(double attacksPerSecond)
        {        
            if (leftStrikeAttack.EnoughTimePassedForTheNextAttackToBeExecuted(attacksPerSecond) && rightStrikeAttack.EnoughTimePassedForTheNextAttackToBeExecuted(attacksPerSecond))
            {
                if (attacker.Position.X < Area.ActiveArea.GetPlayerPositionX())
                {
                    currentStrikeAttack = rightStrikeAttack;
                } 
                else 
                {
                    currentStrikeAttack = leftStrikeAttack;
                }

                return currentStrikeAttack.Start(attacksPerSecond);
            }
            else
            {
                AsyncResponse<bool> result = new AsyncResponse<bool>();
                result.SetResponseObject(false);

                return result;
            }
        }

        public class EnemyStrikeAttackWithAsymmetricLeftRightBuilder
        {
            private Enemy attacker;
            private EnemyStrikeAttack leftStrikeAttack;
            private EnemyStrikeAttack rightStrikeAttack;

            public EnemyStrikeAttackWithAsymmetricLeftRightBuilder SetAttacker(Enemy value)
            {
                attacker = value;
                return this;
            }

            public EnemyStrikeAttackWithAsymmetricLeftRightBuilder SetLeftStrikeAttack(EnemyStrikeAttack value)
            {
                leftStrikeAttack = value;
                return this;
            }

            public EnemyStrikeAttackWithAsymmetricLeftRightBuilder SetRightStrikeAttack(EnemyStrikeAttack value)
            {
                rightStrikeAttack = value;
                return this;
            }

            public EnemyStrikeAttackWithAsymmetricLeftRight Build()
            {
                EnemyStrikeAttackWithAsymmetricLeftRight result = new EnemyStrikeAttackWithAsymmetricLeftRight();

                result.attacker = attacker;
                result.leftStrikeAttack = leftStrikeAttack;
                result.rightStrikeAttack = rightStrikeAttack;

                return result;
            }
        }
    }
}