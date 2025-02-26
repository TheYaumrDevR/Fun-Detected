namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public struct InteractableRenderProxy
    {
        public string RenderImageName
        {
            get;
            private set;
        }

        public string InteractableDisplayName
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
            private InteractableRenderProxy result;

            public Builder()
            {
                result = new InteractableRenderProxy();
            }

            public Builder SetRenderImageName(string value)
            {
                result.RenderImageName = value;
                return this;
            }

            public Builder SetInteractableDisplayName(string value)
            {
                result.InteractableDisplayName = value;
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

            public InteractableRenderProxy Build()
            {
                return result;
            }
        }
    }
}