namespace Org.Ethasia.Fundetected.Core.Map
{
    public class Tombstone : PhysicsObject
    {
        public Tombstone(int posX, int posY)
        {
            UniqueId = "Tombstone" + System.Guid.NewGuid().ToString();

            CollisionShape = new RectangleCollisionShape.Builder()
                .SetPosition(new Position(posX, posY))
                .SetCollisionShapeDistanceToLeftEdgeFromCenter(4)
                .SetCollisionShapeDistanceToRightEdgeFromCenter(4)
                .SetCollisionShapeDistanceToTopEdgeFromCenter(8)
                .SetCollisionShapeDistanceToBottomEdgeFromCenter(8)
                .Build();
        }
    }
}