using NUnit.Framework;

namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes.Tests
{
    public class IntegerIntervalMinMaxIncrementRollableEquipmentAffixTest
    {
        [Test]
        public void TestEqualsNullParameter_ReturnsFalse()
        {
            // Arrange
            var affix1 = new IntegerIntervalMinMaxIncrementRollableEquipmentAffix.Builder()
                .SetRerolledAffix(new PlusMinMaxGlobalPhysicalDamageWithAttacksAffix(0, 0))
                .SetLowerBoundMinValue(5)
                .SetLowerBoundMaxValue(10)
                .SetLowerBoundIncrement(1)
                .SetUpperBoundMinValue(15)
                .SetUpperBoundMaxValue(20)
                .SetUpperBoundIncrement(2)
                .Build();

            // Act & Assert
            Assert.That(affix1.Equals(null), Is.False);
        } 

        [Test]
        public void TestEqualsDifferentAffixType_ReturnsFalse()
        {
            // Arrange
            var affix1 = new IntegerIntervalMinMaxIncrementRollableEquipmentAffix.Builder()
                .SetRerolledAffix(new PlusMinMaxGlobalPhysicalDamageWithAttacksAffix(0, 0))
                .SetLowerBoundMinValue(5)
                .SetLowerBoundMaxValue(10)
                .SetLowerBoundIncrement(1)
                .SetUpperBoundMinValue(15)
                .SetUpperBoundMaxValue(20)
                .SetUpperBoundIncrement(2)
                .Build();

            // Create a different type of RollableEquipmentAffix
            var differentAffix = new IntegerMinMaxIncrementRollableEquipmentAffix(new IncreasedGlobalArmourAffix(0));

            // Act & Assert
            Assert.That(affix1.Equals(differentAffix), Is.False);
        }       
    }
}