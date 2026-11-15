using System.IO;
using UnityEngine;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class JsonFileStore : IFileStore
    {
        private const string SAVE_DIRECTORY_NAME = "SaveGames";

        public void Save(string fileName, string content)
        {
            string directory = Path.Combine(Application.persistentDataPath, SAVE_DIRECTORY_NAME);
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