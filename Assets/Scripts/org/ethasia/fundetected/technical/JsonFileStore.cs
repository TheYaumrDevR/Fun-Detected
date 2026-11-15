using System.IO;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class JsonFileStore : IFileStore
    {
        public void Save(string directory, string fileName, string content)
        {
            Directory.CreateDirectory(directory);

            string safeFileName = Path.GetFileName(fileName);
            string finalPath = Path.Combine(directory, safeFileName);
            string temporaryPath = finalPath + ".tmp";

            File.WriteAllText(temporaryPath, content);

            if (File.Exists(finalPath))
            {
                File.Delete(finalPath);
            }

            File.Move(temporaryPath, finalPath);
        }
    }
}