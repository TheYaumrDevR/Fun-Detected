using Org.Ethasia.Fundetected.Interactors.Map;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{
    public class MapChunkGatewayMock : IMapChunkGateway
    {
        public MapChunkProperties LoadChunkProperties(string chunkName)
        {
            return new MapChunkProperties.Builder()
                .SetId(chunkName)
                .SetPlayerSpawnPoint(PlayerSpawn.CreateUnset())
                .Build(); 
        }
    }
}