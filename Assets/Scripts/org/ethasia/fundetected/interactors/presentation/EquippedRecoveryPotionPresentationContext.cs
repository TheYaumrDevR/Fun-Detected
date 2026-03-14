using Org.Ethasia.Fundetected.Core.Equipment;

namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct EquippedRecoveryPotionPresentationContext
    {
        public EquipmentSlotPositions SlotPosition
        {
            get;
            private set;
        }

        public InventoryItemPresentationContext ItemPresentationContext
        {
            get;
            private set;
        }

        public RecoveryPotionPresentationContext RecoveryPotionPresentationContext
        {
            get;
            private set;
        }

        public static EquippedRecoveryPotionPresentationContext CreateEmpty()
        {
            return new Builder().Build();
        }

        public class Builder
        {
            private EquippedRecoveryPotionPresentationContext result;

            public Builder WithSlotPosition(EquipmentSlotPositions value)
            {
                result.SlotPosition = value;
                return this;
            }

            public Builder WithItemPresentationContext(InventoryItemPresentationContext value)
            {
                result.ItemPresentationContext = value;
                return this;
            }

            public Builder WithRecoveryPotionPresentationContext(RecoveryPotionPresentationContext value)
            {
                result.RecoveryPotionPresentationContext = value;
                return this;
            }

            public EquippedRecoveryPotionPresentationContext Build()
            {
                return result;
            }
        }
    }
}