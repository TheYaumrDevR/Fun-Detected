using NUnit.Framework;

namespace Org.Ethasia.Fundetected.Core.Map.Tests
{
    public class PlayerCharacterTotalStatsTest
    {
        [Test]
        public void TestCalculateAddsIncreasesAndMultipliesIntelligenceProperly()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();

            statModifiers.AddIntelligenceAddend(3);
            statModifiers.AddIntelligenceAddend(9);

            statModifiers.AddIntelligenceIncrease(0.2f);
            statModifiers.AddIntelligenceIncrease(0.4f);

            statModifiers.AddIntelligenceMultiplier(1.3f);
            statModifiers.AddIntelligenceMultiplier(1.5f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers);

            Assert.That(testCandidate.Intelligence, Is.EqualTo(177)); 
        }

        [Test]
        public void TestCalculateAddsIncreasesAndMultipliesAgilityProperly()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();

            statModifiers.AddAgilityAddend(2);
            statModifiers.AddAgilityAddend(5);

            statModifiers.AddAgilityIncrease(0.1f);
            statModifiers.AddAgilityIncrease(0.3f);

            statModifiers.AddAgilityMultiplier(1.2f);
            statModifiers.AddAgilityMultiplier(1.4f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers);

            Assert.That(testCandidate.Agility, Is.EqualTo(96)); 
        }

        [Test]
        public void TestCalculateAddsIncreasesAndMultipliesStrengthProperly()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();

            statModifiers.AddStrengthAddend(4);
            statModifiers.AddStrengthAddend(8);

            statModifiers.AddStrengthIncrease(0.3f);
            statModifiers.AddStrengthIncrease(0.5f);

            statModifiers.AddStrengthMultiplier(1.1f);
            statModifiers.AddStrengthMultiplier(1.6f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers);

            Assert.That(testCandidate.Strength, Is.EqualTo(250)); 
        }

        [Test]
        public void TestCalculateAddsIncreasesAndMultipliesMaximumLifeProperly()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();

            statModifiers.AddMaximumLifeAddend(50);
            statModifiers.AddMaximumLifeAddend(100);

            statModifiers.AddMaximumLifeIncrease(0.2f);
            statModifiers.AddMaximumLifeIncrease(0.4f);

            statModifiers.AddMaximumLifeMultiplier(1.3f);
            statModifiers.AddMaximumLifeMultiplier(1.5f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers);

            Assert.That(testCandidate.MaximumLife, Is.EqualTo(2130)); 
        }

        [Test]
        public void TestCalculateAddsIncreasesAndMultipliesMaximumManaProperly()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();

            statModifiers.AddMaximumManaAddend(20);
            statModifiers.AddMaximumManaAddend(30);

            statModifiers.AddMaximumManaIncrease(0.1f);
            statModifiers.AddMaximumManaIncrease(0.3f);

            statModifiers.AddMaximumManaMultiplier(1.2f);
            statModifiers.AddMaximumManaMultiplier(1.4f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers);

            Assert.That(testCandidate.MaximumMana, Is.EqualTo(639)); 
        }

        [Test]
        public void TestCalculateAddsIncreasesAndMultipliesMeleePhysicalDamageProperly()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();

            statModifiers.AddAddedPhysicalDamage(new DamageRange(5, 10));
            statModifiers.AddAddedPhysicalDamage(new DamageRange(7, 15));

            statModifiers.AddAddedPhysicalDamageIncrease(0.2f);
            statModifiers.AddAddedPhysicalDamageIncrease(0.4f);

            statModifiers.AddAddedPhysicalDamageMultiplier(1.3f);
            statModifiers.AddAddedPhysicalDamageMultiplier(1.5f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers);

            Assert.That(testCandidate.PhysicalDamageWithMeleeAttacks.MinDamage, Is.EqualTo(76));
            Assert.That(testCandidate.PhysicalDamageWithMeleeAttacks.MaxDamage, Is.EqualTo(161));
        }

        [Test]
        public void TestCalculateAddsIncreasesAndMultipliesAccuracyRatingProperly()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();

            statModifiers.AddAccuracyRatingAddend(10);
            statModifiers.AddAccuracyRatingAddend(20);

            statModifiers.AddAccuracyRatingIncrease(0.1f);
            statModifiers.AddAccuracyRatingIncrease(0.3f);

            statModifiers.AddAccuracyRatingMultiplier(1.2f);
            statModifiers.AddAccuracyRatingMultiplier(1.4f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers);

            Assert.That(testCandidate.AccuracyRating, Is.EqualTo(350)); 
        }

        [Test]
        public void TestCalculateAddsIncreasesAndMultipliesEvasionRatingProperly()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();

            statModifiers.AddEvasionRatingAddend(15);
            statModifiers.AddEvasionRatingAddend(25);

            statModifiers.AddEvasionRatingIncrease(0.2f);
            statModifiers.AddEvasionRatingIncrease(0.4f);

            statModifiers.AddEvasionRatingMultiplier(1.3f);
            statModifiers.AddEvasionRatingMultiplier(1.5f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers);

            Assert.That(testCandidate.EvasionRating, Is.EqualTo(673)); 
        }

        [Test]
        public void TestCalculateAddsIncreasesAndMultipliesAttacksPerSecondProperly()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();

            statModifiers.AddAttacksPerSecondIncrease(0.1f);
            statModifiers.AddAttacksPerSecondIncrease(0.2f);

            statModifiers.AddAttacksPerSecondMultiplier(1.2f);
            statModifiers.AddAttacksPerSecondMultiplier(1.4f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers);

            Assert.That(testCandidate.AttacksPerSecond, Is.EqualTo(3.0576001495361336)); 
        }

        [Test]
        public void TestCalculateAddsIncreasesAndMultipliesMovementSpeedProperly()
        {
            PlayerCharacterAdditionalStats statModifiers = new PlayerCharacterAdditionalStats();

            statModifiers.AddMovementSpeedAddend(10);
            statModifiers.AddMovementSpeedAddend(20);

            statModifiers.AddMovementSpeedIncrease(0.1f);
            statModifiers.AddMovementSpeedIncrease(0.3f);

            statModifiers.AddMovementSpeedMultiplier(1.2f);
            statModifiers.AddMovementSpeedMultiplier(1.4f);

            PlayerCharacterBaseStats baseStats = CreateBaseStats();

            PlayerCharacterTotalStats testCandidate = new PlayerCharacterTotalStats();

            testCandidate.Calculate(baseStats, statModifiers);

            Assert.That(testCandidate.MovementSpeed, Is.EqualTo(423)); 
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
    