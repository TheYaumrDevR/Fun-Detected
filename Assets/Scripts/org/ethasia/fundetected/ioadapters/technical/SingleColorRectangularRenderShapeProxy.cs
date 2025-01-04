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

        public SingleColorRectangularRenderShapeProxy(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}