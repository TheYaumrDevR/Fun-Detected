using NUnit.Framework;

using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters.Mocks;

namespace Org.Ethasia.Fundetected.Interactors.Tests
{

    public class PlayerSkillInteractorTest
    {

        [OneTimeSetUp] 
        public void Init()
        {
            IoAdaptersFactoryForInteractors.SetInstance(new MockedIoAdaptersFactoryForInteractors());
        }

        [SetUp]
        public void ResetStates()
        {
            int[] randomNumbersToGenerate = {5, 7, 9, 5, 2};
            float[] randomFloatsToGenerate = {};       

            RandomNumberGeneratorMock rngMock = new RandomNumberGeneratorMock(randomNumbersToGenerate, randomFloatsToGenerate);
            MockedIoAdaptersFactoryForCore ioAdaptersFactoryForCore = new MockedIoAdaptersFactoryForCore();
            ioAdaptersFactoryForCore.SetRngInstance(rngMock);

            IoAdaptersFactoryForCore.SetInstance(ioAdaptersFactoryForCore);
        }

        [Test]
        public void TestExecutePrimaryPlayerActionDealsDamage()
        {   
            StartGameInteractor startGameInteractor = new StartGameInteractor();
            startGameInteractor.CreateCharacterAndStartGame(CharacterClasses.STRONGMAN);

            PlayerSkillInteractor testCandidate = new PlayerSkillInteractor();
            testCandidate.ExecutePrimaryPlayerAction(1000);

            Enemy enemy = Area.ActiveArea.GetEnemies()[0];

            Assert.That(enemy.CurrentLife, Is.EqualTo(26));  
        }

        [Test]
        public void TestExecutePrimaryPlayerActionTimeBetweenTwoAttacksTooShort()
        {   
            StartGameInteractor startGameInteractor = new StartGameInteractor();
            startGameInteractor.CreateCharacterAndStartGame(CharacterClasses.CUCK);

            PlayerSkillInteractor testCandidate = new PlayerSkillInteractor();
            testCandidate.ExecutePrimaryPlayerAction(1.0);
            testCandidate.ExecutePrimaryPlayerAction(1.4);

            Enemy enemy = Area.ActiveArea.GetEnemies()[0];

            Assert.That(enemy.CurrentLife, Is.EqualTo(26));  
        }        
    }
}