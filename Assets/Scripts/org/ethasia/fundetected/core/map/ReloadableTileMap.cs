using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Core.Map
{
    public class ReloadableTileMap
    {
        public List<ReloadableTile> TerrainTiles
        {
            get;
        }

        public List<ReloadableTile> GroundTiles
        {
            get;
        }

        public List<ReloadableTile> FoliageBackTiles
        {
            get;
        }

        public List<ReloadableTile> FoliageFrontTiles
        {
            get;
        }

        public ReloadableTileMap()
        {
            TerrainTiles = new List<ReloadableTile>();
            GroundTiles = new List<ReloadableTile>();
            FoliageBackTiles = new List<ReloadableTile>();
            FoliageFrontTiles = new List<ReloadableTile>();
        }
    }
}