using NUnit.Framework;

namespace Org.Ethasia.Fundetected.Core.Maths.Tests
{
    public class FormulasTest
    {

        [Test]
        public void TestCalculatePhysicalDamageAfterReduction()
        {
            int rawDamage = 50;
            int armour = 20;

            int mitigatedDamage = Formulas.CalculatePhysicalDamageAfterReduction(rawDamage, armour);

            Assert.That(mitigatedDamage, Is.EqualTo(46));  
        }
    }
}