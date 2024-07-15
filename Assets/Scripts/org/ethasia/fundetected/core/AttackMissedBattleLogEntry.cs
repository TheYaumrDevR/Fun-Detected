namespace Org.Ethasia.Fundetected.Core
{
    public class AttackMissedBattleLogEntry : IBattleActionResult
    {
        public Enemy Target
        {
            get;
            private set;
        }

        public void PresentToPlayer()
        {
            Area map = Area.ActiveArea;

            int textPositionX = Target.Position.X + map.LowestScreenX;
            int textPositionY = Target.Position.Y + map.LowestScreenY;

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
            private Enemy target;

            public Builder SetTarget(Enemy value)
            {
                target = value;
                return this;
            }

            public AttackMissedBattleLogEntry Build()
            {
                AttackMissedBattleLogEntry result = new AttackMissedBattleLogEntry();

                result.Target = target;

                return result;
            }               
        }         
    }
}