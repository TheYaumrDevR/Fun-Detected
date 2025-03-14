using NUnit.Framework;

namespace Org.Ethasia.Fundetected.Interactors.Tests
{
    public class FixedStatsPerLevelEnemyScalingMasterDataTest
    {
        [Test]
        public void TestScaleMasterDataScalesByValueTimesLevelDiff()
        {
            EnemyMasterData result = ExecuteStandardTest(27);

            Assert.That(result.ScalableMasterData.MaxLife, Is.EqualTo(360));
            Assert.That(result.ScalableMasterData.Armor, Is.EqualTo(180));
            Assert.That(result.ScalableMasterData.FireResistance, Is.EqualTo(72));
            Assert.That(result.ScalableMasterData.IceResistance, Is.EqualTo(72));
            Assert.That(result.ScalableMasterData.LightningResistance, Is.EqualTo(72));
            Assert.That(result.ScalableMasterData.MagicResistance, Is.EqualTo(72));
            Assert.That(result.ScalableMasterData.MinPhysicalDamage, Is.EqualTo(72));
            Assert.That(result.ScalableMasterData.MaxPhysicalDamage, Is.EqualTo(144));
            Assert.That(result.ScalableMasterData.AccuracyRating, Is.EqualTo(72));
            Assert.That(result.ScalableMasterData.EvasionRating, Is.EqualTo(72));
        }

        [Test]
        public void TestScaleMasterDataDoesNotScaleBeyondLevel100()
        {
            EnemyMasterData result = ExecuteStandardTest(102);

            Assert.That(result.ScalableMasterData.MaxLife, Is.EqualTo(1090));
            Assert.That(result.ScalableMasterData.Armor, Is.EqualTo(545));
            Assert.That(result.ScalableMasterData.FireResistance, Is.EqualTo(218));
            Assert.That(result.ScalableMasterData.IceResistance, Is.EqualTo(218));
            Assert.That(result.ScalableMasterData.LightningResistance, Is.EqualTo(218));
            Assert.That(result.ScalableMasterData.MagicResistance, Is.EqualTo(218));
            Assert.That(result.ScalableMasterData.MinPhysicalDamage, Is.EqualTo(218));
            Assert.That(result.ScalableMasterData.MaxPhysicalDamage, Is.EqualTo(436));
            Assert.That(result.ScalableMasterData.AccuracyRating, Is.EqualTo(218));
            Assert.That(result.ScalableMasterData.EvasionRating, Is.EqualTo(218));                          
        }

        [Test]
        public void TestScaleMasterDataDoesNotScaleWhenLevelDifferenceSmallerOne()
        {
            EnemyMasterData result = ExecuteStandardTest(0);

            Assert.That(result.ScalableMasterData.MaxLife, Is.EqualTo(100));
            Assert.That(result.ScalableMasterData.Armor, Is.EqualTo(50));
            Assert.That(result.ScalableMasterData.FireResistance, Is.EqualTo(20));
            Assert.That(result.ScalableMasterData.IceResistance, Is.EqualTo(20));
            Assert.That(result.ScalableMasterData.LightningResistance, Is.EqualTo(20));
            Assert.That(result.ScalableMasterData.MagicResistance, Is.EqualTo(20));
            Assert.That(result.ScalableMasterData.MinPhysicalDamage, Is.EqualTo(20));
            Assert.That(result.ScalableMasterData.MaxPhysicalDamage, Is.EqualTo(40));
            Assert.That(result.ScalableMasterData.AccuracyRating, Is.EqualTo(20));
            Assert.That(result.ScalableMasterData.EvasionRating, Is.EqualTo(20));                          
        }        

        private EnemyMasterData ExecuteStandardTest(int targetLevel)
        {
            ScalableEnemyMasterData additionsPerLevel = new ScalableEnemyMasterData();
            additionsPerLevel.MaxLife = 10;
            additionsPerLevel.Armor = 5;
            additionsPerLevel.FireResistance = 2;
            additionsPerLevel.IceResistance = 2;
            additionsPerLevel.LightningResistance = 2;
            additionsPerLevel.MagicResistance = 2;
            additionsPerLevel.MinPhysicalDamage = 2;
            additionsPerLevel.MaxPhysicalDamage = 4;
            additionsPerLevel.AccuracyRating = 2;
            additionsPerLevel.EvasionRating = 2;        

            FixedStatsPerLevelEnemyScalingMasterData testCandidate = new FixedStatsPerLevelEnemyScalingMasterData();
            testCandidate.AdditionsPerLevel = additionsPerLevel;

            EnemyMasterData testData = new EnemyMasterData();
            ScalableEnemyMasterData scalableMasterData = new ScalableEnemyMasterData();
            scalableMasterData.MaxLife = 100;
            scalableMasterData.Armor = 50;
            scalableMasterData.FireResistance = 20;
            scalableMasterData.IceResistance = 20;
            scalableMasterData.LightningResistance = 20;
            scalableMasterData.MagicResistance = 20;
            scalableMasterData.MinPhysicalDamage = 20;
            scalableMasterData.MaxPhysicalDamage = 40;
            scalableMasterData.AccuracyRating = 20;
            scalableMasterData.EvasionRating = 20;
            testData.ScalableMasterData = scalableMasterData;
            testData.MinimumSpawnLevel = 1;

            return testCandidate.ScaleMasterData(testData, targetLevel);              
        }
    }
}