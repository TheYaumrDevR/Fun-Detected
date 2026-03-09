using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Ioadapters.Presentation.UI.Tests
{

    public class MarkupTextParserTest
    {
        [Test]
        public void TestParseMarksBoldSegmentBetweenNormalText()
        {
            // Arrange
            var input = "This is <b>bold</b> text.";

            // Act
            var result = MarkupTextParser.Parse(input);

            // Assert
            Assert.That(result, Has.Count.EqualTo(3));
            Assert.That(result[0].Text, Is.EqualTo("This is "));
            Assert.That(result[0].IsBold, Is.False);
            Assert.That(result[1].Text, Is.EqualTo("bold"));
            Assert.That(result[1].IsBold, Is.True);
            Assert.That(result[2].Text, Is.EqualTo(" text."));
            Assert.That(result[2].IsBold, Is.False);
        }

        [Test]
        public void TestParseMarksTwoBoldSegments()
        {
            // Arrange
            var input = "This is <b>bold</b> text with <b>another bold</b> segment.";
            var expected = new List<UiTextSegment>
            {
                new UiTextSegment("This is ", false),
                new UiTextSegment("bold", true),
                new UiTextSegment(" text with ", false),
                new UiTextSegment("another bold", true),
                new UiTextSegment(" segment.", false)
            };

            // Act
            var result = MarkupTextParser.Parse(input);

            // Assert
            Assert.That(result, Has.Count.EqualTo(expected.Count));
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.That(result[i].Text, Is.EqualTo(expected[i].Text));
                Assert.That(result[i].IsBold, Is.EqualTo(expected[i].IsBold));
            }
        }

        [Test]
        public void TestParseHasOnlyNormalText()
        {
            // Arrange
            var input = "This is normal text.";

            // Act
            var result = MarkupTextParser.Parse(input);

            // Assert
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Text, Is.EqualTo(input));
            Assert.That(result[0].IsBold, Is.False);
        }

        [Test]
        public void TestParseHasOnlyBoldText()
        {
            // Arrange
            var input = "<b>This is bold text.</b>";

            // Act
            var result = MarkupTextParser.Parse(input);

            // Assert
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Text, Is.EqualTo("This is bold text."));
            Assert.That(result[0].IsBold, Is.True);
        }
    }
}