using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Equipment.Affixes;
using Org.Ethasia.Fundetected.Core.Items;

namespace Org.Ethasia.Fundetected.Core.Equipment.Tests
{
    public class ArmorTest
    {
        [Test]
        public void TestCloneInstancesAreDifferent()
        {
            Armor testCandidate = CreateTestArmor();
            Armor clone = testCandidate.Clone() as Armor;

            Assert.AreNotSame(testCandidate, clone);
            Assert.AreNotSame(testCandidate.LocalModifiers, clone.LocalModifiers);
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
            Armor testCandidate = CreateTestArmor();
            Armor clone = testCandidate.Clone() as Armor;

            Assert.That(clone.ArmorValue, Is.EqualTo(testCandidate.ArmorValue));
            Assert.That(clone.MovementSpeedAddend, Is.EqualTo(testCandidate.MovementSpeedAddend));
            Assert.That(clone.LocalModifiers.IncreasedArmorInPercent, Is.EqualTo(testCandidate.LocalModifiers.IncreasedArmorInPercent));
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

        private Armor CreateTestArmor()
        {
            Armor.Builder builder = new Armor.Builder();
            builder.SetMovementSpeedAddend(5)
                .SetArmorValue(250);

            IntegerMinMaxIncrementRollableEquipmentAffix firstImplicit = new IntegerMinMaxIncrementRollableEquipmentAffix(new PlusAllElementalResistancesAffix(9));
            PlusAgilityAffix suffixOne = new PlusAgilityAffix(23);
            IncreasedLocalArmourAffix prefixOne = new IncreasedLocalArmourAffix(10);
            IncreasedMaximumLifeAffix prefixTwo = new IncreasedMaximumLifeAffix(80);

            builder.SetStrengthRequirement(32)
                .SetAgilityRequirement(0)
                .SetIntelligenceRequirement(0)
                .AddAffix(prefixOne)
                .AddAffix(suffixOne)
                .AddAffix(prefixTwo)
                .SetFirstImplicit(firstImplicit);

            builder.SetName("Test Armor")
                .SetItemClass(ItemClass.BODY_ARMOR)
                .SetMinimumItemLevel(62)
                .SetItemLevel(73)
                .SetCollisionShapeDistanceToLeftEdgeFromCenter(3)
                .SetCollisionShapeDistanceToRightEdgeFromCenter(3)
                .SetCollisionShapeDistanceToTopEdgeFromCenter(4)
                .SetCollisionShapeDistanceToBottomEdgeFromCenter(4);

            return builder.Build();
        }
    }
}