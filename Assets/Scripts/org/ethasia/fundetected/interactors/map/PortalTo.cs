namespace Org.Ethasia.Fundetected.Interactors.Map
{
    public struct PortalTo
    {
        public string MapId
        {
            get;
            private set;
        }

        public string PortalId
        {
            get;
            private set;
        }

        public PortalTo(string mapId, string portalId)
        {
            MapId = mapId;
            PortalId = portalId;
        }
    }
}