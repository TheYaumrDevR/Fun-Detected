using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors.Map;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{
    public class TileGroupGatewayMock : ITileGroupGateway
    {
        public List<TileGroupTileDefinition> LoadTileGroup(string groupId)
        {
            return new List<TileGroupTileDefinition>();
        }

        public List<ITile> ResolveTileGroup(string groupId, int startX, int startY)
        {
            return new List<ITile>();
        }
    }
}
