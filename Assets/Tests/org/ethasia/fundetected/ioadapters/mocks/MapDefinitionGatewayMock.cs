using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{
    public class MapDefinitionGatewayMock : IMapDefinitionGateway
    {
        public MapDefinition LoadMapDefinition(string mapName)
        {
            return new MapDefinition(0);
        }
    }
}