using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors.Map
{
    public interface ITileGroupGateway
    {
        List<TileGroupTileDefinition> LoadTileGroup(string groupId);

        List<ITile> ResolveTileGroup(string groupId, int startX, int startY);
    }
}
