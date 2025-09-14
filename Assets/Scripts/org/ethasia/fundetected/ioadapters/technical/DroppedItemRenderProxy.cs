namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public struct DroppedItemRenderProxy
    {
        public string Id
        {
            get;
            private set;
        }

        public string RenderImageName
        {
            get;
            private set;
        }

        public string ItemName
        {
            get;
            private set;
        }

        public float PosX
        {
            get;
            private set;
        }

        public float PosY
        {
            get;
            private set;
        }

        public class Builder
        {
            private DroppedItemRenderProxy result;

            public Builder()
            {
                result = new DroppedItemRenderProxy();
            }

            public Builder SetId(string value)
            {
                result.Id = value;
                return this;
            }

            public Builder SetRenderImageName(string value)
            {
                result.RenderImageName = value;
                return this;
            }

            public Builder SetItemName(string value)
            {
                result.ItemName = value;
                return this;
            }

            public Builder SetPosX(float value)
            {
                result.PosX = value;
                return this;
            }

            public Builder SetPosY(float value)
            {
                result.PosY = value;
                return this;
            }

            public DroppedItemRenderProxy Build()
            {
                return result;
            }
        }
    }
}