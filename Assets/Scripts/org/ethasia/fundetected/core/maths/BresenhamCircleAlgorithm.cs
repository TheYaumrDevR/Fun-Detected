using System;
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

        public void CreateFilledCircleArc(double startAngleInRadians, double stopAngleInRadians, int radius)
        {
            this.radius = radius;
            SetCirclePoints();

            HitboxTilePosition startPoint = DetermineCirclePointFromAngle(startAngleInRadians);
            HitboxTilePosition endPoint = DetermineCirclePointFromAngle(stopAngleInRadians);  

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

        private HitboxTilePosition DetermineCirclePointFromAngle(double angleInRadians)
        {
            int pointX = Convert.ToInt32(Math.Round(radius + radius * Math.Cos(angleInRadians)));
            int pointY = Convert.ToInt32(Math.Round(radius + radius * Math.Sin(angleInRadians)));

            return new HitboxTilePosition(pointX, pointY);
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

        private void DrawLine(HitboxTilePosition startPoint, HitboxTilePosition endPoint)
        {
            int dx = endPoint.X - startPoint.X;
            int dy = endPoint.Y - startPoint.Y;

            if (dx < 0)
            {
                dx = -dx;
            }

            if (dy < 0)
            {
                dy = -dy;
            }

            int incrementX = 1;

            if (endPoint.X < startPoint.X)
            {
                incrementX = -1;
            }

            int incrementY = 1;

            if (endPoint.Y < startPoint.Y)
            {
                incrementY = -1;
            }

            int x = startPoint.X;
            int y = startPoint.Y;

            int decisionParameter = 0;

            int decisionParameterIncrement1 = 0;
            int decisionParameterIncrement2 = 0;

            if (dx > dy)
            {
                decisionParameter = 2 * dy - dx;
                decisionParameterIncrement1 = 2 * (dy - dx);
                decisionParameterIncrement2 = 2 * dy;

                for (int i = 0; i < dx; i++)
                {
                    if (decisionParameter >= 0)
                    {
                        y += incrementY;
                        decisionParameter += decisionParameterIncrement1;
                    }
                    else
                    {
                        decisionParameter += decisionParameterIncrement2;
                    }

                    x += incrementX;
                    SetCollisionTile(x, y);
                }
            }
            else
            {
                decisionParameter = 2 * dx - dy;
                decisionParameterIncrement1 = 2 * (dx - dy);
                decisionParameterIncrement2 = 2 * dx;

                for (int i = 0; i < dy; i++)
                {
                    if (decisionParameter >= 0)
                    {
                        x += incrementX;
                        decisionParameter += decisionParameterIncrement1;
                    }
                    else
                    {
                        decisionParameter += decisionParameterIncrement2;
                    }

                    y += incrementY;
                    SetCollisionTile(x, y);
                }
            }
        }    

        private void SetCollisionTile(int x, int y)
        {
            if (!setPixels[x, y])
            {
                HitboxTilePosition collisionTile = new HitboxTilePosition(x, y);

                setPixels[x, y] = true;
                HitboxTilePositions.Add(collisionTile);
            }
        }   
    }
}