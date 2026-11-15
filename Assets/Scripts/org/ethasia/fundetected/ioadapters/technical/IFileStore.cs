namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public interface IFileStore
    {
        void Save(string fileName, string content);
    }
}