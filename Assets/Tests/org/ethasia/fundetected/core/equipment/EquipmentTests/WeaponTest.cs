using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Equipment.Affixes;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Equipment.Tests
{
    public class WeaponTest
    {
        [Test]
        public void TestCloneInstancesAreDifferent()
        {
            Weapon testCandidate = CreateTestWeapon();
            Weapon clone = testCandidate.Clone() as Weapon;

            Assert.AreNotSame(testCandidate, clone);
            Assert.AreNotSame(testCandidate.MinToMaxPhysicalDamage, clone.MinToMaxPhysicalDamage);
            Assert.AreNotSame(testCandidate.MinToMaxSpellDamage, clone.MinToMaxSpellDamage);
            Assert.AreNotSame(testCandidate.LocalModifiers, clone.LocalModifiers);
            Assert.AreNotSame(testCandidate.FirstImplicit, clone.FirstImplicit);
            Assert.AreNotSame(testCandidate.CollisionShape, clone.CollisionShape);

            for (int i = 0; i < testCandidate.Prefixes.Count; i++)
            {
                Assert.AreNotSame(testCandidate.Prefixes[i], clone.Prefixes[i]);
            }

            for (int i = 0; i < testCandidate.Suffixes.Count; i++)
            {
                Assert.AreNotSame(testCandidate.Suffixes[i], clone.Suffixes[i]);
            }
        }

        [Test]
        public void TestCloneInstancesHaveSameValues()
        {
            Weapon testCandidate = CreateTestWeapon();
            Weapon clone = testCandidate.Clone() as Weapon;

            Assert.That(clone.MinToMaxPhysicalDamage.MinDamage, Is.EqualTo(testCandidate.MinToMaxPhysicalDamage.MinDamage));
            Assert.That(clone.MinToMaxPhysicalDamage.MaxDamage, Is.EqualTo(testCandidate.MinToMaxPhysicalDamage.MaxDamage));
            Assert.That(clone.MinToMaxSpellDamage.MinDamage, Is.EqualTo(testCandidate.MinToMaxSpellDamage.MinDamage));
            Assert.That(clone.MinToMaxSpellDamage.MaxDamage, Is.EqualTo(testCandidate.MinToMaxSpellDamage.MaxDamage));
            Assert.That(clone.SkillsPerSecond, Is.EqualTo(testCandidate.SkillsPerSecond));
            Assert.That(clone.CriticalStrikeChance, Is.EqualTo(testCandidate.CriticalStrikeChance));
            Assert.That(clone.WeaponRange, Is.EqualTo(testCandidate.WeaponRange));
            Assert.That(clone.LocalModifiers.PlusMinToMaxPhysicalDamage.MinDamage, Is.EqualTo(testCandidate.LocalModifiers.PlusMinToMaxPhysicalDamage.MinDamage));
            Assert.That(clone.LocalModifiers.PlusMinToMaxPhysicalDamage.MaxDamage, Is.EqualTo(testCandidate.LocalModifiers.PlusMinToMaxPhysicalDamage.MaxDamage));
            Assert.That(clone.LocalModifiers.PlusMinToMaxFireDamage.MinDamage, Is.EqualTo(testCandidate.LocalModifiers.PlusMinToMaxFireDamage.MinDamage));
            Assert.That(clone.LocalModifiers.PlusMinToMaxFireDamage.MaxDamage, Is.EqualTo(testCandidate.LocalModifiers.PlusMinToMaxFireDamage.MaxDamage));
            Assert.That(clone.LocalModifiers.PlusMinToMaxColdDamage.MinDamage, Is.EqualTo(testCandidate.LocalModifiers.PlusMinToMaxColdDamage.MinDamage));
            Assert.That(clone.LocalModifiers.PlusMinToMaxColdDamage.MaxDamage, Is.EqualTo(testCandidate.LocalModifiers.PlusMinToMaxColdDamage.MaxDamage));
            Assert.That(clone.LocalModifiers.PlusMinToMaxLightningDamage.MinDamage, Is.EqualTo(testCandidate.LocalModifiers.PlusMinToMaxLightningDamage.MinDamage));
            Assert.That(clone.LocalModifiers.PlusMinToMaxLightningDamage.MaxDamage, Is.EqualTo(testCandidate.LocalModifiers.PlusMinToMaxLightningDamage.MaxDamage));
            Assert.That(clone.LocalModifiers.IncreasedPhysicalDamageInPercent, Is.EqualTo(testCandidate.LocalModifiers.IncreasedPhysicalDamageInPercent));
            Assert.That(clone.LocalModifiers.IncreasedAttackSpeedInPercent, Is.EqualTo(testCandidate.LocalModifiers.IncreasedAttackSpeedInPercent));
            Assert.That(clone.StrengthRequirement, Is.EqualTo(testCandidate.StrengthRequirement));
            Assert.That(clone.AgilityRequirement, Is.EqualTo(testCandidate.AgilityRequirement));
            Assert.That(clone.IntelligenceRequirement, Is.EqualTo(testCandidate.IntelligenceRequirement));

            Assert.That(clone.Name, Is.EqualTo(testCandidate.Name));
            Assert.That(clone.ItemClass, Is.EqualTo(testCandidate.ItemClass));
            Assert.That(clone.MinimumItemLevel, Is.EqualTo(testCandidate.MinimumItemLevel));
            Assert.That(clone.ItemLevel, Is.EqualTo(testCandidate.ItemLevel));
            Assert.That(clone.CollisionShape.CollisionShapeDistanceToLeftEdgeFromCenter, Is.EqualTo(testCandidate.CollisionShape.CollisionShapeDistanceToLeftEdgeFromCenter));
            Assert.That(clone.CollisionShape.CollisionShapeDistanceToRightEdgeFromCenter, Is.EqualTo(testCandidate.CollisionShape.CollisionShapeDistanceToRightEdgeFromCenter));
            Assert.That(clone.CollisionShape.CollisionShapeDistanceToTopEdgeFromCenter, Is.EqualTo(testCandidate.CollisionShape.CollisionShapeDistanceToTopEdgeFromCenter));
            Assert.That(clone.CollisionShape.CollisionShapeDistanceToBottomEdgeFromCenter, Is.EqualTo(testCandidate.CollisionShape.CollisionShapeDistanceToBottomEdgeFromCenter));
        }

        private Weapon CreateTestWeapon()
        {
            DamageRange minToMaxPhysicalDamage = new DamageRange(52, 98);
            DamageRange minToMaxSpellDamage = new DamageRange(11, 23);

            Weapon.Builder builder = new Weapon.Builder();
            builder.SetMinToMaxPhysicalDamage(minToMaxPhysicalDamage)
                .SetMinToMaxSpellDamage(minToMaxSpellDamage)
                .SetSkillsPerSecond(1.24)
                .SetCriticalStrikeChance(5)
                .SetWeaponRange(1);

            IntegerMinMaxIncrementRollableEquipmentAffix firstImplicit = new IntegerMinMaxIncrementRollableEquipmentAffix(new IncreasedLocalPhysicalDamageAffix(12));
            IncreasedAttackSpeedAffix suffixOne = new IncreasedAttackSpeedAffix(7);
            PhysicalDamagePercentStolenAsLifeAffix prefixOne = new PhysicalDamagePercentStolenAsLifeAffix(0.2f);
            PlusAccuracyAffix suffixTwo = new PlusAccuracyAffix(120);

            builder.SetStrengthRequirement(15)
                .SetAgilityRequirement(10)
                .SetIntelligenceRequirement(0)
                .AddAffix(prefixOne)
                .AddAffix(suffixOne)
                .AddAffix(suffixTwo)
                .SetFirstImplicit(firstImplicit);

            builder.SetName("Test Weapon")
                .SetItemClass(ItemClass.TWO_HANDED_AXE)
                .SetMinimumItemLevel(23)
                .SetItemLevel(27)
                .SetCollisionShapeDistanceToLeftEdgeFromCenter(3)
                .SetCollisionShapeDistanceToRightEdgeFromCenter(3)
                .SetCollisionShapeDistanceToTopEdgeFromCenter(5)
                .SetCollisionShapeDistanceToBottomEdgeFromCenter(5);

            return builder.Build();
        }
    }
}