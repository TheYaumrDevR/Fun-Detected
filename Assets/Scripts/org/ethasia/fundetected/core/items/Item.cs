using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Items
{
    public abstract class Item
    {
        public string Name
        {
            get;
            private set;
        }

        public ItemClass ItemClass
        {
            get;
            private set;
        }

        public int MinimumItemLevel
        {
            get;
            private set;
        }

        public int ItemLevel
        {
            get;
            private set;
        }

        public RectangleCollisionShape CollisionShape
        {
            get;
            private set;
        }

        public ItemInInventoryShape CreateInventoryShape()
        {
            return ItemClass.CreateInventoryShape(this);
        }

        public abstract void Accept(ItemVisitor visitor);

        public class Builder
        {
            private string name;
            private ItemClass itemClass;
            private int minimumItemLevel;
            private int itemLevel;
            private int collisionShapeDistanceToLeftEdgeFromCenter;
            private int collisionShapeDistanceToRightEdgeFromCenter;
            private int collisionShapeDistanceToTopEdgeFromCenter;
            private int collisionShapeDistanceToBottomEdgeFromCenter;

            public Builder SetName(string value)
            {
                this.name = value;
                return this;
            }

            public Builder SetItemClass(ItemClass value)
            {
                this.itemClass = value;
                return this;
            }

            public Builder SetMinimumItemLevel(int value)
            {
                this.minimumItemLevel = value;
                return this;
            }

            public Builder SetItemLevel(int value)
            {
                this.itemLevel = value;
                return this;
            }

            public Builder SetCollisionShapeDistanceToLeftEdgeFromCenter(int value)
            {
                this.collisionShapeDistanceToLeftEdgeFromCenter = value;
                return this;
            }

            public Builder SetCollisionShapeDistanceToRightEdgeFromCenter(int value)
            {
                this.collisionShapeDistanceToRightEdgeFromCenter = value;
                return this;
            }

            public Builder SetCollisionShapeDistanceToTopEdgeFromCenter(int value)
            {
                this.collisionShapeDistanceToTopEdgeFromCenter = value;
                return this;
            }

            public Builder SetCollisionShapeDistanceToBottomEdgeFromCenter(int value)
            {
                this.collisionShapeDistanceToBottomEdgeFromCenter = value;
                return this;
            }

            protected void FillItemFields(Item statlessItem)
            {
                RectangleCollisionShape collisionShape = new RectangleCollisionShape.Builder()
                    .SetPosition(new Position(0, 0))
                    .SetCollisionShapeDistanceToLeftEdgeFromCenter(collisionShapeDistanceToLeftEdgeFromCenter)
                    .SetCollisionShapeDistanceToRightEdgeFromCenter(collisionShapeDistanceToRightEdgeFromCenter)
                    .SetCollisionShapeDistanceToTopEdgeFromCenter(collisionShapeDistanceToTopEdgeFromCenter)
                    .SetCollisionShapeDistanceToBottomEdgeFromCenter(collisionShapeDistanceToBottomEdgeFromCenter)
                    .Build();

                statlessItem.Name = name;
                statlessItem.ItemClass = itemClass;
                statlessItem.MinimumItemLevel = minimumItemLevel;
                statlessItem.ItemLevel = itemLevel;
                statlessItem.CollisionShape = collisionShape;
            }
        }
    }
}