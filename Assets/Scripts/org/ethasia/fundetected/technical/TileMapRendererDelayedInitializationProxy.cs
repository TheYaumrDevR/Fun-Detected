using System.Collections.Generic;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class TileMapRendererDelayedInitializationProxy : ITileMapRenderer, IInitializationObserver
    {
        private static TileMapRendererDelayedInitializationProxy instance;
        private Dictionary<string, List<TileRenderContext>> storedCallParametersByRenderLayerName;
        private ITileMapRenderer proxiedRenderer;

        public static TileMapRendererDelayedInitializationProxy GetInstance()
        {
            if (null == instance)
            {
                instance = new TileMapRendererDelayedInitializationProxy();
                TileMapRenderer.RegisterInitializationObserver(instance);
            }

            return instance;
        }

        public TileMapRendererDelayedInitializationProxy()
        {
            storedCallParametersByRenderLayerName = new Dictionary<string, List<TileRenderContext>>();

            storedCallParametersByRenderLayerName.Add("ground", new List<TileRenderContext>());
            storedCallParametersByRenderLayerName.Add("terrain", new List<TileRenderContext>());
        }

        public void RenderGroundTileAtPosition(TileRenderContext tileRenderContext)
        {
            proxiedRenderer = TileMapRenderer.GetInstance();

            if (null != proxiedRenderer)
            {
                proxiedRenderer.RenderGroundTileAtPosition(tileRenderContext);
            }
            else
            {
                storedCallParametersByRenderLayerName["ground"].Add(tileRenderContext);
            }
        }   

        public void RenderTerrainTileAtPosition(TileRenderContext tileRenderContext)
        {
            proxiedRenderer = TileMapRenderer.GetInstance();

            if (null != proxiedRenderer)
            {
                proxiedRenderer.RenderTerrainTileAtPosition(tileRenderContext);
            }
            else 
            {
                storedCallParametersByRenderLayerName["terrain"].Add(tileRenderContext);
            }
        }         

        public void NotifyInitializationCompleted()
        {
            proxiedRenderer = TileMapRenderer.GetInstance();

            if (null != proxiedRenderer)
            {
                foreach (TileRenderContext groundTileRenderContext in storedCallParametersByRenderLayerName["ground"])
                {
                    proxiedRenderer.RenderGroundTileAtPosition(groundTileRenderContext);
                }

                storedCallParametersByRenderLayerName["ground"].Clear();

                foreach (TileRenderContext terrainTileRenderContext in storedCallParametersByRenderLayerName["terrain"])
                {
                    proxiedRenderer.RenderTerrainTileAtPosition(terrainTileRenderContext);
                }

                storedCallParametersByRenderLayerName["terrain"].Clear();
            }
        }
    }
}