namespace Org.Ethasia.Fundetected.Core.Items.Potions
{
    public class RecoveryPotion : Potion
    {
        public int RecoveryAmount
        {
            get;
            private set;
        }

        public override void Accept(ItemVisitor visitor)
        {

        }

        public override void RerollEntireItem()
        {
            // TODO: implement later when there is something to reroll
        }

        protected override Item CloneActual()
        {
            RecoveryPotion result = new RecoveryPotion();
            result.RecoveryAmount = RecoveryAmount;

            Clone(result);
            
            return result;
        }

        new public class Builder : Potion.Builder
        {
            private int recoveryAmount;

            public Builder SetRecoveryAmount(int value)
            {
                this.recoveryAmount = value;
                return this;
            }

            public RecoveryPotion Build()
            {
                RecoveryPotion result = new RecoveryPotion();
                result.RecoveryAmount = recoveryAmount;

                FillPotionFields(result);

                return result;
            }
        }
    }
}