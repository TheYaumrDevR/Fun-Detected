namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public interface IJsonSerializer
    {
        string Serialize<T>(T value, bool prettyPrint);
        T Deserialize<T>(string json);
    }
}