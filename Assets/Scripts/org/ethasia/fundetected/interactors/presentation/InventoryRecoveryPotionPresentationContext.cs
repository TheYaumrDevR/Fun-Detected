namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct InventoryRecoveryPotionPresentationContext
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

        public InventoryItemPresentationContext ItemContext
        {
            get;
            private set;
        }

        public class Builder
        {
            private InventoryRecoveryPotionPresentationContext result;

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

            public Builder WithItemContext(InventoryItemPresentationContext value)
            {
                result.ItemContext = value;
                return this;
            }

            public InventoryRecoveryPotionPresentationContext Build()
            {
                return result;
            }
        }
    }
}