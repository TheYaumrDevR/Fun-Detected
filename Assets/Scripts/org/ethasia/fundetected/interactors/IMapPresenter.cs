using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors
{
    public interface IMapPresenter
    {
        void PresentTiles(List<Tile> tilesWithAbsolutePositions, string tileMapName);
        void PresentPortal(Position position, int width, int height);
    }
}