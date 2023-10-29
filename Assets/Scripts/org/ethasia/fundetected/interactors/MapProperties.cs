using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Interactors
{
    public struct MapProperties 
    {
        public int Width
        {
            get;
        }

        public int Height
        {
            get;
        }
        
        public List<Collision> Collisions
        {
            get;
        }

        public MapProperties(int width, int height)
        {
            Width = width;
            Height = height;
            Collisions = new List<Collision>();
        }

        public void AddCollision(Collision value)
        {
            Collisions.Add(value);
        }

        public int CalculateLowestX()
        {
            int result = 0;

            if (Collisions.Count > 0)
            {
                result = Collisions[0].StartX;
            }

            foreach (Collision collision in Collisions)
            {
                if (collision.StartX < result)
                {
                    result = collision.StartX;
                }
            }

            return result;
        }

        public int CalculateLowestY()
        {
            int result = 0;

            if (Collisions.Count > 0)
            {
                result = Collisions[0].StartY;
            }

            foreach (Collision collision in Collisions)
            {
                if (collision.StartY < result)
                {
                    result = collision.StartY;
                }
            }

            return result;
        }        
    }
}