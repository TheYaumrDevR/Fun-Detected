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
                new UiTextSegment("This is ", false, UiDefaultColors.UNCOLORED),
                new UiTextSegment("bold", true, UiDefaultColors.UNCOLORED),
                new UiTextSegment(" text with ", false, UiDefaultColors.UNCOLORED),
                new UiTextSegment("another bold", true, UiDefaultColors.UNCOLORED),
                new UiTextSegment(" segment.", false, UiDefaultColors.UNCOLORED)
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

        [Test]
        public void TestParseColorsBoldSegmentsWithPassedColor()
        {
            // Arrange
            var input = "This is <b>bold</b> text with <b>another bold</b> segment.";

            // Act
            var result = MarkupTextParser.Parse(input, UiDefaultColors.TEXT_BLUE);

            // Assert
            Assert.That(result, Has.Count.EqualTo(5));
            Assert.That(result[1].IsBold, Is.True);
            Assert.That(result[1].Color, Is.EqualTo(UiDefaultColors.TEXT_BLUE));
            Assert.That(result[3].IsBold, Is.True);
            Assert.That(result[3].Color, Is.EqualTo(UiDefaultColors.TEXT_BLUE));
        }

        [Test]
        public void TestParseKeepsNonBoldSegmentsUncoloredWhenBoldColorIsPassed()
        {
            // Arrange
            var input = "This is <b>bold</b> text with <b>another bold</b> segment.";

            // Act
            var result = MarkupTextParser.Parse(input, UiDefaultColors.TEXT_BLUE);

            // Assert
            Assert.That(result, Has.Count.EqualTo(5));
            Assert.That(result[0].IsBold, Is.False);
            Assert.That(result[0].Color, Is.EqualTo(UiDefaultColors.UNCOLORED));
            Assert.That(result[2].IsBold, Is.False);
            Assert.That(result[2].Color, Is.EqualTo(UiDefaultColors.UNCOLORED));
            Assert.That(result[4].IsBold, Is.False);
            Assert.That(result[4].Color, Is.EqualTo(UiDefaultColors.UNCOLORED));
        }
    }
}