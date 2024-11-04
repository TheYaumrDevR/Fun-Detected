using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Combat
{
    public class AttackMissedBattleLogEntry : IBattleActionResult
    {
        private int enemyPositionX;
        private int enemyPositionY;

        public void PresentToPlayer()
        {
            int textPositionX = enemyPositionX;
            int textPositionY = enemyPositionY;

            Position textPosition = new Position(textPositionX, textPositionY);

            IDamageTextPresenter damageTextPresenter = IoAdaptersFactoryForCore.GetInstance().GetDamageTextPresenterInstance();

            damageTextPresenter.PresentMissText(textPosition);
        }

        public override string ToString()
        {
            return "The player's attack missed";
        }

        public class Builder
        {
            private int enemyPositionX;
            private int enemyPositionY;

            public Builder SetEnemyPositionX(int value)
            {
                enemyPositionX = value;
                return this;
            }

            public Builder SetEnemyPositionY(int value)
            {
                enemyPositionY = value;
                return this;
            }

            public AttackMissedBattleLogEntry Build()
            {
                AttackMissedBattleLogEntry result = new AttackMissedBattleLogEntry();

                result.enemyPositionX = enemyPositionX;
                result.enemyPositionY = enemyPositionY;

                return result;
            }               
        }         
    }
}