namespace Org.Ethasia.Fundetected.Interactors.Map
{
    public interface IMapChunkGateway
    {
        MapChunkProperties LoadChunkProperties(string chunkName);
    }
}