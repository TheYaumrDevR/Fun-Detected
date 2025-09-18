using Org.Ethasia.Fundetected.Core.Items;

namespace Org.Ethasia.Fundetected.Interactors
{
    public abstract class ItemMasterData
    {
        public ItemClass ItemClass { get; protected set; }
        public int MinimumItemLevel { get; protected set; }
        public string Name { get; protected set; }
        public int StrengthRequirement { get; protected set; }
        public int AgilityRequirement { get; protected set; }
        public int IntelligenceRequirement { get; protected set; }
        public EquipmentAffixMasterData FirstImplicit { get; protected set; }
        public int CollisionShapeDistanceToLeftEdgeFromCenter { get; protected set; }
        public int CollisionShapeDistanceToRightEdgeFromCenter { get; protected set; }
        public int CollisionShapeDistanceToTopEdgeFromCenter { get; protected set; }
        public int CollisionShapeDistanceToBottomEdgeFromCenter { get; protected set; }

        public abstract Item ToItem();

        public class Builder
        {
            private int collisionShapeDistanceToLeftEdgeFromCenter;
            private int collisionShapeDistanceToRightEdgeFromCenter;
            private int collisionShapeDistanceToTopEdgeFromCenter;
            private int collisionShapeDistanceToBottomEdgeFromCenter;

            public Builder SetCollisionShapeDistanceToLeftEdgeFromCenter(int value)
            {
                collisionShapeDistanceToLeftEdgeFromCenter = value;
                return this;
            }

            public Builder SetCollisionShapeDistanceToRightEdgeFromCenter(int value)
            {
                collisionShapeDistanceToRightEdgeFromCenter = value;
                return this;
            }

            public Builder SetCollisionShapeDistanceToTopEdgeFromCenter(int value)
            {
                collisionShapeDistanceToTopEdgeFromCenter = value;
                return this;
            }

            public Builder SetCollisionShapeDistanceToBottomEdgeFromCenter(int value)
            {
                collisionShapeDistanceToBottomEdgeFromCenter = value;
                return this;
            }

            protected void FillItemMasterDataFields(ItemMasterData itemMasterData)
            {
                itemMasterData.CollisionShapeDistanceToLeftEdgeFromCenter = collisionShapeDistanceToLeftEdgeFromCenter;
                itemMasterData.CollisionShapeDistanceToRightEdgeFromCenter = collisionShapeDistanceToRightEdgeFromCenter;
                itemMasterData.CollisionShapeDistanceToTopEdgeFromCenter = collisionShapeDistanceToTopEdgeFromCenter;
                itemMasterData.CollisionShapeDistanceToBottomEdgeFromCenter = collisionShapeDistanceToBottomEdgeFromCenter;
            }
        }
    }
}