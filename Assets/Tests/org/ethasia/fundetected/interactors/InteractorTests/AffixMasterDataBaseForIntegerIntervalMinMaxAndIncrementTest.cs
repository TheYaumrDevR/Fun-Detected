using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Equipment.Affixes;
using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Interactors.Tests
{
    public class AffixMasterDataBaseForIntegerIntervalMinMaxAndIncrementTest
    {
        [Test]
        public void TestToRollableEquipmentAffix_CreatesCorrectAffixInstance()
        {
            AffixMasterDataBaseForIntegerIntervalMinMaxAndIncrement masterData = 
                new AffixMasterDataBaseForIntegerIntervalMinMaxAndIncrement.Builder()
                    .SetLowerBoundMinValue(5)
                    .SetLowerBoundMaxValue(15)
                    .SetLowerBoundIncrement(1)
                    .SetUpperBoundMinValue(40)
                    .SetUpperBoundMaxValue(75)
                    .SetUpperBoundIncrement(1)
                    .SetAffixClass(AffixClasses.PlusGlobalMinMaxDamageToAttacks)
                    .Build();

            var result = masterData.ToRollableEquipmentAffix();
            var expected = new IntegerIntervalMinMaxIncrementRollableEquipmentAffix.Builder()
                .SetLowerBoundMinValue(5)
                .SetLowerBoundMaxValue(15)
                .SetLowerBoundIncrement(1)
                .SetUpperBoundMinValue(40)
                .SetUpperBoundMaxValue(75)
                .SetUpperBoundIncrement(1)
                .SetRerolledAffix(new PlusMinMaxGlobalPhysicalDamageWithAttacksAffix(0, 0))
                .Build();

            Assert.That(result.Equals(expected), Is.True);
        }
    }
}