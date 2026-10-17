using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Items.Potions;

namespace Org.Ethasia.Fundetected.Core.Equipment.Tests
{
    public class RecoveryPotionTest
    {
        [Test]
        public void TestCloneInstancesAreDifferent()
        {
            RecoveryPotion testCandidate = CreateTestRecoveryPotion();
            RecoveryPotion clone = testCandidate.Clone() as RecoveryPotion;

            Assert.AreNotSame(testCandidate, clone);
            Assert.AreNotSame(testCandidate.CollisionShape, clone.CollisionShape);
        }

        [Test]
        public void TestCloneInstancesHaveSameValues()
        {
            RecoveryPotion testCandidate = CreateTestRecoveryPotion();
            RecoveryPotion clone = testCandidate.Clone() as RecoveryPotion;

            Assert.That(clone.RecoveryAmount, Is.EqualTo(testCandidate.RecoveryAmount));
            Assert.That(clone.Uses, Is.EqualTo(testCandidate.Uses));
            Assert.That(clone.Name, Is.EqualTo(testCandidate.Name));
            Assert.That(clone.ItemClass, Is.EqualTo(testCandidate.ItemClass));
            Assert.That(clone.MinimumItemLevel, Is.EqualTo(testCandidate.MinimumItemLevel));
            Assert.That(clone.ItemLevel, Is.EqualTo(testCandidate.ItemLevel));
            Assert.That(clone.CollisionShape.CollisionShapeDistanceToLeftEdgeFromCenter, Is.EqualTo(testCandidate.CollisionShape.CollisionShapeDistanceToLeftEdgeFromCenter));
            Assert.That(clone.CollisionShape.CollisionShapeDistanceToRightEdgeFromCenter, Is.EqualTo(testCandidate.CollisionShape.CollisionShapeDistanceToRightEdgeFromCenter));
            Assert.That(clone.CollisionShape.CollisionShapeDistanceToTopEdgeFromCenter, Is.EqualTo(testCandidate.CollisionShape.CollisionShapeDistanceToTopEdgeFromCenter));
            Assert.That(clone.CollisionShape.CollisionShapeDistanceToBottomEdgeFromCenter, Is.EqualTo(testCandidate.CollisionShape.CollisionShapeDistanceToBottomEdgeFromCenter));
        }

        private RecoveryPotion CreateTestRecoveryPotion()
        {
            RecoveryPotion.Builder builder = new RecoveryPotion.Builder();

            builder.SetRecoveryAmount(70);
            builder.SetUses(3);

            builder.SetName("Recovery Potion")
                .SetItemClass(ItemClass.LIFE_POTION)
                .SetMinimumItemLevel(1)
                .SetItemLevel(3)
                .SetCollisionShapeDistanceToLeftEdgeFromCenter(1)
                .SetCollisionShapeDistanceToRightEdgeFromCenter(1)
                .SetCollisionShapeDistanceToTopEdgeFromCenter(2)
                .SetCollisionShapeDistanceToBottomEdgeFromCenter(2);

            return builder.Build();
        }
    }
}