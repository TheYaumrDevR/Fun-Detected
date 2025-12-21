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

        [Test]   
        public void TestIncreasePlusMinMaxPhysicalDamageWithMeleeAttacksBy_IncreasesOnlyMeleeAttacks()
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
            testCandidate.IncreasePlusMinMaxPhysicalDamageWithMeleeAttacksBy(4, 10);
            
            // Assert
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithRightHandMeleeAttacks.MinDamage, Is.EqualTo(4));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithRightHandMeleeAttacks.MaxDamage, Is.EqualTo(10));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithLeftHandMeleeAttacks.MinDamage, Is.EqualTo(4));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithLeftHandMeleeAttacks.MaxDamage, Is.EqualTo(10));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithRangedAttacks.MinDamage, Is.EqualTo(0));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithRangedAttacks.MaxDamage, Is.EqualTo(0));
        }

        [Test]
        public void TestDecreasePlusMinMaxPhysicalDamageWithAttacksBy_DecreasesBothMeleeAndRangedAttacks()
        {
            // Arrange
            StatsFromEquipment testCandidate = new StatsFromEquipment();
            testCandidate.IncreasePlusMinMaxPhysicalDamageWithAttacksBy(10, 20);
            
            // Act
            testCandidate.DecreasePlusMinMaxPhysicalDamageWithAttacksBy(4, 8);
            
            // Assert
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithRightHandMeleeAttacks.MinDamage, Is.EqualTo(6));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithRightHandMeleeAttacks.MaxDamage, Is.EqualTo(12));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithLeftHandMeleeAttacks.MinDamage, Is.EqualTo(6));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithLeftHandMeleeAttacks.MaxDamage, Is.EqualTo(12));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithRangedAttacks.MinDamage, Is.EqualTo(6));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithRangedAttacks.MaxDamage, Is.EqualTo(12));
        }

        [Test]
        public void TestDecreasePlusMinMaxPhysicalDamageWithMeleeAttacksBy_DecreasesOnlyMeleeAttacks()
        {
            // Arrange
            StatsFromEquipment testCandidate = new StatsFromEquipment();
            testCandidate.IncreasePlusMinMaxPhysicalDamageWithAttacksBy(10, 20);
            
            // Act
            testCandidate.DecreasePlusMinMaxPhysicalDamageWithMeleeAttacksBy(3, 7);
            
            // Assert
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithRightHandMeleeAttacks.MinDamage, Is.EqualTo(7));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithRightHandMeleeAttacks.MaxDamage, Is.EqualTo(13));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithLeftHandMeleeAttacks.MinDamage, Is.EqualTo(7));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithLeftHandMeleeAttacks.MaxDamage, Is.EqualTo(13));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithRangedAttacks.MinDamage, Is.EqualTo(10));
            Assert.That(testCandidate.PlusMinMaxPhysicalDamageWithRangedAttacks.MaxDamage, Is.EqualTo(20));
        }
    }
}