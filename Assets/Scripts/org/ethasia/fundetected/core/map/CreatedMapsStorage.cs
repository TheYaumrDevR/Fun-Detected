using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Core.Map
{
    public class CreatedMapsStorage
    {
        private static CreatedMapsStorage instance;
        private Dictionary<string, List<Area>> mapIdByStoredMaps;

        public static CreatedMapsStorage GetInstance()
        {
            if (null == instance)
            {
                instance = new CreatedMapsStorage();
            }

            return instance;
        }

        private CreatedMapsStorage()
        {
            mapIdByStoredMaps = new Dictionary<string, List<Area>>();
        }

        public void AddMapById(string id, Area map)
        {
            if (!mapIdByStoredMaps.ContainsKey(id))
            {
                mapIdByStoredMaps[id] = new List<Area>();
            }

            mapIdByStoredMaps[id].Add(map);
        }

        public List<Area> GetStoredMapsById(string id)
        {
            return mapIdByStoredMaps[id];
        }

        public void ClearAllMaps()
        {
            mapIdByStoredMaps.Clear();
        }
    }
}