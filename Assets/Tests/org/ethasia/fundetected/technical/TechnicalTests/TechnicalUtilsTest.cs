using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Technical.Tests
{
    public class TechnicalUtilsTest
    {
        [Test]
        public void TestReplacePlaceHoldersInTextForSimpleText()
        {
            string text = "Error {0} occurred in module {1} at time {2}";

            List<string> insertedTexts = new List<string>();
            insertedTexts.Add("Connection Failure");
            insertedTexts.Add("Network");
            insertedTexts.Add("12:34");

            string result = TechnicalUtils.ReplacePlaceHoldersInText(text, insertedTexts);

            Assert.That(result, Is.EqualTo("Error Connection Failure occurred in module Network at time 12:34"));
        }

        [Test]
        public void TestReplacePlaceHoldersInTextWithMorePlaceHoldersThanInsertedTexts()
        {
            string text = "Error {0} occurred in module {1} at time {2}";

            List<string> insertedTexts = new List<string>();
            insertedTexts.Add("Connection Failure");
            insertedTexts.Add("Network");

            string result = TechnicalUtils.ReplacePlaceHoldersInText(text, insertedTexts);

            Assert.That(result, Is.EqualTo("Error Connection Failure occurred in module Network at time {2}"));
        }

        [Test]	
        public void TestReplacePlaceHoldersInTextWithMoreInsertedTextsThanPlaceHolders()
        {
            string text = "Error {0} occurred in module {1} at time {2}";

            List<string> insertedTexts = new List<string>();
            insertedTexts.Add("Connection Failure");
            insertedTexts.Add("Network");
            insertedTexts.Add("12:34");
            insertedTexts.Add("Some other text");

            string result = TechnicalUtils.ReplacePlaceHoldersInText(text, insertedTexts);

            Assert.That(result, Is.EqualTo("Error Connection Failure occurred in module Network at time 12:34"));
        }

        [Test]
        public void TestReplacePlaceHoldersInTextForSimpleTextWithArray()
        {
            string text = "Error {0} occurred in module {1} at time {2}";

            string result = TechnicalUtils.ReplacePlaceHoldersInText(text, "Connection Failure", "Network", "12:34");

            Assert.That(result, Is.EqualTo("Error Connection Failure occurred in module Network at time 12:34"));
        }

        [Test]
        public void TestReplacePlaceHoldersInTextWithMorePlaceHoldersThanInsertedTextsForArray()
        {
            string text = "Error {0} occurred in module {1} at time {2}";

            string result = TechnicalUtils.ReplacePlaceHoldersInText(text, "Connection Failure", "Network");

            Assert.That(result, Is.EqualTo("Error Connection Failure occurred in module Network at time {2}"));
        }

        [Test]
        public void TestReplacePlaceHoldersInTextWithMoreInsertedTextsThanPlaceHoldersForArray()
        {
            string text = "Error {0} occurred in module {1} at time {2}";

            string result = TechnicalUtils.ReplacePlaceHoldersInText(text, "Connection Failure", "Network", "12:34", "Some other text");

            Assert.That(result, Is.EqualTo("Error Connection Failure occurred in module Network at time 12:34"));
        }
    }
}