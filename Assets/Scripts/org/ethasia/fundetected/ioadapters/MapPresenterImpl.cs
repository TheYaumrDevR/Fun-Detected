using System;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class MapPresenterImpl : IMapPresenter
    {
        private ITileMapRenderer tileMapRenderer;
        private Dictionary<string, Action<TileRenderContext>> renderMethodByTileLayerName;

        public MapPresenterImpl()
        {
            tileMapRenderer = TechnicalFactory.GetInstance().GetTileMapRendererInstance();
            renderMethodByTileLayerName = new Dictionary<string, Action<TileRenderContext>>();

            renderMethodByTileLayerName.Add("ground", tileMapRenderer.RenderGroundTileAtPosition);
            renderMethodByTileLayerName.Add("foliageBack", tileMapRenderer.RenderFoliageBackTileAtPosition);
            renderMethodByTileLayerName.Add("foliageFront", tileMapRenderer.RenderFoliageFrontTileAtPosition);
            renderMethodByTileLayerName.Add("terrain", tileMapRenderer.RenderTerrainTileAtPosition);
        }

        public void PresentTiles(List<Tile> tilesWithAbsolutePositions, string tileMapName)
        {   
            foreach (Tile tile in tilesWithAbsolutePositions)
            {
                for (int i = tile.StartX; i < tile.StartX + tile.Width; i++)
                {
                    for (int j = tile.StartY; j < tile.StartY + tile.Height; j++)
                    {
                        if (renderMethodByTileLayerName.ContainsKey(tileMapName))
                        {
                            string tileSetName = tile.Id.Substring(0, tile.Id.LastIndexOf("_"));

                            TileRenderContext tileRenderContext = new TileRenderContext.Builder()
                                .SetTileSetName(tileSetName)
                                .SetTileName(tile.Id)
                                .SetX(i)
                                .SetY(j)
                                .Build();

                            renderMethodByTileLayerName[tileMapName](tileRenderContext);
                        }
                    }
                }
            }
        }
    }
}