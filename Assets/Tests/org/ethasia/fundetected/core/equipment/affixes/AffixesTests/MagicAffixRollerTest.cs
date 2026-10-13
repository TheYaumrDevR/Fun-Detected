using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Ioadapters.Mocks;

namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes.Tests
{
    public class MagicAffixRollerTest
    {
        private Jewelry itemToRollOn;
        private ConfigurableRandomNumberGeneratorStub rng;

        [SetUp]
        public void SetUp()
        {
            rng = new ConfigurableRandomNumberGeneratorStub();

            var factory = new MockedIoAdaptersFactoryForCore();
            factory.SetRngInstance(rng);
            IoAdaptersFactoryForCore.SetInstance(factory);

            itemToRollOn = new Jewelry.Builder().Build();
        }

        [Test]
        public void RollMagicAffixes_ShouldAddExactlyOneAffix_WhenOnlyOneAffixHasToBeRolled()
        {
            rng.OnlyOneAffix = true;
            var testCandidate = new MagicAffixRoller();

            testCandidate.RollMagicAffixes(itemToRollOn, CreatePrefixTable(), CreateSuffixTable());

            Assert.That(itemToRollOn.Prefixes.Count + itemToRollOn.Suffixes.Count, Is.EqualTo(1));
        }

        [Test]
        public void RollMagicAffixes_ShouldAddOnePrefixAndOneSuffix_WhenTwoAffixesHaveToBeRolled()
        {
            rng.OnlyOneAffix = false;
            var testCandidate = new MagicAffixRoller();

            testCandidate.RollMagicAffixes(itemToRollOn, CreatePrefixTable(), CreateSuffixTable());

            Assert.That(itemToRollOn.Prefixes.Count, Is.EqualTo(1));
            Assert.That(itemToRollOn.Suffixes.Count, Is.EqualTo(1));
        }

        [Test]
        public void RollMagicAffixes_ShouldNotAddAffix_WhenItemLevelIsBelowMinItemLevelOfAllEntries()
        {
            rng.OnlyOneAffix = false;
            var testCandidate = new MagicAffixRoller();

            var prefixTable = new AffixRollCalculationTableMasterData.Builder()
                .AddRollableAffix(CreateEntry(new PlusGlobalArmorAffix(0), 1000, 1000))
                .Build();
            var suffixTable = new AffixRollCalculationTableMasterData.Builder()
                .AddRollableAffix(CreateEntry(new PlusStrengthAffix(0), 1000, 1000))
                .Build();

            testCandidate.RollMagicAffixes(itemToRollOn, prefixTable, suffixTable);

            Assert.That(itemToRollOn.Prefixes.Count, Is.EqualTo(0));
            Assert.That(itemToRollOn.Suffixes.Count, Is.EqualTo(0));
        }

        [Test]
        public void RollMagicAffixes_ShouldOnlyPickEligibleEntry_WhenOtherEntryRequiresHigherItemLevel()
        {
            rng.OnlyOneAffix = false;
            rng.RolledInteger = 0;
            var testCandidate = new MagicAffixRoller();

            var prefixTable = new AffixRollCalculationTableMasterData.Builder()
                .AddRollableAffix(CreateEntry(new PlusGlobalArmorAffix(0), 1000, 1000))
                .AddRollableAffix(CreateEntry(new PlusMaximumLifeAffix(0), 0, 1000))
                .Build();

            testCandidate.RollMagicAffixes(itemToRollOn, prefixTable, CreateSuffixTable());

            Assert.That(itemToRollOn.Prefixes.Count, Is.EqualTo(1));
            Assert.That(itemToRollOn.Prefixes[0], Is.TypeOf<PlusMaximumLifeAffix>());
        }

        [Test]
        public void RollMagicAffixes_ShouldAddFirstEntry_WhenRollIsWithinWeightingOfFirstEntry()
        {
            rng.OnlyOneAffix = false;
            rng.RolledInteger = 499;
            var testCandidate = new MagicAffixRoller();

            testCandidate.RollMagicAffixes(itemToRollOn, CreateWeightedPrefixTable(), CreateSuffixTable());

            Assert.That(itemToRollOn.Prefixes[0], Is.TypeOf<PlusGlobalArmorAffix>());
        }

        [Test]
        public void RollMagicAffixes_ShouldAddSecondEntry_WhenRollExceedsWeightingOfFirstEntry()
        {
            rng.OnlyOneAffix = false;
            rng.RolledInteger = 500;
            var testCandidate = new MagicAffixRoller();

            testCandidate.RollMagicAffixes(itemToRollOn, CreateWeightedPrefixTable(), CreateSuffixTable());

            Assert.That(itemToRollOn.Prefixes[0], Is.TypeOf<PlusMaximumLifeAffix>());
        }

        [Test]
        public void RollMagicAffixes_ShouldNotAddAffix_WhenTotalWeightIsZeroAndTwoAffixesHaveToBeRolled()
        {
            rng.OnlyOneAffix = false;
            var testCandidate = new MagicAffixRoller();

            testCandidate.RollMagicAffixes(itemToRollOn, CreateZeroWeightPrefixTable(), CreateZeroWeightSuffixTable());

            Assert.That(itemToRollOn.Prefixes.Count, Is.EqualTo(0));
            Assert.That(itemToRollOn.Suffixes.Count, Is.EqualTo(0));
        }

        [Test]
        public void RollMagicAffixes_ShouldNotAddAffix_WhenTotalWeightIsZeroAndOnlyOneAffixHasToBeRolled()
        {
            rng.OnlyOneAffix = true;
            var testCandidate = new MagicAffixRoller();

            testCandidate.RollMagicAffixes(itemToRollOn, CreateZeroWeightPrefixTable(), CreateZeroWeightSuffixTable());

            Assert.That(itemToRollOn.Prefixes.Count, Is.EqualTo(0));
            Assert.That(itemToRollOn.Suffixes.Count, Is.EqualTo(0));
        }

        private static AffixRollCalculationTableMasterData CreateZeroWeightPrefixTable()
        {
            return new AffixRollCalculationTableMasterData.Builder()
                .AddRollableAffix(CreateEntry(new PlusGlobalArmorAffix(0), 0, 0))
                .Build();
        }

        private static AffixRollCalculationTableMasterData CreateZeroWeightSuffixTable()
        {
            return new AffixRollCalculationTableMasterData.Builder()
                .AddRollableAffix(CreateEntry(new PlusStrengthAffix(0), 0, 0))
                .Build();
        }

        private static AffixRollCalculationTableMasterData CreateWeightedPrefixTable()
        {
            return new AffixRollCalculationTableMasterData.Builder()
                .AddRollableAffix(CreateEntry(new PlusGlobalArmorAffix(0), 0, 500))
                .AddRollableAffix(CreateEntry(new PlusMaximumLifeAffix(0), 0, 500))
                .Build();
        }

        private static AffixRollCalculationTableMasterData CreatePrefixTable()
        {
            return new AffixRollCalculationTableMasterData.Builder()
                .AddRollableAffix(CreateEntry(new PlusGlobalArmorAffix(0), 0, 1000))
                .Build();
        }

        private static AffixRollCalculationTableMasterData CreateSuffixTable()
        {
            return new AffixRollCalculationTableMasterData.Builder()
                .AddRollableAffix(CreateEntry(new PlusStrengthAffix(0), 0, 1000))
                .Build();
        }

        private static AffixRollCalculationTableEntryMasterData CreateEntry(
            EquipmentAffix baseAffix,
            int minItemLevel,
            int weighting)
        {
            return new AffixRollCalculationTableEntryMasterData.Builder()
                .SetTier(1)
                .SetMinItemLevel(minItemLevel)
                .SetWeighting(weighting)
                .SetRollableAffix(new IntegerMinMaxIncrementRollableEquipmentAffix.Builder()
                    .SetRerolledAffix(baseAffix)
                    .SetMinValue(1)
                    .SetMaxValue(1)
                    .SetIncrement(1)
                    .Build())
                .Build();
        }

        private class ConfigurableRandomNumberGeneratorStub : IRandomNumberGenerator
        {
            public bool OnlyOneAffix { get; set; }
            public int RolledInteger { get; set; }

            public int GenerateIntegerBetweenAnd(int min, int max) { return min; }

            public int GenerateIntegerBetweenAndWithStep(int min, int max, int step) { return min; }

            public int GenerateRandomPositiveInteger(int max) { return RolledInteger; }

            public bool CheckProbabilityIsHit(float probability) { return OnlyOneAffix; }

            public bool CheckProbabilityIsHit(double probability) { return OnlyOneAffix; }

            public double GenerateDoubleBetweenZeroAndOne() { return 0; }
        }
    }
}