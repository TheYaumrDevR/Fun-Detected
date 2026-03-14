namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct RecoveryPotionPresentationContext
    {
        public int Uses
        {
            get;
            private set;
        }

        public int RecoveryAmount
        {
            get;
            private set;
        }

        public class Builder
        {
            private RecoveryPotionPresentationContext result;

            public Builder WithUses(int value)
            {
                result.Uses = value;
                return this;
            }

            public Builder WithRecoveryAmount(int value)
            {
                result.RecoveryAmount = value;
                return this;
            }

            public RecoveryPotionPresentationContext Build()
            {
                return result;
            }
        }
    }
}