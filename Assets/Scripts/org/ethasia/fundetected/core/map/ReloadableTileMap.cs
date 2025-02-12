using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Core.Map
{
    public class ReloadableTileMap
    {
        public List<ITile> TerrainTiles
        {
            get;
        }

        public List<ITile> GroundTiles
        {
            get;
        }

        public List<ITile> FoliageBackTiles
        {
            get;
        }

        public List<ITile> FoliageFrontTiles
        {
            get;
        }

        public ReloadableTileMap()
        {
            TerrainTiles = new List<ITile>();
            GroundTiles = new List<ITile>();
            FoliageBackTiles = new List<ITile>();
            FoliageFrontTiles = new List<ITile>();
        }
    }
}