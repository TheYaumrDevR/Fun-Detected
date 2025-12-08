using NUnit.Framework;

namespace Org.Ethasia.Fundetected.Core.Map.Tests
{
    public class PlayerCharacterTotalStatsTest
    {
        [Test]
        public void TestCalculateAddsIncreasesAndMultipliesIntelligenceProperly()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();
            StatsFromEquipment equipmentStats = new StatsFromEquipment();

            statModifiers.AddIntelligenceAddend(3);
            statModifiers.AddIntelligenceAddend(9);

            statModifiers.AddIntelligenceIncrease(0.2f);
            statModifiers.AddIntelligenceIncrease(0.4f);

            statModifiers.AddIntelligenceMultiplier(1.3f);
            statModifiers.AddIntelligenceMultiplier(1.5f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers, equipmentStats);

            Assert.That(testCandidate.Intelligence, Is.EqualTo(177)); 
        }

        [Test]
        public void TestCalculateAddsIncreasesAndMultipliesAgilityProperly()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();
            StatsFromEquipment equipmentStats = new StatsFromEquipment();

            statModifiers.AddAgilityAddend(2);
            statModifiers.AddAgilityAddend(5);

            statModifiers.AddAgilityIncrease(0.1f);
            statModifiers.AddAgilityIncrease(0.3f);

            statModifiers.AddAgilityMultiplier(1.2f);
            statModifiers.AddAgilityMultiplier(1.4f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers, equipmentStats);

            Assert.That(testCandidate.Agility, Is.EqualTo(96)); 
        }

        [Test]
        public void TestCalculateAddsIncreasesAndMultipliesStrengthProperly()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();
            StatsFromEquipment equipmentStats = new StatsFromEquipment();

            statModifiers.AddStrengthAddend(4);
            statModifiers.AddStrengthAddend(8);

            statModifiers.AddStrengthIncrease(0.3f);
            statModifiers.AddStrengthIncrease(0.5f);

            statModifiers.AddStrengthMultiplier(1.1f);
            statModifiers.AddStrengthMultiplier(1.6f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers, equipmentStats);

            Assert.That(testCandidate.Strength, Is.EqualTo(250)); 
        }

        [Test]
        public void TestCalculateAddsIncreasesAndMultipliesMaximumLifeProperly()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();
            StatsFromEquipment equipmentStats = new StatsFromEquipment();

            statModifiers.AddMaximumLifeAddend(50);
            statModifiers.AddMaximumLifeAddend(100);

            statModifiers.AddMaximumLifeIncrease(0.2f);
            statModifiers.AddMaximumLifeIncrease(0.4f);

            statModifiers.AddMaximumLifeMultiplier(1.3f);
            statModifiers.AddMaximumLifeMultiplier(1.5f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers, equipmentStats);

            Assert.That(testCandidate.MaximumLife, Is.EqualTo(2130)); 
        }

        [Test]
        public void TestCalculateAddsIncreasesAndMultipliesMaximumManaProperly()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();
            StatsFromEquipment equipmentStats = new StatsFromEquipment();

            statModifiers.AddMaximumManaAddend(20);
            statModifiers.AddMaximumManaAddend(30);

            statModifiers.AddMaximumManaIncrease(0.1f);
            statModifiers.AddMaximumManaIncrease(0.3f);

            statModifiers.AddMaximumManaMultiplier(1.2f);
            statModifiers.AddMaximumManaMultiplier(1.4f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers, equipmentStats);

            Assert.That(testCandidate.MaximumMana, Is.EqualTo(639)); 
        }

        [Test]
        public void TestCalculateAddsIncreasesAndMultipliesMeleePhysicalDamageProperly()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();
            StatsFromEquipment equipmentStats = new StatsFromEquipment();

            statModifiers.AddAddedPhysicalDamage(new DamageRange(5, 10));
            statModifiers.AddAddedPhysicalDamage(new DamageRange(7, 15));

            statModifiers.AddAddedPhysicalDamageIncrease(0.2f);
            statModifiers.AddAddedPhysicalDamageIncrease(0.4f);

            statModifiers.AddAddedPhysicalDamageMultiplier(1.3f);
            statModifiers.AddAddedPhysicalDamageMultiplier(1.5f);

            statModifiers.AddAddedPhysicalDamageWithMeleeAttacks(new DamageRange(18, 19));
            statModifiers.AddAddedPhysicalDamageWithMeleeAttacksIncrease(0.1f);
            statModifiers.AddAddedPhysicalDamageWithMeleeAttacksMultiplier(1.05f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers, equipmentStats);

            Assert.That(testCandidate.PhysicalDamageWithMeleeAttacks.MinDamage, Is.EqualTo(153));
            Assert.That(testCandidate.PhysicalDamageWithMeleeAttacks.MaxDamage, Is.EqualTo(251));
        }

        [Test]
        public void TestCalculateAddsIncreasesAndMultipliesRangedPhysicalDamageProperly()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();
            StatsFromEquipment equipmentStats = new StatsFromEquipment();

            statModifiers.AddAddedPhysicalDamage(new DamageRange(5, 10));
            statModifiers.AddAddedPhysicalDamage(new DamageRange(7, 15));

            statModifiers.AddAddedPhysicalDamageIncrease(0.2f);
            statModifiers.AddAddedPhysicalDamageIncrease(0.4f);

            statModifiers.AddAddedPhysicalDamageMultiplier(1.3f);
            statModifiers.AddAddedPhysicalDamageMultiplier(1.5f);

            statModifiers.AddAddedPhysicalDamageWithRangedAttacks(new DamageRange(6, 15));
            statModifiers.AddAddedPhysicalDamageWithRangedAttacksIncrease(0.05f);
            statModifiers.AddAddedPhysicalDamageWithRangedAttacksMultiplier(1.1f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers, equipmentStats);

            Assert.That(testCandidate.PhysicalDamageWithRangedAttacks.MinDamage, Is.EqualTo(63));
            Assert.That(testCandidate.PhysicalDamageWithRangedAttacks.MaxDamage, Is.EqualTo(141));
        }

        [Test]
        public void TestCalculateAddsIncreasesAndMultipliesSpellPhysicalDamageProperly()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();
            StatsFromEquipment equipmentStats = new StatsFromEquipment();

            statModifiers.AddAddedPhysicalDamage(new DamageRange(5, 10));
            statModifiers.AddAddedPhysicalDamage(new DamageRange(7, 15));

            statModifiers.AddAddedPhysicalDamageIncrease(0.2f);
            statModifiers.AddAddedPhysicalDamageIncrease(0.4f);

            statModifiers.AddAddedPhysicalDamageMultiplier(1.3f);
            statModifiers.AddAddedPhysicalDamageMultiplier(1.5f);

            statModifiers.AddAddedPhysicalDamageWithSpells(new DamageRange(18, 19));
            statModifiers.AddAddedPhysicalDamageWithSpellsIncrease(0.07f);
            statModifiers.AddAddedPhysicalDamageWithSpellsMultiplier(1.12f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers, equipmentStats);

            Assert.That(testCandidate.PhysicalDamageWithSpells.MinDamage, Is.EqualTo(109));
            Assert.That(testCandidate.PhysicalDamageWithSpells.MaxDamage, Is.EqualTo(160));
        }

        [Test]
        public void TestCalculateAddsIncreasesAndMultipliesAccuracyRatingProperly()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();
            StatsFromEquipment equipmentStats = new StatsFromEquipment();

            statModifiers.AddAccuracyRatingAddend(10);
            statModifiers.AddAccuracyRatingAddend(20);

            statModifiers.AddAccuracyRatingIncrease(0.1f);
            statModifiers.AddAccuracyRatingIncrease(0.3f);

            statModifiers.AddAccuracyRatingMultiplier(1.2f);
            statModifiers.AddAccuracyRatingMultiplier(1.4f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers, equipmentStats);

            Assert.That(testCandidate.AccuracyRating, Is.EqualTo(350)); 
        }

        [Test]
        public void TestCalculateAddsIncreasesAndMultipliesEvasionRatingProperly()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();
            StatsFromEquipment equipmentStats = new StatsFromEquipment();

            statModifiers.AddEvasionRatingAddend(15);
            statModifiers.AddEvasionRatingAddend(25);

            statModifiers.AddEvasionRatingIncrease(0.2f);
            statModifiers.AddEvasionRatingIncrease(0.4f);

            statModifiers.AddEvasionRatingMultiplier(1.3f);
            statModifiers.AddEvasionRatingMultiplier(1.5f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers, equipmentStats);

            Assert.That(testCandidate.EvasionRating, Is.EqualTo(673)); 
        }

        [Test]
        public void TestCalculateAddsIncreasesAndMultipliesAttacksPerSecondProperly()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();
            StatsFromEquipment equipmentStats = new StatsFromEquipment();

            statModifiers.AddAttacksPerSecondIncrease(0.1f);
            statModifiers.AddAttacksPerSecondIncrease(0.2f);

            statModifiers.AddAttacksPerSecondMultiplier(1.2f);
            statModifiers.AddAttacksPerSecondMultiplier(1.4f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers, equipmentStats);

            Assert.That(testCandidate.AttacksPerSecond, Is.EqualTo(3.0576001495361336)); 
        }

        [Test]
        public void TestCalculateAddsIncreasesAndMultipliesMovementSpeedProperly()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();
            StatsFromEquipment equipmentStats = new StatsFromEquipment();

            statModifiers.AddMovementSpeedAddend(10);
            statModifiers.AddMovementSpeedAddend(20);

            statModifiers.AddMovementSpeedIncrease(0.1f);
            statModifiers.AddMovementSpeedIncrease(0.3f);

            statModifiers.AddMovementSpeedMultiplier(1.2f);
            statModifiers.AddMovementSpeedMultiplier(1.4f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers, equipmentStats);

            Assert.That(testCandidate.MovementSpeed, Is.EqualTo(423)); 
        }

        [Test]
        public void TestCalculateCalculatesSameValuesWhenCalculateIsCalledTwice()
        {
            PlayerCharacterAdditionalStats statModifiers = CreateAdditionalStats();
            PlayerCharacterBaseStats baseStats = CreateBaseStats();
            StatsFromEquipment equipmentStats = new StatsFromEquipment();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers, equipmentStats);
            testCandidate.Calculate(baseStats, statModifiers, equipmentStats);

            Assert.That(testCandidate.Intelligence, Is.EqualTo(177));
            Assert.That(testCandidate.Agility, Is.EqualTo(96));
            Assert.That(testCandidate.Strength, Is.EqualTo(250));
            Assert.That(testCandidate.MaximumLife, Is.EqualTo(2417));
            Assert.That(testCandidate.MaximumMana, Is.EqualTo(794));
            Assert.That(testCandidate.PhysicalDamageWithMeleeAttacks.MinDamage, Is.EqualTo(184));
            Assert.That(testCandidate.PhysicalDamageWithMeleeAttacks.MaxDamage, Is.EqualTo(301));
            Assert.That(testCandidate.PhysicalDamageWithRangedAttacks.MinDamage, Is.EqualTo(63));
            Assert.That(testCandidate.PhysicalDamageWithRangedAttacks.MaxDamage, Is.EqualTo(141));
            Assert.That(testCandidate.PhysicalDamageWithSpells.MinDamage, Is.EqualTo(109));
            Assert.That(testCandidate.PhysicalDamageWithSpells.MaxDamage, Is.EqualTo(160));
            Assert.That(testCandidate.AccuracyRating, Is.EqualTo(642));
            Assert.That(testCandidate.EvasionRating, Is.EqualTo(726));
            Assert.That(testCandidate.AttacksPerSecond, Is.EqualTo(3.0576001495361336));
            Assert.That(testCandidate.MovementSpeed, Is.EqualTo(423));
        }

        [Test]
        public void TestCalculateAddsEquipmentStatsWhenCalculatingStrength()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();
            StatsFromEquipment equipmentStats = new StatsFromEquipment();

            equipmentStats.IncreasePlusStrengthBy(2);

            statModifiers.AddStrengthAddend(4);
            statModifiers.AddStrengthAddend(8);

            statModifiers.AddStrengthIncrease(0.3f);
            statModifiers.AddStrengthIncrease(0.5f);

            statModifiers.AddStrengthMultiplier(1.1f);
            statModifiers.AddStrengthMultiplier(1.6f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers, equipmentStats);

            Assert.That(testCandidate.Strength, Is.EqualTo(256));             
        }

        [Test]
        public void TestCalculateAddsEquipmentStatsWhenCalculatingAgility()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();
            StatsFromEquipment equipmentStats = new StatsFromEquipment();

            equipmentStats.IncreasePlusAgilityBy(2);

            statModifiers.AddAgilityAddend(2);
            statModifiers.AddAgilityAddend(5);

            statModifiers.AddAgilityIncrease(0.1f);
            statModifiers.AddAgilityIncrease(0.3f);

            statModifiers.AddAgilityMultiplier(1.2f);
            statModifiers.AddAgilityMultiplier(1.4f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers, equipmentStats);

            Assert.That(testCandidate.Agility, Is.EqualTo(101));             
        }

        [Test]
        public void TestCalculateAddsEquipmentStatsWhenCalculatingIntelligence()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();
            StatsFromEquipment equipmentStats = new StatsFromEquipment();

            equipmentStats.IncreasePlusIntelligenceBy(5);

            statModifiers.AddIntelligenceAddend(3);
            statModifiers.AddIntelligenceAddend(9);

            statModifiers.AddIntelligenceIncrease(0.2f);
            statModifiers.AddIntelligenceIncrease(0.4f);

            statModifiers.AddIntelligenceMultiplier(1.3f);
            statModifiers.AddIntelligenceMultiplier(1.5f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers, equipmentStats);

            Assert.That(testCandidate.Intelligence, Is.EqualTo(193));             
        }

        [Test]
        public void TestCalculateAddsEquipmentStatsWhenCalculatingMaximumLife()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();
            StatsFromEquipment equipmentStats = new StatsFromEquipment();

            equipmentStats.IncreasePlusMaximumLifeBy(23);
            equipmentStats.IncreaseIncreasedMaximumLifeInPercentBy(8);

            statModifiers.AddMaximumLifeAddend(50);
            statModifiers.AddMaximumLifeAddend(100);

            statModifiers.AddMaximumLifeIncrease(0.2f);
            statModifiers.AddMaximumLifeIncrease(0.4f);

            statModifiers.AddMaximumLifeMultiplier(1.3f);
            statModifiers.AddMaximumLifeMultiplier(1.5f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers, equipmentStats);

            Assert.That(testCandidate.MaximumLife, Is.EqualTo(2312));             
        }

        [Test]
        public void TestCalculateAddsEquipmentStatsWhenCalculatingMaximumMana()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();
            StatsFromEquipment equipmentStats = new StatsFromEquipment();

            equipmentStats.IncreasePlusMaximumManaBy(35);

            statModifiers.AddMaximumManaAddend(20);
            statModifiers.AddMaximumManaAddend(30);

            statModifiers.AddMaximumManaIncrease(0.1f);
            statModifiers.AddMaximumManaIncrease(0.3f);

            statModifiers.AddMaximumManaMultiplier(1.2f);
            statModifiers.AddMaximumManaMultiplier(1.4f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers, equipmentStats);

            Assert.That(testCandidate.MaximumMana, Is.EqualTo(722));       
        }

        [Test]
        public void TestCalculateAddsEquipmentStatsWhenCalculatingMeleePhysicalDamage()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();
            StatsFromEquipment equipmentStats = new StatsFromEquipment();

            equipmentStats.IncreaseIncreasedPhysicalDamageWithAttacksInPercentBy(1);
            equipmentStats.IncreaseIncreasedPhysicalDamageInPercentBy(6);

            statModifiers.AddAddedPhysicalDamage(new DamageRange(5, 10));
            statModifiers.AddAddedPhysicalDamage(new DamageRange(7, 15));

            statModifiers.AddAddedPhysicalDamageIncrease(0.2f);
            statModifiers.AddAddedPhysicalDamageIncrease(0.4f);

            statModifiers.AddAddedPhysicalDamageMultiplier(1.3f);
            statModifiers.AddAddedPhysicalDamageMultiplier(1.5f);

            statModifiers.AddAddedPhysicalDamageWithMeleeAttacks(new DamageRange(18, 19));
            statModifiers.AddAddedPhysicalDamageWithMeleeAttacksIncrease(0.1f);
            statModifiers.AddAddedPhysicalDamageWithMeleeAttacksMultiplier(1.05f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers, equipmentStats);

            Assert.That(testCandidate.PhysicalDamageWithMeleeAttacks.MinDamage, Is.EqualTo(159));
            Assert.That(testCandidate.PhysicalDamageWithMeleeAttacks.MaxDamage, Is.EqualTo(260));    
        }

        [Test]
        public void TestCalculateAddsEquipmentStatsWhenCalculatingRangedPhysicalDamage()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();
            StatsFromEquipment equipmentStats = new StatsFromEquipment();

            equipmentStats.IncreaseIncreasedPhysicalDamageWithAttacksInPercentBy(9);
            equipmentStats.IncreaseIncreasedPhysicalDamageInPercentBy(2);

            statModifiers.AddAddedPhysicalDamage(new DamageRange(5, 10));
            statModifiers.AddAddedPhysicalDamage(new DamageRange(7, 15));

            statModifiers.AddAddedPhysicalDamageIncrease(0.2f);
            statModifiers.AddAddedPhysicalDamageIncrease(0.4f);

            statModifiers.AddAddedPhysicalDamageMultiplier(1.3f);
            statModifiers.AddAddedPhysicalDamageMultiplier(1.5f);

            statModifiers.AddAddedPhysicalDamageWithRangedAttacks(new DamageRange(6, 15));
            statModifiers.AddAddedPhysicalDamageWithRangedAttacksIncrease(0.05f);
            statModifiers.AddAddedPhysicalDamageWithRangedAttacksMultiplier(1.1f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers, equipmentStats);

            Assert.That(testCandidate.PhysicalDamageWithRangedAttacks.MinDamage, Is.EqualTo(67));
            Assert.That(testCandidate.PhysicalDamageWithRangedAttacks.MaxDamage, Is.EqualTo(151));
        }

        [Test]
        public void TestCalculateAddsEquipmentStatsWhenCalculatingSpellPhysicalDamage()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();
            StatsFromEquipment equipmentStats = new StatsFromEquipment();

            equipmentStats.IncreaseIncreasedPhysicalDamageInPercentBy(10);

            statModifiers.AddAddedPhysicalDamage(new DamageRange(5, 10));
            statModifiers.AddAddedPhysicalDamage(new DamageRange(7, 15));

            statModifiers.AddAddedPhysicalDamageIncrease(0.2f);
            statModifiers.AddAddedPhysicalDamageIncrease(0.4f);

            statModifiers.AddAddedPhysicalDamageMultiplier(1.3f);
            statModifiers.AddAddedPhysicalDamageMultiplier(1.5f);

            statModifiers.AddAddedPhysicalDamageWithSpells(new DamageRange(18, 19));
            statModifiers.AddAddedPhysicalDamageWithSpellsIncrease(0.07f);
            statModifiers.AddAddedPhysicalDamageWithSpellsMultiplier(1.12f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers, equipmentStats);

            Assert.That(testCandidate.PhysicalDamageWithSpells.MinDamage, Is.EqualTo(115));
            Assert.That(testCandidate.PhysicalDamageWithSpells.MaxDamage, Is.EqualTo(170));
        }

        [Test]
        public void TestCalculateAddsEquipmentStatsWhenCalculatingAccuracy()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();
            StatsFromEquipment equipmentStats = new StatsFromEquipment();

            equipmentStats.IncreasePlusAccuracyBy(8);

            statModifiers.AddAccuracyRatingAddend(10);
            statModifiers.AddAccuracyRatingAddend(20);

            statModifiers.AddAccuracyRatingIncrease(0.1f);
            statModifiers.AddAccuracyRatingIncrease(0.3f);

            statModifiers.AddAccuracyRatingMultiplier(1.2f);
            statModifiers.AddAccuracyRatingMultiplier(1.4f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers, equipmentStats);

            Assert.That(testCandidate.AccuracyRating, Is.EqualTo(369)); 
        }

        private PlayerCharacterAdditionalStats CreateAdditionalStats()
        {
            PlayerCharacterAdditionalStats result = new PlayerCharacterAdditionalStats();

            result.AddIntelligenceAddend(3);
            result.AddIntelligenceAddend(9);

            result.AddIntelligenceIncrease(0.2f);
            result.AddIntelligenceIncrease(0.4f);

            result.AddIntelligenceMultiplier(1.3f);
            result.AddIntelligenceMultiplier(1.5f);

            result.AddAgilityAddend(2);
            result.AddAgilityAddend(5);

            result.AddAgilityIncrease(0.1f);
            result.AddAgilityIncrease(0.3f);

            result.AddAgilityMultiplier(1.2f);
            result.AddAgilityMultiplier(1.4f);

            result.AddStrengthAddend(4);
            result.AddStrengthAddend(8);

            result.AddStrengthIncrease(0.3f);
            result.AddStrengthIncrease(0.5f);

            result.AddStrengthMultiplier(1.1f);
            result.AddStrengthMultiplier(1.6f);

            result.AddMaximumLifeAddend(50);
            result.AddMaximumLifeAddend(100);

            result.AddMaximumLifeIncrease(0.2f);
            result.AddMaximumLifeIncrease(0.4f);

            result.AddMaximumLifeMultiplier(1.3f);
            result.AddMaximumLifeMultiplier(1.5f);

            result.AddMaximumManaAddend(20);
            result.AddMaximumManaAddend(30);

            result.AddMaximumManaIncrease(0.1f);
            result.AddMaximumManaIncrease(0.3f);

            result.AddMaximumManaMultiplier(1.2f);
            result.AddMaximumManaMultiplier(1.4f);

            result.AddAddedPhysicalDamage(new DamageRange(5, 10));
            result.AddAddedPhysicalDamage(new DamageRange(7, 15));

            result.AddAddedPhysicalDamageIncrease(0.2f);
            result.AddAddedPhysicalDamageIncrease(0.4f);

            result.AddAddedPhysicalDamageMultiplier(1.3f);
            result.AddAddedPhysicalDamageMultiplier(1.5f);

            result.AddAddedPhysicalDamageWithMeleeAttacks(new DamageRange(18, 19));
            result.AddAddedPhysicalDamageWithMeleeAttacksIncrease(0.1f);
            result.AddAddedPhysicalDamageWithMeleeAttacksMultiplier(1.05f);

            result.AddAddedPhysicalDamageWithRangedAttacks(new DamageRange(6, 15));
            result.AddAddedPhysicalDamageWithRangedAttacksIncrease(0.05f);
            result.AddAddedPhysicalDamageWithRangedAttacksMultiplier(1.1f);

            result.AddAddedPhysicalDamageWithSpells(new DamageRange(18, 19));
            result.AddAddedPhysicalDamageWithSpellsIncrease(0.07f);
            result.AddAddedPhysicalDamageWithSpellsMultiplier(1.12f);

            result.AddAccuracyRatingAddend(10);
            result.AddAccuracyRatingAddend(20);

            result.AddAccuracyRatingIncrease(0.1f);
            result.AddAccuracyRatingIncrease(0.3f);

            result.AddAccuracyRatingMultiplier(1.2f);
            result.AddAccuracyRatingMultiplier(1.4f);

            result.AddEvasionRatingAddend(15);
            result.AddEvasionRatingAddend(25);

            result.AddEvasionRatingIncrease(0.2f);
            result.AddEvasionRatingIncrease(0.4f);

            result.AddEvasionRatingMultiplier(1.3f);
            result.AddEvasionRatingMultiplier(1.5f);

            result.AddAttacksPerSecondIncrease(0.1f);
            result.AddAttacksPerSecondIncrease(0.2f);

            result.AddAttacksPerSecondMultiplier(1.2f);
            result.AddAttacksPerSecondMultiplier(1.4f);

            result.AddMovementSpeedAddend(10);
            result.AddMovementSpeedAddend(20);

            result.AddMovementSpeedIncrease(0.1f);
            result.AddMovementSpeedIncrease(0.3f);

            result.AddMovementSpeedMultiplier(1.2f);
            result.AddMovementSpeedMultiplier(1.4f);

            return result;
        }

        private PlayerCharacterBaseStats CreateBaseStats()
        {
            return new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .SetLevel(13)
                .SetIntelligence(45)
                .SetAgility(34)
                .SetStrength(67)
                .SetMaxLife(500)
                .SetMaxMana(200)
                .SetAccuracyRating(51)
                .SetEvasionRating(168)
                .SetBasePhysicalDamageWithMeleeAttacks(new DamageRange(11, 23))
                .SetAttacksPerSecond(1.4)
                .SetMovementSpeed(150)
                .Build();
        }
    }
}
    