using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Equipment.Affixes;
using Org.Ethasia.Fundetected.Core.Items;

namespace Org.Ethasia.Fundetected.Core.Equipment.Tests
{
    public class JewelryTest
    {
        [Test]
        public void TestCloneInstancesAreDifferent()
        {
            Jewelry testCandidate = CreateTestJewelry();
            Jewelry clone = testCandidate.Clone() as Jewelry;

            Assert.AreNotSame(testCandidate, clone);
            Assert.AreNotSame(testCandidate.FirstImplicit, clone.FirstImplicit);
            Assert.AreNotSame(testCandidate.CollisionShape, clone.CollisionShape);

            for (int i = 0; i < testCandidate.Prefixes.Count; i++)
            {
                Assert.AreNotSame(testCandidate.Prefixes[i], clone.Prefixes[i]);
            }

            for (int i = 0; i < testCandidate.Suffixes.Count; i++)
            {
                Assert.AreNotSame(testCandidate.Suffixes[i], clone.Suffixes[i]);
            }
        }

        [Test]
        public void TestCloneInstancesHaveSameValues()
        {
            Jewelry testCandidate = CreateTestJewelry();
            Jewelry clone = testCandidate.Clone() as Jewelry;

            Assert.That(clone.StrengthRequirement, Is.EqualTo(testCandidate.StrengthRequirement));
            Assert.That(clone.AgilityRequirement, Is.EqualTo(testCandidate.AgilityRequirement));
            Assert.That(clone.IntelligenceRequirement, Is.EqualTo(testCandidate.IntelligenceRequirement));
            Assert.That(clone.Name, Is.EqualTo(testCandidate.Name));
            Assert.That(clone.ItemClass, Is.EqualTo(testCandidate.ItemClass));
            Assert.That(clone.MinimumItemLevel, Is.EqualTo(testCandidate.MinimumItemLevel));
            Assert.That(clone.ItemLevel, Is.EqualTo(testCandidate.ItemLevel));
            Assert.That(clone.CollisionShape.CollisionShapeDistanceToLeftEdgeFromCenter, Is.EqualTo(testCandidate.CollisionShape.CollisionShapeDistanceToLeftEdgeFromCenter));
            Assert.That(clone.CollisionShape.CollisionShapeDistanceToRightEdgeFromCenter, Is.EqualTo(testCandidate.CollisionShape.CollisionShapeDistanceToRightEdgeFromCenter));
            Assert.That(clone.CollisionShape.CollisionShapeDistanceToTopEdgeFromCenter, Is.EqualTo(testCandidate.CollisionShape.CollisionShapeDistanceToTopEdgeFromCenter));
            Assert.That(clone.CollisionShape.CollisionShapeDistanceToBottomEdgeFromCenter, Is.EqualTo(testCandidate.CollisionShape.CollisionShapeDistanceToBottomEdgeFromCenter));
        }

        private Jewelry CreateTestJewelry()
        {
            Jewelry.Builder builder = new Jewelry.Builder();

            IntegerMinMaxIncrementRollableEquipmentAffix firstImplicit = new IntegerMinMaxIncrementRollableEquipmentAffix(new PlusMaximumFireResistanceAffix(1));
            PlusAllElementalResistancesAffix suffixOne = new PlusAllElementalResistancesAffix(12);
            PlusAllSocketedSpellsLevelAffix prefixOne = new PlusAllSocketedSpellsLevelAffix(1);
            PlusMaximumLifeAffix prefixTwo = new PlusMaximumLifeAffix(43);

            builder.SetStrengthRequirement(6)
                .SetAgilityRequirement(3)
                .SetIntelligenceRequirement(1)
                .AddAffix(prefixOne)
                .AddAffix(suffixOne)
                .AddAffix(prefixTwo)
                .SetFirstImplicit(firstImplicit);

            builder.SetName("Test Jewelry")
                .SetItemClass(ItemClass.AMULET)
                .SetMinimumItemLevel(32)
                .SetItemLevel(40)
                .SetCollisionShapeDistanceToLeftEdgeFromCenter(1)
                .SetCollisionShapeDistanceToRightEdgeFromCenter(1)
                .SetCollisionShapeDistanceToTopEdgeFromCenter(2)
                .SetCollisionShapeDistanceToBottomEdgeFromCenter(2);

            return builder.Build();
        }
    }
}
