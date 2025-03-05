using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Core.Map
{
    public abstract class InteractableEnvironmentObject
    {
        public Position Position
        {
            get;
            protected set;
        }

        public int Width
        {
            get;
            protected set;
        }

        public int Height
        {
            get;
            protected set;
        } 

        public CollisionCalculations.CollisionBoundingBoxContext GetCollisionBoundingBoxContext()
        {
            int distanceToRightEdge = Width / 2;
            int distanceToLeftEdge = 0 == Width % 2 ? Width / 2 - 1 : Width / 2;
            int distanceToTopEdge = Height / 2;
            int distanceToBottomEdge = 0 == Height % 2 ? Height / 2 - 1 : Height / 2;

            return new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(Position.X)
                .SetPositionY(Position.Y)
                .SetDistanceToLeftEdge(distanceToLeftEdge)
                .SetDistanceToRightEdge(distanceToRightEdge)
                .SetDistanceToTopEdge(distanceToTopEdge)
                .SetDistanceToBottomEdge(distanceToBottomEdge)
                .Build();
        }

        public abstract void OnInteract(IEnvironmentInteractionInteractor interactor);
    }
}