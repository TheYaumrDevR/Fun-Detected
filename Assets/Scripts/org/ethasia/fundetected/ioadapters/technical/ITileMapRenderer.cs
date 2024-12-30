namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public interface ITileMapRenderer
    {
        void RenderGroundTileAtPosition(TileRenderContext tileRenderContext);
        void RenderFoliageBackTileAtPosition(TileRenderContext tileRenderContext);
        void RenderFoliageFrontTileAtPosition(TileRenderContext tileRenderContext);
        void RenderTerrainTileAtPosition(TileRenderContext tileRenderContext);
    }
}