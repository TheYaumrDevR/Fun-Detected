using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Equipment.Affixes;

namespace Org.Ethasia.Fundetected.Tests.Core.Equipment
{
    public class EquipmentTest
    {
        private const int MAX_AFFIXES_PER_TYPE = 3;

        private Jewelry testCandidate;

        [SetUp]
        public void SetUp()
        {
            testCandidate = new Jewelry.Builder().Build();
        }

        [Test]
        public void TryAddAffix_ShouldAddPrefix_WhenPrefixesNotFull()
        {
            bool result = testCandidate.TryAddAffix(new PlusGlobalArmorAffix(5));

            Assert.IsTrue(result);
            Assert.AreEqual(1, testCandidate.Prefixes.Count);
            Assert.AreEqual(0, testCandidate.Suffixes.Count);
        }

        [Test]
        public void TryAddAffix_ShouldAddSuffix_WhenSuffixesNotFull()
        {
            bool result = testCandidate.TryAddAffix(new PlusStrengthAffix(5));

            Assert.IsTrue(result);
            Assert.AreEqual(1, testCandidate.Suffixes.Count);
            Assert.AreEqual(0, testCandidate.Prefixes.Count);
        }

        [Test]
        public void TryAddAffix_ShouldAddPrefix_WhenPrefixCountIsOneBelowMaximum()
        {
            FillPrefixes(MAX_AFFIXES_PER_TYPE - 1);

            bool result = testCandidate.TryAddAffix(new PlusGlobalArmorAffix(5));

            Assert.IsTrue(result);
            Assert.AreEqual(MAX_AFFIXES_PER_TYPE, testCandidate.Prefixes.Count);
        }

        [Test]
        public void TryAddAffix_ShouldAddSuffix_WhenSuffixCountIsOneBelowMaximum()
        {
            FillSuffixes(MAX_AFFIXES_PER_TYPE - 1);

            bool result = testCandidate.TryAddAffix(new PlusStrengthAffix(5));

            Assert.IsTrue(result);
            Assert.AreEqual(MAX_AFFIXES_PER_TYPE, testCandidate.Suffixes.Count);
        }

        [Test]
        public void TryAddAffix_ShouldRejectPrefix_WhenPrefixesFull()
        {
            FillPrefixes(MAX_AFFIXES_PER_TYPE);

            bool result = testCandidate.TryAddAffix(new PlusGlobalArmorAffix(5));

            Assert.IsFalse(result);
            Assert.AreEqual(MAX_AFFIXES_PER_TYPE, testCandidate.Prefixes.Count);
        }

        [Test]
        public void TryAddAffix_ShouldRejectSuffix_WhenSuffixesFull()
        {
            FillSuffixes(MAX_AFFIXES_PER_TYPE);

            bool result = testCandidate.TryAddAffix(new PlusStrengthAffix(5));

            Assert.IsFalse(result);
            Assert.AreEqual(MAX_AFFIXES_PER_TYPE, testCandidate.Suffixes.Count);
        }

        [Test]
        public void TryAddAffix_ShouldAddSuffix_WhenOnlyPrefixesFull()
        {
            FillPrefixes(MAX_AFFIXES_PER_TYPE);

            bool result = testCandidate.TryAddAffix(new PlusStrengthAffix(5));

            Assert.IsTrue(result);
            Assert.AreEqual(MAX_AFFIXES_PER_TYPE, testCandidate.Prefixes.Count);
            Assert.AreEqual(1, testCandidate.Suffixes.Count);
        }

        [Test]
        public void TryAddAffix_ShouldAddPrefix_WhenOnlySuffixesFull()
        {
            FillSuffixes(MAX_AFFIXES_PER_TYPE);

            bool result = testCandidate.TryAddAffix(new PlusGlobalArmorAffix(5));

            Assert.IsTrue(result);
            Assert.AreEqual(MAX_AFFIXES_PER_TYPE, testCandidate.Suffixes.Count);
            Assert.AreEqual(1, testCandidate.Prefixes.Count);
        }

        private void FillPrefixes(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Assert.IsTrue(testCandidate.TryAddAffix(new PlusGlobalArmorAffix(i + 1)));
            }
        }

        private void FillSuffixes(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Assert.IsTrue(testCandidate.TryAddAffix(new PlusStrengthAffix(i + 1)));
            }
        }        
    }
}