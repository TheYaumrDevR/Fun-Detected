using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Interactors
{
    public struct MapProperties 
    {
        public int Width
        {
            get;
            private set;
        }

        public int Height
        {
            get;
            private set;
        }

        public int LowestScreenX
        {
            get;
            private set;
        }

        public int LowestScreenY
        {
            get;
            private set;
        }

        public int MaximumMonsters
        {
            get;
            private set;
        }
        
        public List<Collision> Collisions
        {
            get;
        }

        public List<Spawner> Spawners
        {
            get;
        }

        public List<SpawnableMonster> SpawnableMonsters
        {
            get;
        }        

        private MapProperties(int width, int height)
        {
            Width = width;
            Height = height;
            MaximumMonsters = 0;
            LowestScreenX = 0;
            LowestScreenY = 0;
            Collisions = new List<Collision>();
            Spawners = new List<Spawner>();
            SpawnableMonsters = new List<SpawnableMonster>();
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

        public class Builder
        {
            private int width;
            private int height;
            private int lowestScreenX;
            private int lowestScreenY;
            private int maximumMonsters;

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

            public Builder SetLowestScreenX(int value)
            {
                lowestScreenX = value;
                return this;
            }

            public Builder SetLowestScreenY(int value)
            {
                lowestScreenY = value;
                return this;
            }   

            public Builder SetMaximumMonsters(int value)
            {
                maximumMonsters = value;
                return this;
            }            

            public MapProperties Build()
            {
                MapProperties result = new MapProperties(width, height);

                result.LowestScreenX = lowestScreenX;
                result.LowestScreenY = lowestScreenY;
                result.MaximumMonsters = maximumMonsters;

                return result;
            }                                  
        }   
    }
}