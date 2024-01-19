using NUnit.Framework;

using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters.Mocks;

namespace Org.Ethasia.Fundetected.Interactors.Tests
{

    public class PlayerSkillInteractorTest
    {
        private RandomNumberGeneratorMock rngMock;

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

            rngMock = new RandomNumberGeneratorMock(randomNumbersToGenerate, randomFloatsToGenerate);
            MockedIoAdaptersFactoryForCore ioAdaptersFactoryForCore = new MockedIoAdaptersFactoryForCore();
            ioAdaptersFactoryForCore.SetRngInstance(rngMock);

            IoAdaptersFactoryForCore.SetInstance(ioAdaptersFactoryForCore);
        }

        [Test]
        public void TestExecutePrimaryPlayerActionDealsDamage()
        {   
            StartGameInteractor startGameInteractor = new StartGameInteractor();
            startGameInteractor.CreateCharacterAndStartGame(CharacterClasses.STRONGMAN);

            rngMock.Reset();

            Area.ActiveArea.Enemies.Clear();
            Area.ActiveArea.AddEnemy(CreateTestEnemy());

            PlayerSkillInteractor testCandidate = new PlayerSkillInteractor();
            testCandidate.ExecutePrimaryPlayerAction(1000);

            Enemy enemy = Area.ActiveArea.Enemies[0];

            Assert.That(enemy.CurrentLife, Is.EqualTo(26));  
        }

        [Test]
        public void TestExecutePrimaryPlayerActionTimeBetweenTwoAttacksTooShort()
        {   
            StartGameInteractor startGameInteractor = new StartGameInteractor();
            startGameInteractor.CreateCharacterAndStartGame(CharacterClasses.CUCK);

            rngMock.Reset();

            Area.ActiveArea.Enemies.Clear();
            Area.ActiveArea.AddEnemy(CreateTestEnemy());

            PlayerSkillInteractor testCandidate = new PlayerSkillInteractor();
            testCandidate.ExecutePrimaryPlayerAction(1.0);
            testCandidate.ExecutePrimaryPlayerAction(1.4);

            Enemy enemy = Area.ActiveArea.Enemies[0];

            Assert.That(enemy.CurrentLife, Is.EqualTo(26));  
        }   

        [Test]
        public void TestExecutePrimaryPlayerActionTimeBetweenTwoAttacksLongEnough()
        {   
            StartGameInteractor startGameInteractor = new StartGameInteractor();
            startGameInteractor.CreateCharacterAndStartGame(CharacterClasses.DUELIST);

            rngMock.Reset();

            Area.ActiveArea.Enemies.Clear();
            Area.ActiveArea.AddEnemy(CreateTestEnemy());

            PlayerSkillInteractor testCandidate = new PlayerSkillInteractor();
            testCandidate.ExecutePrimaryPlayerAction(1.0);
            testCandidate.ExecutePrimaryPlayerAction(2.0);

            Enemy enemy = Area.ActiveArea.Enemies[0];

            Assert.That(enemy.CurrentLife, Is.EqualTo(20));  
        }  

        [Test]
        public void TestExecutePrimaryPlayerActionAttackMisses()
        {   
            int[] randomNumbersToGenerate = {5, 7, 9, 5, 2};
            float[] randomFloatsToGenerate = {0.95f};       

            RandomNumberGeneratorMock localRngMock = new RandomNumberGeneratorMock(randomNumbersToGenerate, randomFloatsToGenerate);
            MockedIoAdaptersFactoryForCore ioAdaptersFactoryForCore = new MockedIoAdaptersFactoryForCore();
            ioAdaptersFactoryForCore.SetRngInstance(localRngMock);

            IoAdaptersFactoryForCore.SetInstance(ioAdaptersFactoryForCore);            

            StartGameInteractor startGameInteractor = new StartGameInteractor();
            startGameInteractor.CreateCharacterAndStartGame(CharacterClasses.MAGICIAN);

            localRngMock.Reset();

            Area.ActiveArea.Enemies.Clear();
            Area.ActiveArea.AddEnemy(CreateTestEnemy());

            PlayerSkillInteractor testCandidate = new PlayerSkillInteractor();
            testCandidate.ExecutePrimaryPlayerAction(1.0);

            Enemy enemy = Area.ActiveArea.Enemies[0];

            Assert.That(enemy.CurrentLife, Is.EqualTo(30));  
        }   

        private Enemy CreateTestEnemy()
        {
            return new Enemy.Builder()
                .SetName("Drowned Zombie")
                .SetLife(30)
                .SetArmor(1)
                .SetEvasionRating(98)
                .Build();         
        }                 
    }
}