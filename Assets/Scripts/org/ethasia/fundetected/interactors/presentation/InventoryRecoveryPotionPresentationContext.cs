namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct InventoryRecoveryPotionPresentationContext
    {
        public RecoveryPotionPresentationContext RecoveryPotionContext
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

            public Builder WithRecoveryPotionContext(RecoveryPotionPresentationContext value)
            {
                result.RecoveryPotionContext = value;
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