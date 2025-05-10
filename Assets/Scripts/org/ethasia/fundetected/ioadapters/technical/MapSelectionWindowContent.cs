using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public struct MapSelectionWindowContent
    {
        public string MapName
        {
            get;
            private set;
        }

        public List<string> MapIds
        {
            get;
            private set;
        }

        public bool ShowNewInstanceButton
        {
            get;
            private set;
        }

        public MapSelectionWindowContent(string mapName, List<string> mapIds)
        {
            MapName = mapName;
            MapIds = mapIds;
            ShowNewInstanceButton = true;
        }

        public static MapSelectionWindowContent CreateForSingletonMap(string mapName, string mapId)
        {
            return new MapSelectionWindowContent(mapName, new List<string> { mapId })
            {
                ShowNewInstanceButton = false
            };
        }
    }
}