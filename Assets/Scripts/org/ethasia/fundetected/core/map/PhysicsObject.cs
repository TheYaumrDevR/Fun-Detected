namespace Org.Ethasia.Fundetected.Core.Map
{
    public abstract class PhysicsObject
    {
        public string UniqueId
        {
            get;
            protected set;
        }

        public RectangleCollisionShape CollisionShape
        {
            get;
            protected set;
        }

        public PhysicsBody PhysicsBody
        {
            get;
            private set;
        } = new PhysicsBody();
    }
}