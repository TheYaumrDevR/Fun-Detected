using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Combat
{
    public class AttackMissedBattleLogEntry : IBattleActionResult
    {
        private int enemyPositionX;
        private int enemyPositionY;
        private int lowestScreenXofMap;
        private int lowestScreenYofMap;

        public void PresentToPlayer()
        {
            int textPositionX = enemyPositionX + lowestScreenXofMap;
            int textPositionY = enemyPositionY + lowestScreenYofMap;

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
            private int lowestScreenXofMap;
            private int lowestScreenYofMap;

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

            public Builder SetLowestScreenXOfMap(int value)
            {
                lowestScreenXofMap = value;
                return this;
            }

            public Builder SetLowestScreenYOfMap(int value)
            {
                lowestScreenYofMap = value;
                return this;
            }

            public AttackMissedBattleLogEntry Build()
            {
                AttackMissedBattleLogEntry result = new AttackMissedBattleLogEntry();

                result.enemyPositionX = enemyPositionX;
                result.enemyPositionY = enemyPositionY;
                result.lowestScreenXofMap = lowestScreenXofMap;
                result.lowestScreenYofMap = lowestScreenYofMap;

                return result;
            }               
        }         
    }
}