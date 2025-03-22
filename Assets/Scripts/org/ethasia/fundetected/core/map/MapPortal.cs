using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Core.Map
{
    public class MapPortal : InteractableEnvironmentObject
    {
        public string DestinationMapId
        {
            get;
            private set;
        }

        public string DestinationPortalId
        {
            get;
            private set;
        }


        public override void OnInteract(IEnvironmentInteractionInteractor interactor)
        {
            IPortalTransitionInteractor portalTransitionInteractor = InteractorsFactoryForCore.GetInstance().GetPortalTransitionInteractor();
            portalTransitionInteractor.TransitionToOtherMap(DestinationMapId, DestinationPortalId);
        }

        public override void OnSecondaryInteract(IEnvironmentInteractionInteractor interactor)
        {
            interactor.ActivateMapSelection(DestinationMapId);
        }

        public class Builder
        {
            private Position position;
            private int width;
            private int height;
            private string destinationMapId;
            private string destinationPortalId;

            public Builder SetPosition(Position value)
            {
                position = value;
                return this;
            }

            public Builder SetWidth(int value)
            {
                width = value;
                return this;
            }

            public Builder SetHeight(int value)
            {
                height = value;
                return this;
            }

            public Builder SetDestinationMapId(string value)
            {
                destinationMapId = value;
                return this;
            }   

            public Builder SetDestinationPortalId(string value)
            {
                destinationPortalId = value;
                return this;
            }

            public MapPortal Build()
            {
                MapPortal result = new MapPortal();

                result.Position = position;
                result.Width = width;
                result.Height = height;
                result.DestinationMapId = destinationMapId;
                result.DestinationPortalId = destinationPortalId;

                return result;
            }
        }
    }
}