using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class MapPropertiesConverter
    {
        public static Area ConvertMapPropertiesToArea(MapProperties mapProperties)
        {
            Area.Builder areaBuilder = new Area.Builder()
                .SetWidthAndHeight(mapProperties.Width, mapProperties.Height);

            ConvertCollisions(mapProperties, areaBuilder);

            return areaBuilder.Build();
        }

        private static void ConvertCollisions(MapProperties mapProperties, Area.Builder areaBuilder)
        {
            foreach (Collision collision in mapProperties.Collisions)
            {
                for (int i = 0; i < collision.Width; i++)
                {
                    for (int j = 0; j < collision.Height; j++)
                    {
                        int x = collision.StartX + i - mapProperties.CalculateLowestX();
                        int y = collision.StartY + j - mapProperties.CalculateLowestY();
                        areaBuilder.SetIsColliding(x, y);
                    }
                }
            }
        }
    }
}