using UnityEngine;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class UnityJsonSerializer : IJsonSerializer
    {
        public string Serialize<T>(T value, bool prettyPrint)
        {
            return JsonUtility.ToJson(value, prettyPrint);
        }

        public T Deserialize<T>(string json)
        {
            return JsonUtility.FromJson<T>(json);
        }
    }
}