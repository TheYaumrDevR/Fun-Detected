using NUnit.Framework;

using Org.Ethasia.Fundetected.Ioadapters.Mocks;

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

        [Test]
        public void TestEqualsSameProperties_ReturnsTrue()
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

            var affix2 = new IntegerIntervalMinMaxIncrementRollableEquipmentAffix.Builder()
                .SetRerolledAffix(new PlusMinMaxGlobalPhysicalDamageWithAttacksAffix(0, 0))
                .SetLowerBoundMinValue(5)
                .SetLowerBoundMaxValue(10)
                .SetLowerBoundIncrement(1)
                .SetUpperBoundMinValue(15)
                .SetUpperBoundMaxValue(20)
                .SetUpperBoundIncrement(2)
                .Build();

            // Act & Assert
            Assert.That(affix1.Equals(affix2), Is.True);
        } 

        [Test]  
        public void TestEqualsDifferentNumbers_ReturnsFalse()
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

            var affix2 = new IntegerIntervalMinMaxIncrementRollableEquipmentAffix.Builder()
                .SetRerolledAffix(new PlusMinMaxGlobalPhysicalDamageWithAttacksAffix(0, 0))
                .SetLowerBoundMinValue(5) 
                .SetLowerBoundMaxValue(10)
                .SetLowerBoundIncrement(1)
                .SetUpperBoundMinValue(14) // Different value
                .SetUpperBoundMaxValue(20)
                .SetUpperBoundIncrement(2)
                .Build();

            // Act & Assert
            Assert.That(affix1.Equals(affix2), Is.False);
        }

        [Test]
        public void TestEqualsDifferentRerolledAffix_ReturnsFalse()
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

            var affix2 = new IntegerIntervalMinMaxIncrementRollableEquipmentAffix.Builder()
                .SetRerolledAffix(new IncreasedGlobalArmourAffix(0)) // Different rerolled affix
                .SetLowerBoundMinValue(5)
                .SetLowerBoundMaxValue(10)
                .SetLowerBoundIncrement(1)
                .SetUpperBoundMinValue(15)
                .SetUpperBoundMaxValue(20)
                .SetUpperBoundIncrement(2)
                .Build();

            // Act & Assert
            Assert.That(affix1.Equals(affix2), Is.False);
        }

        [Test]
        public void TestClone_CreatesExactCopy()
        {
            // Arrange
            var originalAffix = new IntegerIntervalMinMaxIncrementRollableEquipmentAffix.Builder()
                .SetRerolledAffix(new PlusMinMaxGlobalPhysicalDamageWithAttacksAffix(3, 8))
                .SetLowerBoundMinValue(5)
                .SetLowerBoundMaxValue(17)
                .SetLowerBoundIncrement(1)
                .SetUpperBoundMinValue(15)
                .SetUpperBoundMaxValue(40)
                .SetUpperBoundIncrement(1)
                .Build();

            // Act
            var clonedAffix = originalAffix.Clone();

            // Assert
            Assert.That(clonedAffix.Equals(originalAffix), Is.True);
        }

        [Test]
        public void TestRerollValue_TakesOnlyValueIfUpperAndLowerIntervalLimitAreSame()
        {
            // Arrange
            CreateMockIoAdaptersFactoryWithRngMock();

            var affix = new IntegerIntervalMinMaxIncrementRollableEquipmentAffix.Builder()
                .SetRerolledAffix(new PlusMinMaxGlobalPhysicalDamageWithAttacksAffix(0, 0))
                .SetLowerBoundMinValue(5)
                .SetLowerBoundMaxValue(5)
                .SetLowerBoundIncrement(1)
                .SetUpperBoundMinValue(5)
                .SetUpperBoundMaxValue(5)
                .SetUpperBoundIncrement(1)
                .Build();

            // Act
            var rerolledValue = affix.RerollValue();

            // Assert
            Assert.That(rerolledValue.MinDamage, Is.EqualTo(5));
            Assert.That(rerolledValue.MaxDamage, Is.EqualTo(5));
        }

        [Test]
        public void TestRerollValue_TakesRandomValuesWithinIntervals()
        {
            // Arrange
            CreateMockIoAdaptersFactoryWithRngMock();

            var affix = new IntegerIntervalMinMaxIncrementRollableEquipmentAffix.Builder()
                .SetRerolledAffix(new PlusMinMaxGlobalPhysicalDamageWithAttacksAffix(0, 0))
                .SetLowerBoundMinValue(5)
                .SetLowerBoundMaxValue(17)
                .SetLowerBoundIncrement(1)
                .SetUpperBoundMinValue(15)
                .SetUpperBoundMaxValue(40)
                .SetUpperBoundIncrement(1)
                .Build();

            // Act
            var rerolledValue = affix.RerollValue();

            // Assert
            // With the mocked RNG, the first random int is 8, the second is 27
            Assert.That(rerolledValue.MinDamage, Is.EqualTo(8));
            Assert.That(rerolledValue.MaxDamage, Is.EqualTo(27));
        }

        private static void CreateMockIoAdaptersFactoryWithRngMock()
        {
            RandomNumberGeneratorMock rngMock = new RandomNumberGeneratorMock(new int[] { 8, 27 }, new float[] { }, new double[] { });
            MockedIoAdaptersFactoryForCore ioAdaptersFactoryForCore = new MockedIoAdaptersFactoryForCore();
            ioAdaptersFactoryForCore.SetRngInstance(rngMock);
            IoAdaptersFactoryForCore.SetInstance(ioAdaptersFactoryForCore);            
        }
    }
}