namespace Org.Ethasia.Fundetected.Core.Maths
{
    public class BresenhamCircleAlgorithm
    {
        public bool[,] SetPixels
        {
            get;
            private set;
        }

        public void SetCirclePoints(int radius)
        {       
            SetPixels = new bool[radius * 2 + 1, radius * 2 + 1];

            int centerXy = radius;

            int x = 0;
            int y = radius;

            int decisionParameter = 3 - 2 * radius;

            SetPixels[centerXy, centerXy] = true;
            SetPixelsOnMirroredSections(centerXy, centerXy, x, y);
            while (y >= x)
            {
                x++;

                if (decisionParameter > 0)
                {
                    y--;
                    decisionParameter = decisionParameter + 4 * (x - y) + 10;
                } 
                else
                {
                    decisionParameter = decisionParameter + 4 * x + 6;    
                }

                SetPixelsOnMirroredSections(centerXy, centerXy, x, y);
            }
        }

        private void SetPixelsOnMirroredSections(int xcenter, int ycenter, int x, int y)
        {
            SetPixels[xcenter + x, ycenter + y] = true;
            SetPixels[xcenter - x, ycenter + y] = true;
            SetPixels[xcenter + x, ycenter - y] = true;
            SetPixels[xcenter - x, ycenter - y] = true;
            SetPixels[xcenter + y, ycenter + x] = true;
            SetPixels[xcenter - y, ycenter + x] = true;
            SetPixels[xcenter + y, ycenter - x] = true;
            SetPixels[xcenter - y, ycenter - x] = true;
        }
    }
}