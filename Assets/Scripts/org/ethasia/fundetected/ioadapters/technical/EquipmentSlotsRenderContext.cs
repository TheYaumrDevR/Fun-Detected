namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public struct EquipmentSlotsRenderContext
    {
        public EquipmentSlotRenderContext MainHand
        {
            get;
            private set;
        }

        public EquipmentSlotRenderContext OffHand
        {
            get;
            private set;
        }

        public EquipmentSlotRenderContext Head
        {
            get;
            private set;
        }

        public EquipmentSlotRenderContext Chest
        {
            get;
            private set;
        }

        public EquipmentSlotRenderContext Feet
        {
            get;
            private set;
        }

        public EquipmentSlotRenderContext Hands
        {
            get;
            private set;
        }

        public EquipmentSlotRenderContext Belt
        {
            get;
            private set;
        }

        public EquipmentSlotRenderContext LeftRing
        {
            get;
            private set;
        }

        public EquipmentSlotRenderContext RightRing
        {
            get;
            private set;
        }

        public EquipmentSlotRenderContext Neck
        {
            get;
            private set;
        }

        public EquipmentSlotRenderContext LeftMostPotion
        {
            get;
            private set;
        }

        public EquipmentSlotRenderContext LeftMiddlePotion
        {
            get;
            private set;
        }

        public EquipmentSlotRenderContext MiddlePotion
        {
            get;
            private set;
        }

        public EquipmentSlotRenderContext RightMiddlePotion
        {
            get;
            private set;
        }

        public EquipmentSlotRenderContext RightMostPotion
        {
            get;
            private set;
        }

        public class Builder
        {
            private EquipmentSlotsRenderContext result;

            public Builder()
            {
                result = new EquipmentSlotsRenderContext();
            }

            public Builder SetMainHand(EquipmentSlotRenderContext value)
            {
                result.MainHand = value;
                return this;
            }

            public Builder SetOffHand(EquipmentSlotRenderContext value)
            {
                result.OffHand = value;
                return this;
            }

            public Builder SetHead(EquipmentSlotRenderContext value)
            {
                result.Head = value;
                return this;
            }

            public Builder SetChest(EquipmentSlotRenderContext value)
            {
                result.Chest = value;
                return this;
            }

            public Builder SetFeet(EquipmentSlotRenderContext value)
            {
                result.Feet = value;
                return this;
            }

            public Builder SetHands(EquipmentSlotRenderContext value)
            {
                result.Hands = value;
                return this;
            }

            public Builder SetBelt(EquipmentSlotRenderContext value)
            {
                result.Belt = value;
                return this;
            }

            public Builder SetLeftRing(EquipmentSlotRenderContext value)
            {
                result.LeftRing = value;
                return this;
            }

            public Builder SetRightRing(EquipmentSlotRenderContext value)
            {
                result.RightRing = value;
                return this;
            }

            public Builder SetNeck(EquipmentSlotRenderContext value)
            {
                result.Neck = value;
                return this;
            }

            public Builder SetLeftMostPotion(EquipmentSlotRenderContext value)
            {
                result.LeftMostPotion = value;
                return this;
            }

            public Builder SetLeftMiddlePotion(EquipmentSlotRenderContext value)
            {
                result.LeftMiddlePotion = value;
                return this;
            }

            public Builder SetMiddlePotion(EquipmentSlotRenderContext value)
            {
                result.MiddlePotion = value;
                return this;
            }

            public Builder SetRightMiddlePotion(EquipmentSlotRenderContext value)
            {
                result.RightMiddlePotion = value;
                return this;
            }

            public Builder SetRightMostPotion(EquipmentSlotRenderContext value)
            {
                result.RightMostPotion = value;
                return this;
            }

            public EquipmentSlotsRenderContext Build()
            {
                return result;
            }
        }
    }

    public struct EquipmentSlotRenderContext
    {
        public string ItemImagePath
        {
            get;
            private set;
        }

        public bool IsEquipped
        {
            get;
            private set;
        }

        public class Builder
        {
            private EquipmentSlotRenderContext result;

            public Builder()
            {
                result = new EquipmentSlotRenderContext();
            }

            public Builder SetItemImagePath(string value)
            {
                result.ItemImagePath = value;
                return this;
            }

            public Builder SetIsEquipped(bool value)
            {
                result.IsEquipped = value;
                return this;
            }

            public EquipmentSlotRenderContext Build()
            {
                return result;
            }
        }
    }
}