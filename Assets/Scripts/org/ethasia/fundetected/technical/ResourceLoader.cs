using UnityEngine;

namespace Org.Ethasia.Fundetected.Technical
{
    public class ResourceLoader : IResourceLoader
    {
        public Material LoadMaterial(string path)
        {
            return Resources.Load<Material>(path);
        }
    }
}