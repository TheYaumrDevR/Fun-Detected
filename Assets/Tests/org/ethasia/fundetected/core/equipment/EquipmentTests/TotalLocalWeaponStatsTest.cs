using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core.Equipment.Tests
{
    public class TotalLocalWeaponStatsTest
    {
        private Weapon weapon;

        [SetUp]
        public void SetUp()
        {
            weapon = new Weapon.Builder()
                .SetMinToMaxPhysicalDamage(new DamageRange(10, 20))
                .SetSkillsPerSecond(1.5)
                .Build();
        }

        [Test]
        public void CalculateFrom_ShouldAddPlusPhysicalDamageToBaseDamage()
        {
            weapon.LocalModifiers.IncreasePlusMinToMaxPhysicalDamageBy(3, 7);

            TotalLocalWeaponStats result = TotalLocalWeaponStats.CalculateFrom(weapon);

            Assert.That(result.PhysicalDamage.MinDamage, Is.EqualTo(13));
            Assert.That(result.PhysicalDamage.MaxDamage, Is.EqualTo(27));
        }

        [Test]
        public void CalculateFrom_ShouldIncreasePhysicalDamageByPercentage()
        {
            weapon.LocalModifiers.IncreaseIncreasedPhysicalDamageInPercentBy(50);

            TotalLocalWeaponStats result = TotalLocalWeaponStats.CalculateFrom(weapon);

            Assert.That(result.PhysicalDamage.MinDamage, Is.EqualTo(15));
            Assert.That(result.PhysicalDamage.MaxDamage, Is.EqualTo(30));
        }

        [Test]
        public void CalculateFrom_ShouldApplyPercentageToBaseDamagePlusFlatDamage()
        {
            weapon.LocalModifiers.IncreasePlusMinToMaxPhysicalDamageBy(5, 10);
            weapon.LocalModifiers.IncreaseIncreasedPhysicalDamageInPercentBy(50);

            TotalLocalWeaponStats result = TotalLocalWeaponStats.CalculateFrom(weapon);

            Assert.That(result.PhysicalDamage.MinDamage, Is.EqualTo(22));
            Assert.That(result.PhysicalDamage.MaxDamage, Is.EqualTo(45));
        }

        [Test]
        public void CalculateFrom_ShouldIncreaseSkillsPerSecondByAttackSpeedPercentage()
        {
            weapon.LocalModifiers.IncreaseIncreasedAttackSpeedInPercentBy(20);

            TotalLocalWeaponStats result = TotalLocalWeaponStats.CalculateFrom(weapon);

            Assert.That(result.SkillsPerSecond, Is.EqualTo(1.8).Within(0.0001));
        }
    }
}