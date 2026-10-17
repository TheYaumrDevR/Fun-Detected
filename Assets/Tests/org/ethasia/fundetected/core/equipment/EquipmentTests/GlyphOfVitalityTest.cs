using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Items.Consumables.Glyphs;

namespace Org.Ethasia.Fundetected.Core.Equipment.Tests
{
    public class GlyphOfVitalityTest
    {
        [Test]
        public void TestCloneInstancesAreDifferent()
        {
            GlyphOfVitality testCandidate = CreateTestGlyphOfVitality();
            GlyphOfVitality clone = testCandidate.Clone() as GlyphOfVitality;

            Assert.AreNotSame(testCandidate, clone);
            Assert.AreNotSame(testCandidate.CollisionShape, clone.CollisionShape);
        }

        [Test]
        public void TestCloneInstancesHaveSameValues()
        {
            GlyphOfVitality testCandidate = CreateTestGlyphOfVitality();
            GlyphOfVitality clone = testCandidate.Clone() as GlyphOfVitality;

            Assert.That(clone.StackSize, Is.EqualTo(testCandidate.StackSize));
            Assert.That(clone.Name, Is.EqualTo(testCandidate.Name));
            Assert.That(clone.ItemClass, Is.EqualTo(testCandidate.ItemClass));
            Assert.That(clone.MinimumItemLevel, Is.EqualTo(testCandidate.MinimumItemLevel));
            Assert.That(clone.ItemLevel, Is.EqualTo(testCandidate.ItemLevel));
            Assert.That(clone.CollisionShape.CollisionShapeDistanceToLeftEdgeFromCenter, Is.EqualTo(testCandidate.CollisionShape.CollisionShapeDistanceToLeftEdgeFromCenter));
            Assert.That(clone.CollisionShape.CollisionShapeDistanceToRightEdgeFromCenter, Is.EqualTo(testCandidate.CollisionShape.CollisionShapeDistanceToRightEdgeFromCenter));
            Assert.That(clone.CollisionShape.CollisionShapeDistanceToTopEdgeFromCenter, Is.EqualTo(testCandidate.CollisionShape.CollisionShapeDistanceToTopEdgeFromCenter));
            Assert.That(clone.CollisionShape.CollisionShapeDistanceToBottomEdgeFromCenter, Is.EqualTo(testCandidate.CollisionShape.CollisionShapeDistanceToBottomEdgeFromCenter));
        }

        private GlyphOfVitality CreateTestGlyphOfVitality()
        {
            GlyphOfVitality.Builder builder = new GlyphOfVitality.Builder();

            builder.SetStackSize(8);

            builder.SetName("Glyph of Vitality")
                .SetItemClass(ItemClass.GLYPH)
                .SetMinimumItemLevel(2)
                .SetItemLevel(6)
                .SetCollisionShapeDistanceToLeftEdgeFromCenter(1)
                .SetCollisionShapeDistanceToRightEdgeFromCenter(1)
                .SetCollisionShapeDistanceToTopEdgeFromCenter(2)
                .SetCollisionShapeDistanceToBottomEdgeFromCenter(2);

            return builder.Build();
        }
    }
}