namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct EquipmentSlotsPresentationContext
    {
        public EquipmentSlotPresentationContext MainHand
        {
            get;
            private set;
        }

        public EquipmentSlotPresentationContext OffHand
        {
            get;
            private set;
        }

        public EquipmentSlotPresentationContext Head
        {
            get;
            private set;
        }

        public EquipmentSlotPresentationContext Chest
        {
            get;
            private set;
        }

        public EquipmentSlotPresentationContext Feet
        {
            get;
            private set;
        }

        public EquipmentSlotPresentationContext Hands
        {
            get;
            private set;
        }

        public EquipmentSlotPresentationContext Belt
        {
            get;
            private set;
        }

        public EquipmentSlotPresentationContext LeftRing
        {
            get;
            private set;
        }

        public EquipmentSlotPresentationContext RightRing
        {
            get;
            private set;
        }

        public EquipmentSlotPresentationContext Neck
        {
            get;
            private set;
        }

        public EquipmentSlotPresentationContext LeftMostPotion
        {
            get;
            private set;
        }

        public EquipmentSlotPresentationContext LeftMiddlePotion
        {
            get;
            private set;
        }

        public EquipmentSlotPresentationContext MiddlePotion
        {
            get;
            private set;
        }

        public EquipmentSlotPresentationContext RightMiddlePotion
        {
            get;
            private set;
        }

        public EquipmentSlotPresentationContext RightMostPotion
        {
            get;
            private set;
        }

        public class Builder
        {
            private EquipmentSlotsPresentationContext result;

            public Builder()
            {
                result = new EquipmentSlotsPresentationContext();
            }

            public Builder SetMainHand(EquipmentSlotPresentationContext value)
            {
                result.MainHand = value;
                return this;
            }

            public Builder SetOffHand(EquipmentSlotPresentationContext value)
            {
                result.OffHand = value;
                return this;
            }

            public Builder SetHead(EquipmentSlotPresentationContext value)
            {
                result.Head = value;
                return this;
            }

            public Builder SetChest(EquipmentSlotPresentationContext value)
            {
                result.Chest = value;
                return this;
            }

            public Builder SetFeet(EquipmentSlotPresentationContext value)
            {
                result.Feet = value;
                return this;
            }

            public Builder SetHands(EquipmentSlotPresentationContext value)
            {
                result.Hands = value;
                return this;
            }

            public Builder SetBelt(EquipmentSlotPresentationContext value)
            {
                result.Belt = value;
                return this;
            }

            public Builder SetLeftRing(EquipmentSlotPresentationContext value)
            {
                result.LeftRing = value;
                return this;
            }

            public Builder SetRightRing(EquipmentSlotPresentationContext value)
            {
                result.RightRing = value;
                return this;
            }

            public Builder SetNeck(EquipmentSlotPresentationContext value)
            {
                result.Neck = value;
                return this;
            }

            public Builder SetLeftMostPotion(EquipmentSlotPresentationContext value)
            {
                result.LeftMostPotion = value;
                return this;
            }

            public Builder SetLeftMiddlePotion(EquipmentSlotPresentationContext value)
            {
                result.LeftMiddlePotion = value;
                return this;
            }

            public Builder SetMiddlePotion(EquipmentSlotPresentationContext value)
            {
                result.MiddlePotion = value;
                return this;
            }

            public Builder SetRightMiddlePotion(EquipmentSlotPresentationContext value)
            {
                result.RightMiddlePotion = value;
                return this;
            }

            public Builder SetRightMostPotion(EquipmentSlotPresentationContext value)
            {
                result.RightMostPotion = value;
                return this;
            }

            public EquipmentSlotsPresentationContext Build()
            {
                return result;
            }
        }        
    }

    public struct EquipmentSlotPresentationContext
    {
        public string ItemId
        {
            get;
            private set;
        }

        public bool IsLegallyEquipped
        {
            get;
            private set;
        }

        public class Builder
        {
            private EquipmentSlotPresentationContext result;

            public Builder()
            {
                result = new EquipmentSlotPresentationContext();
            }

            public Builder SetItemId(string value)
            {
                result.ItemId = value;
                return this;
            }

            public Builder SetIsLegallyEquipped(bool value)
            {
                result.IsLegallyEquipped = value;
                return this;
            }

            public EquipmentSlotPresentationContext Build()
            {
                return result;
            }
        }
    }
}