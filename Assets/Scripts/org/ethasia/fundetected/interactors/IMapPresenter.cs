using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Interactors
{
    public interface IMapPresenter
    {
        void PresentTiles(List<Tile> tilesWithAbsolutePositions, string tileMapName);
    }
}