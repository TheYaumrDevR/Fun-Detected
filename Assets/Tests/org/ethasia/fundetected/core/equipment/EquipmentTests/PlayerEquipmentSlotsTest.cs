using NUnit.Framework;

namespace Org.Ethasia.Fundetected.Core.Equipment.Tests
{
    public class PlayerEquipmentSlotsTest
    {

        [Test]
        public void TestCanEquipInMainHandCanEquipTwoHandedWeaponWhenOffhandFree()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetItemClass(ItemClass.WIZARD_STAFF);

            Weapon twoHandedWeapon = weaponBuilder.Build();

            bool result = testCandidate.CanEquipInMainHand(twoHandedWeapon);

            Assert.That(result, Is.True);  
        }

        [Test]
        public void TestCanEquipInMainHandCanNotEquipTwoHandedWeaponWhenOffhandUsed()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetItemClass(ItemClass.BOW);

            Weapon twoHandedWeapon = weaponBuilder.Build();

            Weapon.Builder offHandWeaponBuilder = new Weapon.Builder();
            offHandWeaponBuilder.SetItemClass(ItemClass.FIST_WEAPON);

            Weapon offHandWeapon = offHandWeaponBuilder.Build();

            testCandidate.EquipInOffHand(offHandWeapon);
            bool result = testCandidate.CanEquipInMainHand(twoHandedWeapon);

            Assert.That(result, Is.False);  
        }  

        [Test]
        public void TestCanEquipInMainHandCanEquipOneHandedWeaponWhenOffhandFree()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetItemClass(ItemClass.ONE_HANDED_SWORD);

            Weapon oneHandedWeapon = weaponBuilder.Build();

            bool result = testCandidate.CanEquipInMainHand(oneHandedWeapon);

            Assert.That(result, Is.True);  
        }   

        [Test]
        public void TestCanEquipInMainHandCanEquipOneHandedWeaponWhenOffhandSame()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetItemClass(ItemClass.DAGGER);

            Weapon oneHandedWeapon = weaponBuilder.Build();

            Weapon.Builder offHandWeaponBuilder = new Weapon.Builder();
            offHandWeaponBuilder.SetItemClass(ItemClass.DAGGER);

            Weapon offHandWeapon = offHandWeaponBuilder.Build();

            testCandidate.EquipInOffHand(offHandWeapon);
            bool result = testCandidate.CanEquipInMainHand(oneHandedWeapon);

            Assert.That(result, Is.True);  
        }             

        [Test]
        public void TestCanEquipInMainHandCanNotEquipOneHandedWeaponWhenOffhandDifferent()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetItemClass(ItemClass.ONE_HANDED_AXE);

            Weapon oneHandedWeapon = weaponBuilder.Build();

            Weapon.Builder offHandWeaponBuilder = new Weapon.Builder();
            offHandWeaponBuilder.SetItemClass(ItemClass.WAND);

            Weapon offHandWeapon = offHandWeaponBuilder.Build();

            testCandidate.EquipInOffHand(offHandWeapon);
            bool result = testCandidate.CanEquipInMainHand(oneHandedWeapon);

            Assert.That(result, Is.False);  
        }   

        [Test]
        public void TestCanEquipInOffHandCanNotEquipTwoHandedWeapon()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetItemClass(ItemClass.TWO_HANDED_MACE);

            Weapon twoHandedWeapon = weaponBuilder.Build();

            bool result = testCandidate.CanEquipInOffHand(twoHandedWeapon);

            Assert.That(result, Is.False);  
        }     

        [Test]
        public void TestCanEquipInOffHandCanEquipOneHandedWeapon()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetItemClass(ItemClass.SPELL_DAGGER);

            Weapon oneHandedWeapon = weaponBuilder.Build();

            bool result = testCandidate.CanEquipInOffHand(oneHandedWeapon);

            Assert.That(result, Is.True);  
        }  

        [Test]
        public void TestCanEquipInOffHandCanEquipOneHandedWeaponWhenSameTypeIsInMainHand()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD);

            Weapon oneHandedWeapon = weaponBuilder.Build();

            Weapon.Builder mainHandWeaponBuilder = new Weapon.Builder();
            mainHandWeaponBuilder.SetItemClass(ItemClass.ONE_HANDED_STABBING_SWORD);

            Weapon mainHandWeapon = mainHandWeaponBuilder.Build();

            testCandidate.EquipInMainHand(mainHandWeapon);
            bool result = testCandidate.CanEquipInOffHand(oneHandedWeapon);

            Assert.That(result, Is.True);  
        }     

        [Test]
        public void TestCanEquipInOffHandCanNotEquipOneHandedWeaponWhenDifferentTypeIsInMainHand()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetItemClass(ItemClass.ONE_HANDED_AXE);

            Weapon oneHandedWeapon = weaponBuilder.Build();

            Weapon.Builder mainHandWeaponBuilder = new Weapon.Builder();
            mainHandWeaponBuilder.SetItemClass(ItemClass.ONE_HANDED_MACE);

            Weapon mainHandWeapon = mainHandWeaponBuilder.Build();

            testCandidate.EquipInMainHand(mainHandWeapon);
            bool result = testCandidate.CanEquipInOffHand(oneHandedWeapon);

            Assert.That(result, Is.False);  
        }         

        [Test]
        public void TestEquipInMainHandReturnsNullIfNothingIsEquipped()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetItemClass(ItemClass.MARTIAL_STAFF);

            Weapon twoHandedWeapon = weaponBuilder.Build();

            Equipment result = testCandidate.EquipInMainHand(twoHandedWeapon);

            Assert.That(result, Is.Null); 
        }    

        [Test]
        public void TestEquipInMainHandReturnsOldEquippedItem()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetName("Bronze Twohander")
                .SetItemClass(ItemClass.TWO_HANDED_SWORD);

            Weapon firstWeapon = weaponBuilder.Build();

            testCandidate.EquipInMainHand(firstWeapon);

            weaponBuilder.SetName("Bronze Warhammer")
                .SetItemClass(ItemClass.TWO_HANDED_MACE);

            Weapon secondWeapon = weaponBuilder.Build();

            Equipment result = testCandidate.EquipInMainHand(firstWeapon);

            Assert.That(result.Name, Is.EqualTo("Bronze Twohander")); 
        }  

        [Test]
        public void TestEquipInMainHandReturnsCurrentItemIfItCannotEquip()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetName("Warstaff")
                .SetItemClass(ItemClass.MARTIAL_STAFF);

            Weapon twoHandedWeapon = weaponBuilder.Build();

            Weapon.Builder offHandWeaponBuilder = new Weapon.Builder();
            offHandWeaponBuilder.SetItemClass(ItemClass.FIST_WEAPON);

            Weapon offHandWeapon = offHandWeaponBuilder.Build();

            testCandidate.EquipInOffHand(offHandWeapon);
            Equipment result = testCandidate.EquipInMainHand(twoHandedWeapon);

            Assert.That(result.Name, Is.EqualTo("Warstaff")); 
        }         

        [Test]
        public void TestEquipInOffHandReturnsNullIfNothingIsEquipped()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetItemClass(ItemClass.ONE_HANDED_MACE);

            Weapon weapon = weaponBuilder.Build();

            Equipment result = testCandidate.EquipInOffHand(weapon);

            Assert.That(result, Is.Null); 
        }    

        [Test]
        public void TestEquipInOffHandReturnsOldEquippedItem()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetName("Spellblade")
                .SetItemClass(ItemClass.SPELL_DAGGER);

            Weapon firstWeapon = weaponBuilder.Build();

            testCandidate.EquipInOffHand(firstWeapon);

            weaponBuilder.SetName("Hatchet")
                .SetItemClass(ItemClass.ONE_HANDED_AXE);

            Weapon secondWeapon = weaponBuilder.Build();

            Equipment result = testCandidate.EquipInOffHand(firstWeapon);

            Assert.That(result.Name, Is.EqualTo("Spellblade")); 
        }  

        [Test]
        public void TestEquipInOffHandReturnsCurrentItemIfItCannotEquip()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            Weapon.Builder weaponBuilder = new Weapon.Builder();

            weaponBuilder.SetName("Gladius")
                .SetItemClass(ItemClass.ONE_HANDED_SWORD);

            Weapon secondWeapon = weaponBuilder.Build();

            Weapon.Builder offHandWeaponBuilder = new Weapon.Builder();
            offHandWeaponBuilder.SetItemClass(ItemClass.FIST_WEAPON);

            Weapon firstWeapon = offHandWeaponBuilder.Build();

            testCandidate.EquipInMainHand(firstWeapon);
            Equipment result = testCandidate.EquipInOffHand(secondWeapon);

            Assert.That(result.Name, Is.EqualTo("Gladius")); 
        }                                            
    }
}