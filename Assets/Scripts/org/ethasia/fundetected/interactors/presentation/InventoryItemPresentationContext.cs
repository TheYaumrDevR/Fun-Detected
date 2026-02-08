namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct InventoryItemPresentationContext
    {
        public string ItemId
        {
            get;
            private set;
        }

        public bool CanBeEquipped
        {
            get;
            private set;
        }

        public int TopLeftCornerX
        {
            get;
            private set;
        }

        public int TopLeftCornerY
        {
            get;
            private set;
        }

        public int DimensionX
        {
            get;
            private set;
        }

        public int DimensionY
        {
            get;
            private set;
        }

        public class Builder
        {
            private InventoryItemPresentationContext result;

            public Builder WithItemId(string itemId)
            {
                result.ItemId = itemId;
                return this;
            }

            public Builder WithCanBeEquipped(bool canBeEquipped)
            {
                result.CanBeEquipped = canBeEquipped;
                return this;
            }

            public Builder WithTopLeftCornerX(int topLeftCornerX)
            {
                result.TopLeftCornerX = topLeftCornerX;
                return this;
            }

            public Builder WithTopLeftCornerY(int topLeftCornerY)
            {
                result.TopLeftCornerY = topLeftCornerY;
                return this;
            }

            public Builder WithDimensionX(int dimensionX)
            {
                result.DimensionX = dimensionX;
                return this;
            }

            public Builder WithDimensionY(int dimensionY)
            {
                result.DimensionY = dimensionY;
                return this;
            }

            public InventoryItemPresentationContext Build()
            {
                return result;
            }
        }
    }
}