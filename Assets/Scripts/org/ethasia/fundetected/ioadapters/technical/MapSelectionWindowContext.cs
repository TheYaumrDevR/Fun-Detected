using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public struct MapSelectionWindowContext
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

        public string DestinationPortalId
        {
            get;
            private set;
        }        

        public bool ShowNewInstanceButton
        {
            get;
            private set;
        }

        public MapSelectionWindowContext(string mapName, List<string> mapIds)
        {
            MapName = mapName;
            MapIds = mapIds;
            ShowNewInstanceButton = true;
            DestinationPortalId = "";
        }

        public static MapSelectionWindowContext CreateForSingletonMap(string mapName, string mapId)
        {
            return new MapSelectionWindowContext(mapName, new List<string> { mapId })
            {
                ShowNewInstanceButton = false
            };
        }

        public class Builder
        {
            private string mapName;
            private List<string> mapIds;
            private string destinationPortalId;
            private bool showNewInstanceButton;

            public Builder SetMapName(string value)
            {
                this.mapName = value;
                return this;
            }

            public Builder SetMapIds(List<string> value)
            {
                this.mapIds = value;
                return this;
            }
    
            public Builder SetDestinationPortalId(string value)
            {
                this.destinationPortalId = value;
                return this;
            }

            public Builder SetShowNewInstanceButton(bool value)
            {
                this.showNewInstanceButton = value;
                return this;
            }
    
            public MapSelectionWindowContext Build()
            {
                return new MapSelectionWindowContext(mapName, mapIds)
                {
                    DestinationPortalId = destinationPortalId,
                    ShowNewInstanceButton = showNewInstanceButton
                };
            }    
        }
    }
}