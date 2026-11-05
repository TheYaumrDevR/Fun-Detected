namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public interface IStaticPlaceablesRenderer
    {
        void RenderTombstone(float posX, float posY);
        void ClearRenderedStaticPlaceables();
    }
}