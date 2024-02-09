using NUnit.Framework;

namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes.Tests
{
    public class AffixesTest
    {
        [Test]
        public void TestGlobalAffixesAreAppliedToEquipmentStats()
        {
            PlayerEquipmentSlots equipmentSlots = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            IncreasedMaximumLifeAffix increasedMaximumLifeAffix = new IncreasedMaximumLifeAffix(60);
            IncreasedStunAndBlockRecoveryAffix increasedStunAndBlockRecoveryAffix = new IncreasedStunAndBlockRecoveryAffix(12);
            PhysicalDamagePercentStolenAsLifeAffix physicalDamagePercentStolenAsLifeAffix = new PhysicalDamagePercentStolenAsLifeAffix(5);
            PlusAccuracyAffix plusAccuracyAffix = new PlusAccuracyAffix(120);
            PlusAccuracyAndIncreasedPhysicalDamageAffix plusAccuracyAndIncreasedPhysicalDamageAffix = new PlusAccuracyAndIncreasedPhysicalDamageAffix(123, 15);

            weaponBuilder.AddAffix(increasedMaximumLifeAffix);
            weaponBuilder.AddAffix(increasedStunAndBlockRecoveryAffix);
            weaponBuilder.AddAffix(physicalDamagePercentStolenAsLifeAffix);
            weaponBuilder.AddAffix(plusAccuracyAffix);
            weaponBuilder.AddAffix(plusAccuracyAndIncreasedPhysicalDamageAffix);

            weaponBuilder.SetItemClass(ItemClass.TWO_HANDED_AXE);

            Weapon twoHandedWeapon = weaponBuilder.Build();    

            equipmentSlots.EquipInMainHand(twoHandedWeapon);  

            Assert.That(equipmentSlots.EquipmentStats.IncreasedMaximumLifeInPercent, Is.EqualTo(60));
            Assert.That(equipmentSlots.EquipmentStats.IncreasedStunAndBlockRecoveryInPercent, Is.EqualTo(12));
            Assert.That(equipmentSlots.EquipmentStats.PhysicalDamagePercentStolenAsLife, Is.EqualTo(5));
            Assert.That(equipmentSlots.EquipmentStats.PlusAccuracy, Is.EqualTo(243));
        }

        [Test]
        public void TestThatGlobalEquipmentStatsAreUpdatedWhenEquipmentIsUnequipped()
        {

        }

        [Test]
        public void TestThatOnlyThreePrefixesAndSuffixesCanBeSet()
        {

        }

        [Test]
        public void TestThatFirstImplicitIsAppliedToGlobalEquipmentStats()
        {

        }

        [Test]
        public void TestThatFirstImplicitIsRemovedFromGlobalEquipmentStatsWhenUnequipped()
        {

        }

        [Test]
        public void TestThatLocalWeaponAffixesAreAddedToWeapon()
        {

        }

        [Test]
        public void TestThatLocalArmorAffixesAreAddedToArmor()
        {

        }

        [Test]
        public void TestThatLocalWeaponAffixesAreNotAddedToGlobalEquipmentStats()
        {

        }   

        public void TestThatLocalArmorAffixesAreNotAddedToGlobalEquipmentStats()
        {

        }
    }
}