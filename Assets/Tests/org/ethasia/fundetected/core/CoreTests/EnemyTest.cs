using NUnit.Framework;

namespace Org.Ethasia.Fundetected.Core.Tests
{
    public class EnemyTest
    {
        [Test]
        public void TestTakePhysicalHitTakesDamage()
        {
            Enemy testCandidate = new Enemy
                .Builder()
                .SetLife(100)
                .Build();

            testCandidate.TakePhysicalHit(50);

            Assert.That(testCandidate.CurrentLife, Is.EqualTo(50));
        }

        [Test]
        public void TestTakePhysicalArmorMitigatesDamage()
        {
            Enemy testCandidate = new Enemy
                .Builder()
                .SetLife(100)
                .SetArmor(20)
                .Build();

            testCandidate.TakePhysicalHit(50);

            Assert.That(testCandidate.CurrentLife, Is.EqualTo(54));
        }    

        [Test]
        public void TestTakeNonPhysicalHitFireResistanceMitigatesDamage()
        {
            Enemy testCandidate = new Enemy
                .Builder()
                .SetLife(100)
                .SetFireResistance(0.2f)
                .Build();

            testCandidate.TakeNonPhysicalHit(100, ResistanceDamageTypes.FIRE);

            Assert.That(testCandidate.CurrentLife, Is.EqualTo(20));
        }     

        [Test]
        public void TestTakeNonPhysicalHitIceResistanceMitigatesDamage()
        {
            Enemy testCandidate = new Enemy
                .Builder()
                .SetLife(100)
                .SetIceResistance(0.5f)
                .Build();

            testCandidate.TakeNonPhysicalHit(100, ResistanceDamageTypes.ICE);

            Assert.That(testCandidate.CurrentLife, Is.EqualTo(50));
        }

        [Test]
        public void TestTakeNonPhysicalHitLightningResistanceMitigatesDamage()
        {
            Enemy testCandidate = new Enemy
                .Builder()
                .SetLife(100)
                .SetLightningResistance(0.75f)
                .Build();

            testCandidate.TakeNonPhysicalHit(100, ResistanceDamageTypes.LIGHTNING);

            Assert.That(testCandidate.CurrentLife, Is.EqualTo(75));
        }  

        [Test]
        public void TestTakeNonPhysicalHitMagicResistanceMitigatesDamage()
        {
            Enemy testCandidate = new Enemy
                .Builder()
                .SetLife(100)
                .SetMagicResistance(0.8f)
                .Build();

            testCandidate.TakeNonPhysicalHit(100, ResistanceDamageTypes.MAGIC);

            Assert.That(testCandidate.CurrentLife, Is.EqualTo(80));
        }                                  
    }
}