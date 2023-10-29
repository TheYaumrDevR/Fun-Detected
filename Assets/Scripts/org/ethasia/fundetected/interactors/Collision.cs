namespace Org.Ethasia.Fundetected.Interactors
{
    public struct Collision
    {
        public int StartX
        {
            get;
        }

        public int StartY
        {
            get;
        }

        public int Width
        {
            get;
        }

        public int Height
        {
            get;
        }

        private Collision(int startX, int startY, int width, int height)
        {
            StartX = startX;
            StartY = startY;
            Width = width;
            Height = height;
        }     

        public class Builder
        {
                
            private int startX;
            private int startY;
            private int width;
            private int height;

            public Builder SetStartX(int value)
            {
                startX = value;
                return this;
            }            

            public Builder SetStartY(int value)
            {
                startY = value;
                return this;
            }

            public Builder SetWidth(int value)    
            {
                width = value;
                return this;
            }        

            public Builder SetHeight(int value)
            {
                height = value;
                return this;
            }                       

            public Collision Build()
            {
                Collision result = new Collision(startX, startY, width, height);
                return result;
            }
        }           
    }
}