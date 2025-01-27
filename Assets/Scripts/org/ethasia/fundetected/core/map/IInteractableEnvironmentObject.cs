using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Core.Map
{
    public interface IInteractableEnvironmentObject
    {
        CollisionCalculations.CollisionBoundingBoxContext GetCollisionBoundingBoxContext();
        void OnInteract();
    }
}