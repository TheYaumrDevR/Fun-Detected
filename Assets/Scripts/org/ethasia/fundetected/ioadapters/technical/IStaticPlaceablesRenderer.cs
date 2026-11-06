namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public interface IStaticPlaceablesRenderer
    {
        void RenderTombstone(string id, float posX, float posY);
        void MoveTombstoneVertically(string id, float units);
        void ClearRenderedStaticPlaceables();
    }
}