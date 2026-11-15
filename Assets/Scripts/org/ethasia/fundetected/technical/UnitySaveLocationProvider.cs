using UnityEngine;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class UnitySaveLocationProvider : ISaveLocationProvider
    {
        public string GetBaseSaveDirectory()
        {
            return Application.persistentDataPath;
        }
    }
}