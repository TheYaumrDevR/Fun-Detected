using NUnit.Framework;

namespace Org.Ethasia.Fundetected.Core.Map.Tests
{
    public class PlayerLevelingSystemTest
    {
        [Test]
        public void TestAddExperiencePointsAddsExperiencePoints()
        {
            PlayerLevelingSystem levelingSystem = new PlayerLevelingSystem(1, 0);

            levelingSystem.AddExperiencePoints(400);

            Assert.That(levelingSystem.ExperiencePoints, Is.EqualTo(400));
        }

        [Test]
        public void TestAddExperiencePointsLevelsUpPlayerWhenPointsOverflow()
        {
            PlayerLevelingSystem levelingSystem = new PlayerLevelingSystem(23, 262000);

            levelingSystem.AddExperiencePoints(600);

            Assert.That(levelingSystem.Level, Is.EqualTo(24));
        }

        [Test]
        public void TestAddExperiencePointsDoesNotLevelUpPlayerWhenPointsDoNotOverflow()
        {
            PlayerLevelingSystem levelingSystem = new PlayerLevelingSystem(56, 7798000);

            levelingSystem.AddExperiencePoints(1000);

            Assert.That(levelingSystem.Level, Is.EqualTo(56));            
        }

        [Test]
        public void TestAddExperiencePointsLevelsUpTwiceWhenExperiencePointsOverflowTwice()
        {
            PlayerLevelingSystem levelingSystem = new PlayerLevelingSystem(29, 750000);

            levelingSystem.AddExperiencePoints(1000000);

            Assert.That(levelingSystem.Level, Is.EqualTo(31));             
        }

        [Test]
        public void TestAddExperiencePointsDoesNotLevelUpPlayerWhenMaxLevelReached()
        {
            PlayerLevelingSystem levelingSystem = new PlayerLevelingSystem(100, 0);

            levelingSystem.AddExperiencePoints(500000000);

            Assert.That(levelingSystem.Level, Is.EqualTo(100));               
        }

        [Test]
        public void TestAddExperiencePointsDoesNotLevelUpPast100WhenExperiencePointsOverflow()
        {
            PlayerLevelingSystem levelingSystem = new PlayerLevelingSystem(99, 300000000);

            levelingSystem.AddExperiencePoints(800000000);

            Assert.That(levelingSystem.Level, Is.EqualTo(100));              
        }
    }
}