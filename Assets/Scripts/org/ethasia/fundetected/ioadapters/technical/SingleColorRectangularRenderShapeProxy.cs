namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public struct SingleColorRectangularRenderShapeProxy
    {
        public float X
        {
            get;
            private set;
        }

        public float Y
        {
            get;
            private set;
        }

        public float Width
        {
            get;
            private set;
        }

        public float Height
        {
            get;
            private set;
        }

        public string Label 
        {
            get;
            private set;
        }   

        private SingleColorRectangularRenderShapeProxy(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Label = "";
        }

        public class Builder
        {
            private float x;
            private float y;
            private float width;
            private float height;
            private string label;

            public Builder SetX(float value)
            {
                x = value;
                return this;
            }

            public Builder SetY(float value)
            {
                y = value;
                return this;
            }

            public Builder SetWidth(float value)
            {
                width = value;
                return this;
            }

            public Builder SetHeight(float value)
            {
                height = value;
                return this;
            }

            public Builder SetLabel(string value)
            {
                label = value;
                return this;
            }

            public SingleColorRectangularRenderShapeProxy Build()
            {
                SingleColorRectangularRenderShapeProxy result = new SingleColorRectangularRenderShapeProxy(x, y, width, height);
                result.Label = label;

                return result;
            }
        }
    }
}