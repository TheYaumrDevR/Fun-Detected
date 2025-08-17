using NUnit.Framework;

using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Interactors.Mocks;
using Org.Ethasia.Fundetected.Ioadapters;
using Org.Ethasia.Fundetected.Ioadapters.Mocks;
using Org.Ethasia.Fundetected.Ioadapters.Technical;
using Org.Ethasia.Fundetected.Technical.Mocks;

namespace Org.Ethasia.Fundetected.Interactors.Tests
{

    public class PlayerSkillInteractorTest
    {
        private RandomNumberGeneratorMock rngMock;

        [OneTimeSetUp] 
        public void Init()
        {
            IoAdaptersFactoryForInteractors.SetInstance(new MockedIoAdaptersFactoryForInteractorsWithRealMapDefinitionGateway());
            TechnicalFactory.SetInstance(new TechnicalMockFactory());
        }

        [SetUp]
        public void ResetStates()
        {
            int[] randomNumbersToGenerate = {0, 0, 5, 7, 9, 5, 2};
            float[] randomFloatsToGenerate = {};   
            double[] randomDoublesToGenerate = {};    

            rngMock = new RandomNumberGeneratorMock(randomNumbersToGenerate, randomFloatsToGenerate, randomDoublesToGenerate);
            MockedIoAdaptersFactoryForCore ioAdaptersFactoryForCore = new MockedIoAdaptersFactoryForCore();
            ioAdaptersFactoryForCore.SetRngInstance(rngMock);

            InternalInteractorsFactory.SetInstance(new InternalInteractorsFactoryMock());
            IoAdaptersFactoryForCore.SetInstance(ioAdaptersFactoryForCore);
        }

        [Test]
        public void TestExecutePrimaryPlayerActionDealsDamage()
        {   
            StartGameInteractor startGameInteractor = new StartGameInteractor();
            startGameInteractor.CreateCharacterAndStartGame(CharacterClasses.JOCK);

            Area.ActiveArea.RemoveEnemies();
            Area.ActiveArea.AddEnemy(CreateTestEnemy());

            PlayerSkillInteractor testCandidate = new PlayerSkillInteractor();
            testCandidate.ExecutePrimaryPlayerAction();

            Area.ActiveArea.Player.Tick(1.5);

            Enemy enemy = Area.ActiveArea.Enemies[0];

            Assert.That(enemy.CurrentLife, Is.EqualTo(26));  
        }

        [Test]
        public void TestExecutePrimaryPlayerActionTimeBetweenTwoAttacksTooShort()
        {   
            StartGameInteractor startGameInteractor = new StartGameInteractor();
            startGameInteractor.CreateCharacterAndStartGame(CharacterClasses.CUCK);

            PlayerRepeatedUpdateInteractor repeatedUpdateInteractor = new PlayerRepeatedUpdateInteractor();

            Area.ActiveArea.RemoveEnemies();
            Area.ActiveArea.AddEnemy(CreateTestEnemy());

            PlayerSkillInteractor testCandidate = new PlayerSkillInteractor();
            testCandidate.ExecutePrimaryPlayerAction();

            repeatedUpdateInteractor.Update(0.63);

            testCandidate.ExecutePrimaryPlayerAction();

            Area.ActiveArea.Player.Tick(0.2);

            Enemy enemy = Area.ActiveArea.Enemies[0];

            Assert.That(enemy.CurrentLife, Is.EqualTo(26));  
        }   

        [Test]
        public void TestExecutePrimaryPlayerActionTimeBetweenTwoAttacksLongEnough()
        {   
            StartGameInteractor startGameInteractor = new StartGameInteractor();
            startGameInteractor.CreateCharacterAndStartGame(CharacterClasses.DUELIST);

            PlayerRepeatedUpdateInteractor repeatedUpdateInteractor = new PlayerRepeatedUpdateInteractor();

            Area.ActiveArea.RemoveEnemies();
            Area.ActiveArea.AddEnemy(CreateTestEnemy());

            PlayerSkillInteractor testCandidate = new PlayerSkillInteractor();
            testCandidate.ExecutePrimaryPlayerAction();

            repeatedUpdateInteractor.Update(0.9);

            testCandidate.ExecutePrimaryPlayerAction();

            repeatedUpdateInteractor.Update(0.5);

            Enemy enemy = Area.ActiveArea.Enemies[0];

            Assert.That(enemy.CurrentLife, Is.EqualTo(20));  
        }  

        [Test]
        public void TestExecutePrimaryPlayerActionAttackMisses()
        {   
            int[] randomNumbersToGenerate = {0, 0, 5, 7, 9, 5, 2};
            float[] randomFloatsToGenerate = {0.95f};       
            double[] randomDoublesToGenerate = {};

            RandomNumberGeneratorMock localRngMock = new RandomNumberGeneratorMock(randomNumbersToGenerate, randomFloatsToGenerate, randomDoublesToGenerate);
            MockedIoAdaptersFactoryForCore ioAdaptersFactoryForCore = new MockedIoAdaptersFactoryForCore();
            ioAdaptersFactoryForCore.SetRngInstance(localRngMock);

            IoAdaptersFactoryForCore.SetInstance(ioAdaptersFactoryForCore);         

            StartGameInteractor startGameInteractor = new StartGameInteractor();
            startGameInteractor.CreateCharacterAndStartGame(CharacterClasses.MAGICIAN);

            localRngMock.Reset();

            Area.ActiveArea.RemoveEnemies();
            Area.ActiveArea.AddEnemy(CreateTestEnemy());

            PlayerSkillInteractor testCandidate = new PlayerSkillInteractor();
            testCandidate.ExecutePrimaryPlayerAction();

            Area.ActiveArea.Player.Tick(1.5);

            Enemy enemy = Area.ActiveArea.Enemies[0];

            Assert.That(enemy.CurrentLife, Is.EqualTo(30));  
        }  

        [Test]
        public void TestExecutePrimaryPlayerActionPlayerFacesLeftAttackHits()
        {  
            StartGameInteractor startGameInteractor = new StartGameInteractor();
            startGameInteractor.CreateCharacterAndStartGame(CharacterClasses.CUCK);

            Area.ActiveArea.RemoveEnemies();
            Area.ActiveArea.AddEnemy(CreateTestEnemy());

            PlayerSkillInteractor testCandidate = new PlayerSkillInteractor();

            PlayerCharacter player = Area.ActiveArea.Player;
            player.MoveLeft(0.1);

            testCandidate.ExecutePrimaryPlayerAction();

            Area.ActiveArea.Player.Tick(1.5);

            Enemy enemy = Area.ActiveArea.Enemies[0];

            Assert.That(enemy.CurrentLife, Is.EqualTo(26));              
        } 

        [Test]
        public void TestExecutePrimaryPlayerActionPlayerFacesLeftAndTimeBetweenTwoAttacksLongEnough()
        {   
            StartGameInteractor startGameInteractor = new StartGameInteractor();
            startGameInteractor.CreateCharacterAndStartGame(CharacterClasses.DUELIST);

            PlayerRepeatedUpdateInteractor repeatedUpdateInteractor = new PlayerRepeatedUpdateInteractor();

            Area.ActiveArea.RemoveEnemies();
            Area.ActiveArea.AddEnemy(CreateTestEnemy());

            PlayerSkillInteractor testCandidate = new PlayerSkillInteractor();

            PlayerCharacter player = Area.ActiveArea.Player;
            player.MoveLeft(0.1);

            testCandidate.ExecutePrimaryPlayerAction();

            repeatedUpdateInteractor.Update(0.9);

            testCandidate.ExecutePrimaryPlayerAction();

            repeatedUpdateInteractor.Update(0.5);

            Enemy enemy = Area.ActiveArea.Enemies[0];

            Assert.That(enemy.CurrentLife, Is.EqualTo(20));  
        }                

        private Enemy CreateTestEnemy()
        {
            Position enemyPosition = new Position(-141, -56);

            BoundingBox enemyBoundingBox = new BoundingBox.Builder()
                .SetDistanceToLeftEdge(5)
                .SetDistanceToRightEdge(5)
                .SetDistanceToTopEdge(5)
                .SetDistanceToBottomEdge(5)
                .Build();

            return new Enemy.Builder()
                .SetName("Drowned Zombie")
                .SetLife(30)
                .SetArmor(1)
                .SetEvasionRating(98)
                .SetPosition(enemyPosition)
                .SetBoundingBox(enemyBoundingBox)
                .Build();         
        }           

        private class MockedIoAdaptersFactoryForInteractorsWithRealMapDefinitionGateway : MockedIoAdaptersFactoryForInteractors
        {
            public override IMapDefinitionGateway GetMapDefinitionGatewayInstance()
            {
                return new XmlFilesBasedMapDefinitionGateway();
            }

            public override IMapChunkGateway GetMapChunkGatewayInstance()
            {
                return new XmlFilesBasedMapChunkGateway();
            }            
        }      
    }
}