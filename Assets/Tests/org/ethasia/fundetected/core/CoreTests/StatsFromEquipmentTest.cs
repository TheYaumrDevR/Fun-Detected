using NUnit.Framework;

namespace Org.Ethasia.Fundetected.Core.Tests
{
    public class StatsFromEquipmentTest
    {
        [Test]
        public void TestIncreasePlusMinMaxPhysicalDamageWithAttacksBy_IncreasesBothMeleeAndRangedAttacks()
        {
            // Arrange
            StatsFromEquipment testCandidate = new StatsFromEquipment();
            
            // Verify initial state
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithRightHandMeleeAttacks.MinDamage, Is.EqualTo(0));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithRightHandMeleeAttacks.MaxDamage, Is.EqualTo(0));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithLeftHandMeleeAttacks.MinDamage, Is.EqualTo(0));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithLeftHandMeleeAttacks.MaxDamage, Is.EqualTo(0));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithRangedAttacks.MinDamage, Is.EqualTo(0));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithRangedAttacks.MaxDamage, Is.EqualTo(0));
            
            // Act
            testCandidate.IncreasePlusMinMaxPhysicalDamageWithAttacksBy(5, 12);
            
            // Assert
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithRightHandMeleeAttacks.MinDamage, Is.EqualTo(5));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithRightHandMeleeAttacks.MaxDamage, Is.EqualTo(12));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithLeftHandMeleeAttacks.MinDamage, Is.EqualTo(5));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithLeftHandMeleeAttacks.MaxDamage, Is.EqualTo(12));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithRangedAttacks.MinDamage, Is.EqualTo(5));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithRangedAttacks.MaxDamage, Is.EqualTo(12));
        }

        [Test]
        public void TestIncreasePlusMinMaxPhysicalDamageWithAttacksBy_AccumulatesValues()
        {
            // Arrange
            StatsFromEquipment testCandidate = new StatsFromEquipment();
            
            // Act
            testCandidate.IncreasePlusMinMaxPhysicalDamageWithAttacksBy(3, 7);
            testCandidate.IncreasePlusMinMaxPhysicalDamageWithAttacksBy(3, 6);
            
            // Assert
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithRightHandMeleeAttacks.MinDamage, Is.EqualTo(6));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithRightHandMeleeAttacks.MaxDamage, Is.EqualTo(13));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithLeftHandMeleeAttacks.MinDamage, Is.EqualTo(6));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithLeftHandMeleeAttacks.MaxDamage, Is.EqualTo(13));            
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithRangedAttacks.MinDamage, Is.EqualTo(6));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithRangedAttacks.MaxDamage, Is.EqualTo(13));
        }        
    }
}