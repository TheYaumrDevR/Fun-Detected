using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Equipment.Affixes;

namespace Org.Ethasia.Fundetected.Ioadapters.Tests
{
    public class RollableAffixesPerItemGroupMasterDataProviderTest
    {
        private const int MAX_COMPARE_DEPTH = 6;

        private RollableAffixesPerItemGroupMasterDataProvider testCandidate;

        [SetUp]
        public void SetUp()
        {
            testCandidate = new RollableAffixesPerItemGroupMasterDataProvider();
        }

        [Test]
        public void CreateTables_WhenBuilt_EachTableIsNotNullAndContainsEntries()
        {
            foreach (var pair in BuildAllTables())
            {
                Assert.That(pair.Value, Is.Not.Null, pair.Key);
                Assert.That(EntriesOf(pair.Value), Is.Not.Empty, pair.Key);
            }
        }

        [Test]
        public void CreateTables_WhenBuilt_UniqueIdsAreUniqueWithinEachTable()
        {
            foreach (var pair in BuildAllTables())
            {
                List<string> duplicates = EntriesOf(pair.Value)
                    .GroupBy(e => e.RollableAffix.UniqueId)
                    .Where(g => g.Count() > 1)
                    .Select(g => g.Key)
                    .ToList();

                Assert.That(duplicates, Is.Empty, pair.Key + " has duplicates: " + string.Join(", ", duplicates));
            }
        }

        [Test]
        public void CreateTables_WhenBuilt_AllEntriesHaveNonEmptyUniqueIdAndPositiveTierAndMinItemLevel()
        {
            foreach (var pair in BuildAllTables())
            {
                foreach (AffixRollCalculationTableEntryMasterData entry in EntriesOf(pair.Value))
                {
                    Assert.That(entry.RollableAffix, Is.Not.Null, pair.Key);

                    string uniqueId = entry.RollableAffix.UniqueId;

                    Assert.That(string.IsNullOrEmpty(uniqueId), Is.False, pair.Key);
                    Assert.That(entry.Tier, Is.GreaterThan(0), pair.Key + "/" + uniqueId);
                    Assert.That(entry.MinItemLevel, Is.GreaterThan(0), pair.Key + "/" + uniqueId);
                }
            }
        }

        [Test]
        public void CreateTables_WhenBuilt_LowerTierNumbersRequireHigherOrEqualMinItemLevelWithinSameAffixGroup()
        {
            var violations = new List<string>();

            foreach (var pair in BuildAllTables())
            {
                // Ids are "<Name><Tier>[Suffix]"; group by the name without digits.
                var groups = EntriesOf(pair.Value).GroupBy(e => new string(e.RollableAffix.UniqueId.Where(c => !char.IsDigit(c)).ToArray()));

                foreach (var group in groups)
                {
                    List<AffixRollCalculationTableEntryMasterData> ordered = group.OrderByDescending(e => e.Tier).ToList();

                    for (int i = 1; i < ordered.Count; i++)
                    {
                        if (ordered[i].MinItemLevel < ordered[i - 1].MinItemLevel)
                        {
                            violations.Add(string.Format("{0}/{1}: tier {2} minItemLevel {3} < tier {4} minItemLevel {5}",
                                pair.Key, ordered[i].RollableAffix.UniqueId, ordered[i].Tier, ordered[i].MinItemLevel,
                                ordered[i - 1].Tier, ordered[i - 1].MinItemLevel));
                        }
                    }
                }
            }

            Assert.That(violations, Is.Empty, string.Join(Environment.NewLine, violations));
        }

        [Test]
        public void CreateTables_WhenEntriesShareUniqueId_TheyHaveIdenticalTierAndRollableAffixValues()
        {
            var mismatches = new List<string>();

            foreach (IGrouping<string, AffixRollCalculationTableEntryMasterData> group in BuildAllEntries().GroupBy(e => e.RollableAffix.UniqueId))
            {
                AffixRollCalculationTableEntryMasterData reference = group.First();

                foreach (AffixRollCalculationTableEntryMasterData other in group.Skip(1))
                {
                    if (reference.Tier != other.Tier)
                    {
                        mismatches.Add(string.Format("{0}: tier {1} != {2}", group.Key, reference.Tier, other.Tier));
                    }

                    var differences = new List<string>();
                    CompareObjects(reference.RollableAffix, other.RollableAffix, "RollableAffix", 0, differences);

                    foreach (string difference in differences)
                    {
                        mismatches.Add(group.Key + ": " + difference);
                    }
                }
            }

            Assert.That(mismatches, Is.Empty, string.Join(Environment.NewLine, mismatches));
        }

        [Test]
        public void CreateTables_WhenBuilt_SomeUniqueIdsAreSharedBetweenTables()
        {
            int sharedIdCount = BuildAllEntries().GroupBy(e => e.RollableAffix.UniqueId).Count(g => g.Count() > 1);

            Assert.That(sharedIdCount, Is.GreaterThan(0));
        }

        [Test]
        public void TryGetAffixByUniqueId_WhenIdExistsInAnyTable_ReturnsTrueAndMatchingEntry()
        {
            foreach (AffixRollCalculationTableEntryMasterData entry in BuildAllEntries())
            {
                string uniqueId = entry.RollableAffix.UniqueId;
                AffixRollCalculationTableEntryMasterData found;

                Assert.That(testCandidate.TryGetAffixByUniqueId(uniqueId, out found), Is.True, uniqueId);
                Assert.That(found.RollableAffix, Is.Not.Null, uniqueId);
                Assert.That(found.RollableAffix.UniqueId, Is.EqualTo(uniqueId));
                Assert.That(found.Tier, Is.EqualTo(entry.Tier), uniqueId);
            }
        }

        [Test]
        public void TryGetAffixByUniqueId_WhenIdIsUnknown_ReturnsFalse()
        {
            AffixRollCalculationTableEntryMasterData found;

            Assert.That(testCandidate.TryGetAffixByUniqueId("DoesNotExist", out found), Is.False);
        }

        private Dictionary<string, AffixRollCalculationTableMasterData> BuildAllTables()
        {
            return new Dictionary<string, AffixRollCalculationTableMasterData>
            {
                { "PrefixesOneHandedSwords", testCandidate.CreateRollablePrefixesForOneHandedSwords() },
                { "SuffixesOneHandedSwords", testCandidate.CreateRollableSuffixesForOneHandedSwords() },
                { "PrefixesRings", testCandidate.CreateRollablePrefixesForRings() },
                { "SuffixesRings", testCandidate.CreateRollableSuffixesForRings() },
                { "PrefixesBelts", testCandidate.CreateRollablePrefixesForBelts() },
                { "SuffixesBelts", testCandidate.CreateRollableSuffixesForBelts() },
                { "PrefixesAmulets", testCandidate.CreateRollablePrefixesForAmulets() },
                { "SuffixesAmulets", testCandidate.CreateRollableSuffixesForAmulets() }
            };
        }

        private List<AffixRollCalculationTableEntryMasterData> BuildAllEntries()
        {
            var entries = new List<AffixRollCalculationTableEntryMasterData>();

            foreach (var table in BuildAllTables().Values)
            {
                foreach (AffixRollCalculationTableEntryMasterData entry in table.RollableAffixes)
                {
                    entries.Add(entry);
                }
            }

            return entries;
        }

        private static List<AffixRollCalculationTableEntryMasterData> EntriesOf(AffixRollCalculationTableMasterData table)
        {
            var entries = new List<AffixRollCalculationTableEntryMasterData>();

            foreach (AffixRollCalculationTableEntryMasterData entry in table.RollableAffixes)
            {
                entries.Add(entry);
            }

            return entries;
        }

        private static void CompareObjects(object expected, object actual, string path, int depth, List<string> differences)
        {
            if (ReferenceEquals(expected, actual))
            {
                return;
            }

            if (null == expected || null == actual)
            {
                differences.Add(path + ": one value is null");
                return;
            }

            Type type = expected.GetType();

            if (type != actual.GetType())
            {
                differences.Add(string.Format("{0}: type {1} != {2}", path, type.Name, actual.GetType().Name));
                return;
            }

            if (type.IsPrimitive || type.IsEnum || type == typeof(string) || type == typeof(decimal))
            {
                if (!expected.Equals(actual))
                {
                    differences.Add(string.Format("{0}: {1} != {2}", path, expected, actual));
                }
                return;
            }

            if (depth >= MAX_COMPARE_DEPTH)
            {
                return;
            }

            if (expected is IEnumerable && actual is IEnumerable)
            {
                var expectedItems = ((IEnumerable)expected).Cast<object>().ToList();
                var actualItems = ((IEnumerable)actual).Cast<object>().ToList();

                if (expectedItems.Count != actualItems.Count)
                {
                    differences.Add(string.Format("{0}: count {1} != {2}", path, expectedItems.Count, actualItems.Count));
                    return;
                }

                for (int i = 0; i < expectedItems.Count; i++)
                {
                    CompareObjects(expectedItems[i], actualItems[i], path + "[" + i + "]", depth + 1, differences);
                }
                return;
            }

            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.GetIndexParameters().Length > 0 || !property.CanRead)
                {
                    continue;
                }

                CompareObjects(property.GetValue(expected, null), property.GetValue(actual, null), path + "." + property.Name, depth + 1, differences);
            }

            foreach (FieldInfo field in type.GetFields(BindingFlags.Public | BindingFlags.Instance))
            {
                CompareObjects(field.GetValue(expected), field.GetValue(actual), path + "." + field.Name, depth + 1, differences);
            }
        }
    }
}