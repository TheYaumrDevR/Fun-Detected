namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public interface IFileStore
    {
        void Save(string directory, string fileName, string content);
    }
}