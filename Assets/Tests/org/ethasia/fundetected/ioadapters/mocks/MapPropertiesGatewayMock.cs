using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{
    public class MapPropertiesGatewayMock : IMapPropertiesGateway
    {
        public MapProperties LoadMapProperties(string mapName)
        {
            return new MapProperties.Builder().Build();
        }
    }
}