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
            PlayerEquipmentSlots equipmentSlots = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            PlusAgilityAffix plusAgilityAffix = new PlusAgilityAffix(53);

            weaponBuilder.AddAffix(plusAgilityAffix);
            weaponBuilder.SetItemClass(ItemClass.FIST_WEAPON);

            Weapon claw = weaponBuilder.Build();

            equipmentSlots.EquipInMainHand(claw);  

            Assert.That(equipmentSlots.EquipmentStats.PlusAgility, Is.EqualTo(53));

            Weapon.Builder newWeaponBuilder = new Weapon.Builder();

            plusAgilityAffix = new PlusAgilityAffix(12);

            newWeaponBuilder.AddAffix(plusAgilityAffix);
            newWeaponBuilder.SetItemClass(ItemClass.ONE_HANDED_SWORD);

            Weapon sword = newWeaponBuilder.Build();        

            equipmentSlots.EquipInMainHand(sword);     

            Assert.That(equipmentSlots.EquipmentStats.PlusAgility, Is.EqualTo(12)); 
        }

        [Test]
        public void TestThatOnlyThreePrefixesAndSuffixesCanBeSet()
        {
            PlayerEquipmentSlots equipmentSlots = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            PlusMaximumManaAffix plusMaximumManaAffix = new PlusMaximumManaAffix(34);
            PlusMaximumLifeAffix plusMaximumLifeAffix = new PlusMaximumLifeAffix(99);
            IncreasedMaximumLifeAffix increasedMaximumLifeAffix = new IncreasedMaximumLifeAffix(33);
            PhysicalDamagePercentStolenAsLifeAffix lifeLeechAffix = new PhysicalDamagePercentStolenAsLifeAffix(24);

            PlusFireResistanceAffix plusFireResistanceAffix = new PlusFireResistanceAffix(45);
            PlusColdResistanceAffix plusColdResistanceAffix = new PlusColdResistanceAffix(45);
            PlusLightningResistanceAffix plusLightningResistanceAffix = new PlusLightningResistanceAffix(45);
            PlusMagicResistanceAffix plusMagicResistanceAffix = new PlusMagicResistanceAffix(45);

            weaponBuilder.AddAffix(plusMaximumManaAffix);
            weaponBuilder.AddAffix(plusMaximumLifeAffix);
            weaponBuilder.AddAffix(increasedMaximumLifeAffix);
            weaponBuilder.AddAffix(lifeLeechAffix);
            weaponBuilder.AddAffix(plusFireResistanceAffix);
            weaponBuilder.AddAffix(plusColdResistanceAffix);
            weaponBuilder.AddAffix(plusLightningResistanceAffix);
            weaponBuilder.AddAffix(plusMagicResistanceAffix);

            weaponBuilder.SetItemClass(ItemClass.TWO_HANDED_SWORD);
            Weapon twoHandedWeapon = weaponBuilder.Build();  

            equipmentSlots.EquipInMainHand(twoHandedWeapon); 

            Assert.That(equipmentSlots.EquipmentStats.PlusMaximumMana, Is.EqualTo(34));
            Assert.That(equipmentSlots.EquipmentStats.PlusMaximumLife, Is.EqualTo(99));
            Assert.That(equipmentSlots.EquipmentStats.IncreasedMaximumLifeInPercent, Is.EqualTo(33));
            Assert.That(equipmentSlots.EquipmentStats.PhysicalDamagePercentStolenAsLife, Is.EqualTo(0));

            Assert.That(equipmentSlots.EquipmentStats.PlusFireResistance, Is.EqualTo(45));
            Assert.That(equipmentSlots.EquipmentStats.PlusColdResistance, Is.EqualTo(45));
            Assert.That(equipmentSlots.EquipmentStats.PlusLightningResistance, Is.EqualTo(45));
            Assert.That(equipmentSlots.EquipmentStats.PlusMagicResistance, Is.EqualTo(0));                        
        }

        [Test]
        public void TestThatFirstImplicitIsAppliedToGlobalEquipmentStats()
        {
            PlayerEquipmentSlots equipmentSlots = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            PlusMaximumColdResistanceAffix plusMaximumColdResistanceAffix = new PlusMaximumColdResistanceAffix(2);

            weaponBuilder.SetFirstImplicit(plusMaximumColdResistanceAffix);
            weaponBuilder.SetItemClass(ItemClass.WAND);

            Weapon wand = weaponBuilder.Build();  

            equipmentSlots.EquipInMainHand(wand); 

            Assert.That(equipmentSlots.EquipmentStats.PlusMaximumColdResistance, Is.EqualTo(2));
        }

        [Test]
        public void TestThatFirstImplicitIsRemovedFromGlobalEquipmentStatsWhenUnequipped()
        {
            PlayerEquipmentSlots equipmentSlots = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            PlusMaximumFireResistanceAffix plusMaximumFireResistanceAffix = new PlusMaximumFireResistanceAffix(5);

            weaponBuilder.SetFirstImplicit(plusMaximumFireResistanceAffix);
            weaponBuilder.SetItemClass(ItemClass.WIZARD_STAFF);

            Weapon staff = weaponBuilder.Build();  

            equipmentSlots.EquipInMainHand(staff); 

            Assert.That(equipmentSlots.EquipmentStats.PlusMaximumFireResistance, Is.EqualTo(5));

            Weapon.Builder replacementWeaponBuilder = new Weapon.Builder();
            weaponBuilder.SetItemClass(ItemClass.MARTIAL_STAFF);

            Weapon replacementStaff = weaponBuilder.Build();  
            equipmentSlots.EquipInMainHand(replacementStaff); 

            Assert.That(equipmentSlots.EquipmentStats.PlusMaximumColdResistance, Is.EqualTo(0));
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

        [Test]
        public void TestThatLocalArmorAffixesAreNotAddedToGlobalEquipmentStats()
        {

        }
    }
}