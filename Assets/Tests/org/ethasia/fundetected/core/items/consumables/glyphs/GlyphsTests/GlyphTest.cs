using NUnit.Framework;

namespace Org.Ethasia.Fundetected.Core.Items.Consumables.Glyphs.Tests
{
    public class GlyphTest
    {
        [Test]
        public void TestBuildGlyphHasMaximumStackSizeTen()
        {
            GlyphOfVitality.Builder testCandidate = new GlyphOfVitality.Builder();

            GlyphOfVitality result = testCandidate.Build();

            Assert.That(result.MaximumStackSize, Is.EqualTo(10));
        }

        [Test]
        public void TestBuildGlyphCanBeBuiltWithAnyStacksize()
        {
            GlyphOfVitality.Builder testCandidate = new GlyphOfVitality.Builder();
            testCandidate.SetStackSize(5);

            GlyphOfVitality result = testCandidate.Build();

            Assert.That(result.StackSize, Is.EqualTo(5));
        }
    }
}