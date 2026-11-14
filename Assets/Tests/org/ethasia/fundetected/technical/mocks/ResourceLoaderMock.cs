using System.Collections.Generic;
using UnityEngine;

namespace Org.Ethasia.Fundetected.Technical.Mocks
{
    public class ResourceLoaderMock : IResourceLoader
    {
        private Dictionary<string, Material> materialsByPath = new Dictionary<string, Material>();

        public void AddMaterial(string path, Material material)
        {
            materialsByPath[path] = material;
        }

        public Material LoadMaterial(string path)
        {
            materialsByPath.TryGetValue(path, out Material result);
            return result;
        }
    }
}