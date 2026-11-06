using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public interface IMapPresenter
    {
        void PresentTiles(List<ITile> tilesWithAbsolutePositions, string tileMapName);
        void PresentPortal(MapPortal portal);
        void PresentHealingWell(HealingWell healingWell);
        void PresentEmpty();
    }
}