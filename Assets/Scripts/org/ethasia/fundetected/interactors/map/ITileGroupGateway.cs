using System.Collections.Generic;
using System.Xml;

using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors.Map
{
    public interface ITileGroupGateway
    {
        List<TileGroupTileDefinition> LoadTileGroup(string groupName);
    }
}
