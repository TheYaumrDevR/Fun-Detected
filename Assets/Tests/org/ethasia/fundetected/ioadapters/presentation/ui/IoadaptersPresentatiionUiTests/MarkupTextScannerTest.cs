using NUnit.Framework;

namespace Org.Ethasia.Fundetected.Ioadapters.Presentation.UI.Tests
{
    public class MarkupTextScannerTest
    {
        [Test]
        public void TestScanNextForSimpleTextOnlyReturnsTheSimpleText()
        {
            var testCandidate = new MarkupTextScanner("Hello, world!");

            Assert.That(testCandidate.ScanNext(), Is.True);
            Assert.That(testCandidate.CurrentToken.Type, Is.EqualTo(TokenType.Text));
            Assert.That(testCandidate.CurrentToken.Content.ToString(), Is.EqualTo("Hello, world!"));

            Assert.That(testCandidate.ScanNext(), Is.False);
        }

        [Test]
        public void TestScanNextForTextWithBoldTags()
        {
            var testCandidate = new MarkupTextScanner("Has <b>30</b> uses remaining");

            Assert.That(testCandidate.ScanNext(), Is.True);
            Assert.That(testCandidate.CurrentToken.Type, Is.EqualTo(TokenType.Text));
            Assert.That(testCandidate.CurrentToken.Content.ToString(), Is.EqualTo("Has "));
            Assert.That(testCandidate.ScanNext(), Is.True);
            Assert.That(testCandidate.CurrentToken.Type, Is.EqualTo(TokenType.BoldStart));
            Assert.That(testCandidate.CurrentToken.Content.ToString(), Is.EqualTo("<b>"));
            Assert.That(testCandidate.ScanNext(), Is.True);
            Assert.That(testCandidate.CurrentToken.Type, Is.EqualTo(TokenType.Text));
            Assert.That(testCandidate.CurrentToken.Content.ToString(), Is.EqualTo("30"));
            Assert.That(testCandidate.ScanNext(), Is.True);
            Assert.That(testCandidate.CurrentToken.Type, Is.EqualTo(TokenType.BoldEnd));
            Assert.That(testCandidate.CurrentToken.Content.ToString(), Is.EqualTo("</b>"));
            Assert.That(testCandidate.ScanNext(), Is.True);
            Assert.That(testCandidate.CurrentToken.Type, Is.EqualTo(TokenType.Text));
            Assert.That(testCandidate.CurrentToken.Content.ToString(), Is.EqualTo(" uses remaining"));

            Assert.That(testCandidate.ScanNext(), Is.False);
        }

        [Test]
        public void TestScanNextForTextWithTwoBoldTags()
        {
            var testCandidate = new MarkupTextScanner("Restores <b>20</b> life and <b>20</b> mana");
            
            Assert.That(testCandidate.ScanNext(), Is.True);
            Assert.That(testCandidate.CurrentToken.Type, Is.EqualTo(TokenType.Text));
            Assert.That(testCandidate.CurrentToken.Content.ToString(), Is.EqualTo("Restores "));
            Assert.That(testCandidate.ScanNext(), Is.True);
            Assert.That(testCandidate.CurrentToken.Type, Is.EqualTo(TokenType.BoldStart));
            Assert.That(testCandidate.CurrentToken.Content.ToString(), Is.EqualTo("<b>"));
            Assert.That(testCandidate.ScanNext(), Is.True);
            Assert.That(testCandidate.CurrentToken.Type, Is.EqualTo(TokenType.Text));
            Assert.That(testCandidate.CurrentToken.Content.ToString(), Is.EqualTo("20"));
            Assert.That(testCandidate.ScanNext(), Is.True);
            Assert.That(testCandidate.CurrentToken.Type, Is.EqualTo(TokenType.BoldEnd));
            Assert.That(testCandidate.CurrentToken.Content.ToString(), Is.EqualTo("</b>"));
            Assert.That(testCandidate.ScanNext(), Is.True);
            Assert.That(testCandidate.CurrentToken.Type, Is.EqualTo(TokenType.Text));
            Assert.That(testCandidate.CurrentToken.Content.ToString(), Is.EqualTo(" life and "));
            Assert.That(testCandidate.ScanNext(), Is.True);
            Assert.That(testCandidate.CurrentToken.Type, IsEqualTo(TokenType.BoldStart));
            Assert.That(testCandidate.CurrentToken.Content.ToString(), Is.EqualTo("<b>"));
            Assert.That(testCandidate.ScanNext(), Is.True);
            Assert.That(testCandidate.CurrentToken.Type, Is.EqualTo(TokenType.Text));
            Assert.That(testCandidate.CurrentToken.Content.ToString(), Is.EqualTo("20"));
            Assert.That(testCandidate.ScanNext(), Is.True);
            Assert.That(testCandidate.CurrentToken.Type, Is.EqualTo(TokenType.BoldEnd));
            Assert.That(testCandidate.CurrentToken.Content.ToString(), Is.EqualTo("</b>"));
            Assert.That(testCandidate.ScanNext(), Is.True);
            Assert.That(testCandidate.CurrentToken.Type, Is.EqualTo(TokenType.Text));
            Assert.That(testCandidate.CurrentToken.Content.ToString(), Is.EqualTo(" mana"));

            Assert.That(testCandidate.ScanNext(), Is.False);
        }
    }
}