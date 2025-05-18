namespace Org.Ethasia.Fundetected.Core.Items.Potions
{
    public class RecoveryPotion : Potion
    {
        public int RecoveryAmount
        {
            get;
            private set;
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