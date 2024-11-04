using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Combat
{
    public struct PlayerAbilityActionResult : IBattleActionResult
    {
        public Enemy Target
        {
            get;
            private set;
        }

        public int TargetDamageTaken
        {
            get;
            private set;
        }       

        public void PresentToPlayer()
        {
            Area map = Area.ActiveArea;

            DamageTextDisplayInformation damageTextDisplayInfo = new DamageTextDisplayInformation();

            damageTextDisplayInfo.DamageValue = TargetDamageTaken;
            damageTextDisplayInfo.PositionX = Target.Position.X;
            damageTextDisplayInfo.PositionY = Target.Position.Y;

            IDamageTextPresenter damageTextPresenter = IoAdaptersFactoryForCore.GetInstance().GetDamageTextPresenterInstance();

            damageTextPresenter.PresentDamageText(damageTextDisplayInfo);
        }

        public override string ToString()
        {
            return "You hit " + Target.Name + " for " + TargetDamageTaken + ". Remaining target HP: " + Target.CurrentLife;
        }

        public class Builder
        {
            private Enemy target;
            private int targetDamageTaken;

            public Builder SetTarget(Enemy value)
            {
                target = value;
                return this;
            }

            public Builder SetTargetDamageTaken(int value)
            {
                targetDamageTaken = value;
                return this;
            }

            public PlayerAbilityActionResult Build()
            {
                PlayerAbilityActionResult result = new PlayerAbilityActionResult();

                result.Target = target;
                result.TargetDamageTaken = targetDamageTaken;

                return result;
            }               
        }       
    }
}