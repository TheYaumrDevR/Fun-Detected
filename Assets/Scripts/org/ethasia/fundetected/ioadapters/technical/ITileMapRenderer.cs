namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public interface ITileMapRenderer
    {
        void RenderGroundTileAtPosition(TileRenderContext tileRenderContext);
        void RenderTerrainTileAtPosition(TileRenderContext tileRenderContext);
    }
}