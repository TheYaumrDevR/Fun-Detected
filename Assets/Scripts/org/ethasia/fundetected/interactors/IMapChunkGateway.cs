namespace Org.Ethasia.Fundetected.Interactors
{
    public interface IMapChunkGateway
    {
        MapChunkProperties LoadChunkProperties(string chunkName);
    }
}