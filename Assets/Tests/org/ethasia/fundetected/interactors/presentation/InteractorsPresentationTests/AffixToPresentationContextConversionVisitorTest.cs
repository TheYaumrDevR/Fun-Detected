using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Equipment.Affixes;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors.Presentation.Tests
{

    public class AffixToPresentationContextConversionVisitorTest
    {
        [Test]
        public void TestConvertAffixesToPresentationContextsConvertsAllImplicitsAndExplicits()
        {
            Weapon testWeapon = CreateTestWeapon();

            AffixToPresentationContextConversionVisitor testCandidate = new AffixToPresentationContextConversionVisitor();
            testCandidate.ConvertAffixesToPresentationContexts(testWeapon.FirstImplicit, testWeapon.Prefixes, testWeapon.Suffixes);
        
            IAffixPresentationContext[] implicitsResult = testCandidate.Implicits;
            IAffixPresentationContext[] explicitsResult = testCandidate.Explicits;

            Assert.That(implicitsResult, Has.Length.EqualTo(1));
            Assert.That(implicitsResult[0].Name, Is.EqualTo("IncreasedAttackSpeedAffix"));
            Assert.That(explicitsResult, Has.Length.EqualTo(5));
            Assert.That(explicitsResult[0].Name, Is.EqualTo("IncreasedLocalPhysicalDamageAffix"));
            Assert.That(explicitsResult[1].Name, Is.EqualTo("IncreasedMaximumLifeAffix"));
            Assert.That(explicitsResult[2].Name, Is.EqualTo("PlusAccuracyAffix"));
            Assert.That(explicitsResult[3].Name, Is.EqualTo("PlusAgilityAffix"));
            Assert.That(explicitsResult[4].Name, Is.EqualTo("PlusStrengthAffix"));
        }

        private Weapon CreateTestWeapon()
        {
            Weapon.Builder weaponBuilder = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(7, 23));

            IntegerMinMaxIncrementRollableEquipmentAffix implicitAffix = new IntegerMinMaxIncrementRollableEquipmentAffix.Builder()
                .SetRerolledAffix(new IncreasedAttackSpeedAffix(5))
                .Build();

            weaponBuilder.SetFirstImplicit(implicitAffix)
                .AddAffix(new IncreasedLocalPhysicalDamageAffix(10))
                .AddAffix(new IncreasedMaximumLifeAffix(50))
                .AddAffix(new PlusAccuracyAffix(200))
                .AddAffix(new PlusAgilityAffix(13))
                .AddAffix(new PlusStrengthAffix(51));

            return weaponBuilder.Build();
        }
    }
}