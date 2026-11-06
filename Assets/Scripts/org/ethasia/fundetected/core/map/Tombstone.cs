namespace Org.Ethasia.Fundetected.Core.Map
{
    public class Tombstone : PhysicsObject
    {
        public Tombstone(int posX, int posY)
        {
            UniqueId = "Tombstone" + System.Guid.NewGuid().ToString();

            CollisionShape = new RectangleCollisionShape.Builder()
                .SetPosition(new Position(posX, posY))
                .SetCollisionShapeDistanceToLeftEdgeFromCenter(5)
                .SetCollisionShapeDistanceToRightEdgeFromCenter(5)
                .SetCollisionShapeDistanceToTopEdgeFromCenter(9)
                .SetCollisionShapeDistanceToBottomEdgeFromCenter(9)
                .Build();
        }
    }
}