namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public struct InventorySlotRenderContext
    {
        public bool ShouldRenderSomething
        {
            get;
            private set;
        }

        public string ItemImageName
        {
            get;
            private set;
        }

        public bool CanBeEquipped
        {
            get;
            private set;
        }

        public class Builder
        {
            private bool shouldRenderSomething;
            private string itemImageName;
            private bool canBeEquipped;

            public Builder ShouldRenderSomething(bool value)
            {
                shouldRenderSomething = value;
                return this;
            }

            public Builder WithItemImageName(string value)
            {
                itemImageName = value;
                return this;
            }

            public Builder WithCanBeEquipped(bool value)
            {
                canBeEquipped = value;
                return this;
            }

            public InventorySlotRenderContext Build()
            {
                return new InventorySlotRenderContext
                {
                    ShouldRenderSomething = shouldRenderSomething,
                    ItemImageName = itemImageName,
                    CanBeEquipped = canBeEquipped
                };
            }
        }
    }
}