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
    }
}