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

        public MapSelectionWindowContent(string mapName, List<string> mapIds)
        {
            MapName = mapName;
            MapIds = mapIds;
        }
    }
}