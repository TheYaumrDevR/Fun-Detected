using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Core.Maths
{
    public class BresenhamCircleAlgorithm
    {
        private bool[,] setPixels;
        private int radius;

        public List<HitboxTilePosition> HitboxTilePositions
        {
            get;
            private set;
        }

        public BresenhamCircleAlgorithm()
        {
            HitboxTilePositions = new List<HitboxTilePosition>();
        }

        public void CreateFilledCircleArc(HitboxTilePosition startPoint, HitboxTilePosition endPoint, int radius)
        {
            this.radius = radius;
            SetCirclePoints();
            MoveClockwiseFromStartToEndAndCopyPositionsToList(startPoint, endPoint);
        }

        private void SetCirclePoints()
        {       
            setPixels = new bool[radius * 2 + 1, radius * 2 + 1];

            int centerXy = radius;

            int x = 0;
            int y = radius;

            int decisionParameter = 3 - 2 * radius;

            HitboxTilePosition centerPoint = new HitboxTilePosition(centerXy, centerXy);
            HitboxTilePositions.Add(centerPoint);

            setPixels[centerXy, centerXy] = true;
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
            setPixels[xcenter + x, ycenter + y] = true;
            setPixels[xcenter - x, ycenter + y] = true;
            setPixels[xcenter + x, ycenter - y] = true;
            setPixels[xcenter - x, ycenter - y] = true;
            setPixels[xcenter + y, ycenter + x] = true;
            setPixels[xcenter - y, ycenter + x] = true;
            setPixels[xcenter + y, ycenter - x] = true;
            setPixels[xcenter - y, ycenter - x] = true;
        }

        private void MoveClockwiseFromStartToEndAndCopyPositionsToList(HitboxTilePosition startPoint, HitboxTilePosition endPoint)
        {
            if (!startPoint.Equals(endPoint))
            {
                HitboxTilePosition currentPoint = startPoint;
                HitboxTilePositions.Add(startPoint);
                
                while (!currentPoint.Equals(endPoint))
                {
                    if (currentPoint.X - radius >= 0 && currentPoint.Y - radius < 0)
                    {
                        currentPoint = DetermineNextArcPointForTopRightQuadrant(currentPoint);
                    }
                    else if (currentPoint.X - radius > 0 && currentPoint.Y - radius >= 0)
                    {
                        currentPoint = DetermineNextArcPointForBottomRightQuadrant(currentPoint);
                    }
                    else if (currentPoint.X - radius <= 0 && currentPoint.Y - radius > 0)
                    {
                        currentPoint = DetermineNextArcPointForBottomLeftQuadrant(currentPoint);
                    }
                    else if (currentPoint.X - radius < 0 && currentPoint.Y - radius <= 0)
                    {
                        currentPoint = DetermineNextArcPointForTopLeftQuadrant(currentPoint);
                    }

                    HitboxTilePositions.Add(currentPoint);
                }
            }
            else
            {
                HitboxTilePositions.Add(startPoint);
            }
        }

        private HitboxTilePosition DetermineNextArcPointForTopRightQuadrant(HitboxTilePosition currentPoint)
        {
            return DetermineNextArcPoint(currentPoint, 1, 1);
        }

        private HitboxTilePosition DetermineNextArcPointForBottomRightQuadrant(HitboxTilePosition currentPoint)
        {  
            return DetermineNextArcPoint(currentPoint, -1, 1);
        }  

        private HitboxTilePosition DetermineNextArcPointForBottomLeftQuadrant(HitboxTilePosition currentPoint)
        {  
            return DetermineNextArcPoint(currentPoint, -1, -1); 
        } 

        private HitboxTilePosition DetermineNextArcPointForTopLeftQuadrant(HitboxTilePosition currentPoint)
        { 
            return DetermineNextArcPoint(currentPoint, 1, -1);
        }    

        private HitboxTilePosition DetermineNextArcPoint(HitboxTilePosition currentPoint, int xDirection, int yDirection)
        {
            if (currentPoint.X + xDirection < setPixels.GetLength(0) && currentPoint.X + xDirection >= 0 && setPixels[currentPoint.X + xDirection, currentPoint.Y])
            {
                return new HitboxTilePosition(currentPoint.X + xDirection, currentPoint.Y);
            }
            else if (currentPoint.Y + yDirection < setPixels.GetLength(1) && currentPoint.Y + yDirection >= 0 && setPixels[currentPoint.X, currentPoint.Y + yDirection])
            {
                return new HitboxTilePosition(currentPoint.X, currentPoint.Y + yDirection);
            }
            else if (currentPoint.X + xDirection < setPixels.GetLength(0) && currentPoint.X + xDirection >= 0 && currentPoint.Y + yDirection < setPixels.GetLength(1) && currentPoint.Y + yDirection >= 0)
            {
                return new HitboxTilePosition(currentPoint.X + xDirection, currentPoint.Y + yDirection);
            }

            return currentPoint;
        }            
    }
}