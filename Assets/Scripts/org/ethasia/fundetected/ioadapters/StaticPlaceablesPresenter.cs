using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class StaticPlaceablesPresenter : IStaticPlaceablesPresenter
    {
        public void PresentTombstone(string id, int positionX, int positionY)
        {
            TechnicalFactory.GetInstance().GetStaticPlaceablesRendererInstance().RenderTombstone(id, positionX * 0.1f, positionY * 0.1f);
        }

        public void MovePresentedTombstoneVertically(string id, int units)
        {
            TechnicalFactory.GetInstance().GetStaticPlaceablesRendererInstance().MoveTombstoneVertically(id, units * 0.1f);
        }

        public void ClearPresentedTombstones()
        {
            TechnicalFactory.GetInstance().GetStaticPlaceablesRendererInstance().ClearRenderedStaticPlaceables();
        }
    }
}