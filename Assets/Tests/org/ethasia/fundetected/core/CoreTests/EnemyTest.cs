using NUnit.Framework;
using Org.Ethasia.Fundetected.Ioadapters.Mocks;

namespace Org.Ethasia.Fundetected.Core.Tests
{
    public class EnemyTest
    {
        [Test]
        public void TestTakePhysicalHitTakesDamage()
        {
            Enemy testCandidate = new Enemy
                .Builder()
                .SetLife(100)
                .Build();

            testCandidate.TakePhysicalHit(50);

            Assert.That(testCandidate.CurrentLife, Is.EqualTo(50));
        }

        [Test]
        public void TestTakePhysicalArmorMitigatesDamage()
        {
            Enemy testCandidate = new Enemy
                .Builder()
                .SetLife(100)
                .SetArmor(20)
                .Build();

            testCandidate.TakePhysicalHit(50);

            Assert.That(testCandidate.CurrentLife, Is.EqualTo(54));
        }    

        [Test]
        public void TestTakeNonPhysicalHitFireResistanceMitigatesDamage()
        {
            Enemy testCandidate = new Enemy
                .Builder()
                .SetLife(100)
                .SetFireResistance(0.2f)
                .Build();

            testCandidate.TakeNonPhysicalHit(100, ResistanceDamageTypes.FIRE);

            Assert.That(testCandidate.CurrentLife, Is.EqualTo(20));
        }     

        [Test]
        public void TestTakeNonPhysicalHitIceResistanceMitigatesDamage()
        {
            Enemy testCandidate = new Enemy
                .Builder()
                .SetLife(100)
                .SetIceResistance(0.5f)
                .Build();

            testCandidate.TakeNonPhysicalHit(100, ResistanceDamageTypes.ICE);

            Assert.That(testCandidate.CurrentLife, Is.EqualTo(50));
        }

        [Test]
        public void TestTakeNonPhysicalHitLightningResistanceMitigatesDamage()
        {
            Enemy testCandidate = new Enemy
                .Builder()
                .SetLife(100)
                .SetLightningResistance(0.75f)
                .Build();

            testCandidate.TakeNonPhysicalHit(100, ResistanceDamageTypes.LIGHTNING);

            Assert.That(testCandidate.CurrentLife, Is.EqualTo(75));
        }  

        [Test]
        public void TestTakeNonPhysicalHitMagicResistanceMitigatesDamage()
        {
            Enemy testCandidate = new Enemy
                .Builder()
                .SetLife(100)
                .SetMagicResistance(0.8f)
                .Build();

            testCandidate.TakeNonPhysicalHit(100, ResistanceDamageTypes.MAGIC);

            Assert.That(testCandidate.CurrentLife, Is.EqualTo(80));
        }                  

        [Test]
        public void TestAggressiveEnemyStrikesPlayerIfPlayerIsInRangeFromRight()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .Build();

            Area.ActiveArea = testArea;          

            Enemy testCandidate = CreateEnemyForAiAttackTests();

            PlayerCharacter player = CreatePlayerCharacterForAiAttackTests();

            testArea.AddEnemy(testCandidate);
            testArea.AddPlayerAt(player, 12, 17);

            testCandidate.Update(1.5f, testArea);           

            IEnemyAnimationPresenter enemyAnimationPresenterMock = IoAdaptersFactoryForCore.GetInstance().GetEnemyAnimationPresenterInstance();
            if (enemyAnimationPresenterMock is EnemyAnimationPresenterMock)
            {
                EnemyAnimationPresenterMock enemyAnimationPresenter = (EnemyAnimationPresenterMock)enemyAnimationPresenterMock;
                Assert.That(enemyAnimationPresenter.TimesPlayLeftStrikeAnimationWasCalled, Is.EqualTo(1));
                Assert.That(enemyAnimationPresenter.TimesPlayRightStrikeAnimationWasCalled, Is.EqualTo(0));

                enemyAnimationPresenter.Reset();
            }
        }

        [Test]
        public void TestAggressiveEnemyStrikesPlayerIfPlayerIsInRangeFromLeft()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .Build();

            Area.ActiveArea = testArea;          

            Enemy testCandidate = CreateEnemyForAiAttackTests();

            PlayerCharacter player = CreatePlayerCharacterForAiAttackTests();

            testArea.AddEnemy(testCandidate);
            testArea.AddPlayerAt(player, 28, 17);

            testCandidate.Update(1.5f, testArea);           

            IEnemyAnimationPresenter enemyAnimationPresenterMock = IoAdaptersFactoryForCore.GetInstance().GetEnemyAnimationPresenterInstance();
            if (enemyAnimationPresenterMock is EnemyAnimationPresenterMock)
            {
                EnemyAnimationPresenterMock enemyAnimationPresenter = (EnemyAnimationPresenterMock)enemyAnimationPresenterMock;
                Assert.That(enemyAnimationPresenter.TimesPlayLeftStrikeAnimationWasCalled, Is.EqualTo(0));
                Assert.That(enemyAnimationPresenter.TimesPlayRightStrikeAnimationWasCalled, Is.EqualTo(1));

                enemyAnimationPresenter.Reset();
            }
        }    

        [Test]
        public void TestAggressiveEnemyStrikesPlayerIfPlayerIsInRangeFromTop()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .Build();

            Area.ActiveArea = testArea;          

            Enemy testCandidate = CreateEnemyForAiAttackTests();

            PlayerCharacter player = CreatePlayerCharacterForAiAttackTests();

            testArea.AddEnemy(testCandidate);
            testArea.AddPlayerAt(player, 20, 12);

            testCandidate.Update(1.5f, testArea);           

            IEnemyAnimationPresenter enemyAnimationPresenterMock = IoAdaptersFactoryForCore.GetInstance().GetEnemyAnimationPresenterInstance();
            if (enemyAnimationPresenterMock is EnemyAnimationPresenterMock)
            {
                EnemyAnimationPresenterMock enemyAnimationPresenter = (EnemyAnimationPresenterMock)enemyAnimationPresenterMock;
                Assert.That(enemyAnimationPresenter.TimesPlayLeftStrikeAnimationWasCalled, Is.EqualTo(1));
                Assert.That(enemyAnimationPresenter.TimesPlayRightStrikeAnimationWasCalled, Is.EqualTo(0));

                enemyAnimationPresenter.Reset();
            }
        } 

        [Test]
        public void TestAggressiveEnemyStrikesPlayerIfPlayerIsInRangeFromBottom()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .Build();

            Area.ActiveArea = testArea;          

            Enemy testCandidate = CreateEnemyForAiAttackTests();

            PlayerCharacter player = CreatePlayerCharacterForAiAttackTests();

            testArea.AddEnemy(testCandidate);
            testArea.AddPlayerAt(player, 20, 28);

            testCandidate.Update(1.5f, testArea);           

            IEnemyAnimationPresenter enemyAnimationPresenterMock = IoAdaptersFactoryForCore.GetInstance().GetEnemyAnimationPresenterInstance();
            if (enemyAnimationPresenterMock is EnemyAnimationPresenterMock)
            {
                EnemyAnimationPresenterMock enemyAnimationPresenter = (EnemyAnimationPresenterMock)enemyAnimationPresenterMock;
                Assert.That(enemyAnimationPresenter.TimesPlayLeftStrikeAnimationWasCalled, Is.EqualTo(1));
                Assert.That(enemyAnimationPresenter.TimesPlayRightStrikeAnimationWasCalled, Is.EqualTo(0));

                enemyAnimationPresenter.Reset();
            }
        }        

        [Test]
        public void TestAggressiveEnemyStrikesPlayerIfPlayerIsNotInRangeFromRight()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .Build();

            Area.ActiveArea = testArea;          

            Enemy testCandidate = CreateEnemyForAiAttackTests();

            PlayerCharacter player = CreatePlayerCharacterForAiAttackTests();

            testArea.AddEnemy(testCandidate);
            testArea.AddPlayerAt(player, 9, 17);

            testCandidate.Update(1.5f, testArea);           

            IEnemyAnimationPresenter enemyAnimationPresenterMock = IoAdaptersFactoryForCore.GetInstance().GetEnemyAnimationPresenterInstance();
            if (enemyAnimationPresenterMock is EnemyAnimationPresenterMock)
            {
                EnemyAnimationPresenterMock enemyAnimationPresenter = (EnemyAnimationPresenterMock)enemyAnimationPresenterMock;
                Assert.That(enemyAnimationPresenter.TimesPlayLeftStrikeAnimationWasCalled, Is.EqualTo(0));
                Assert.That(enemyAnimationPresenter.TimesPlayRightStrikeAnimationWasCalled, Is.EqualTo(0));

                enemyAnimationPresenter.Reset();
            }
        }     

        [Test]
        public void TestAggressiveEnemyStrikesPlayerIfPlayerIsNotInRangeFromLeft()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .Build();

            Area.ActiveArea = testArea;          

            Enemy testCandidate = CreateEnemyForAiAttackTests();

            PlayerCharacter player = CreatePlayerCharacterForAiAttackTests();

            testArea.AddEnemy(testCandidate);
            testArea.AddPlayerAt(player, 30, 17);

            testCandidate.Update(1.5f, testArea);           

            IEnemyAnimationPresenter enemyAnimationPresenterMock = IoAdaptersFactoryForCore.GetInstance().GetEnemyAnimationPresenterInstance();
            if (enemyAnimationPresenterMock is EnemyAnimationPresenterMock)
            {
                EnemyAnimationPresenterMock enemyAnimationPresenter = (EnemyAnimationPresenterMock)enemyAnimationPresenterMock;
                Assert.That(enemyAnimationPresenter.TimesPlayLeftStrikeAnimationWasCalled, Is.EqualTo(0));
                Assert.That(enemyAnimationPresenter.TimesPlayRightStrikeAnimationWasCalled, Is.EqualTo(0));

                enemyAnimationPresenter.Reset();
            }
        }                          

        [Test]
        public void TestAggressiveEnemyStrikesPlayerIfPlayerIsNotInRangeFromTop()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .Build();

            Area.ActiveArea = testArea;          

            Enemy testCandidate = CreateEnemyForAiAttackTests();

            PlayerCharacter player = CreatePlayerCharacterForAiAttackTests();

            testArea.AddEnemy(testCandidate);
            testArea.AddPlayerAt(player, 20, 10);

            testCandidate.Update(1.5f, testArea);           

            IEnemyAnimationPresenter enemyAnimationPresenterMock = IoAdaptersFactoryForCore.GetInstance().GetEnemyAnimationPresenterInstance();
            if (enemyAnimationPresenterMock is EnemyAnimationPresenterMock)
            {
                EnemyAnimationPresenterMock enemyAnimationPresenter = (EnemyAnimationPresenterMock)enemyAnimationPresenterMock;
                Assert.That(enemyAnimationPresenter.TimesPlayLeftStrikeAnimationWasCalled, Is.EqualTo(0));
                Assert.That(enemyAnimationPresenter.TimesPlayRightStrikeAnimationWasCalled, Is.EqualTo(0));

                enemyAnimationPresenter.Reset();
            }
        } 

        [Test]
        public void TestAggressiveEnemyStrikesPlayerIfPlayerIsNotInRangeFromBottom()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .Build();

            Area.ActiveArea = testArea;          

            Enemy testCandidate = CreateEnemyForAiAttackTests();

            PlayerCharacter player = CreatePlayerCharacterForAiAttackTests();

            testArea.AddEnemy(testCandidate);
            testArea.AddPlayerAt(player, 20, 31);

            testCandidate.Update(1.5f, testArea);           

            IEnemyAnimationPresenter enemyAnimationPresenterMock = IoAdaptersFactoryForCore.GetInstance().GetEnemyAnimationPresenterInstance();
            if (enemyAnimationPresenterMock is EnemyAnimationPresenterMock)
            {
                EnemyAnimationPresenterMock enemyAnimationPresenter = (EnemyAnimationPresenterMock)enemyAnimationPresenterMock;
                Assert.That(enemyAnimationPresenter.TimesPlayLeftStrikeAnimationWasCalled, Is.EqualTo(0));
                Assert.That(enemyAnimationPresenter.TimesPlayRightStrikeAnimationWasCalled, Is.EqualTo(0));

                enemyAnimationPresenter.Reset();
            }
        }         

        // player right and left border include
        // player top and bottom border include      

        private Enemy CreateEnemyForAiAttackTests()
        {
            Position enemyPosition = new Position(20, 20);  

            return new Enemy
                .Builder()
                .SetLife(10)
                .SetPosition(enemyPosition)
                .SetUnarmedStrikeRange(5)
                .SetIsAggressiveOnSight(true)
                .Build();
        } 

        private PlayerCharacter CreatePlayerCharacterForAiAttackTests()
        {
            BoundingBox playerBoundingBox = new BoundingBox
                .Builder()
                .SetDistanceToLeftEdge(4)
                .SetDistanceToRightEdge(5)
                .SetDistanceToTopEdge(4)
                .SetDistanceToBottomEdge(5)
                .Build();

            MeleeHitArcProperties meleeHitArcProperties = new MeleeHitArcProperties
            {
                HitArcStartAngle = 0.0f,
                HitArcEndAngle = 1.4f,
                HitArcRadius = 2,
                HitArcCenterXOffset = 0,
                HitArcCenterYOffset = 0
            };

            return new PlayerCharacter
                .PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(new PlayerCharacterBaseStats())
                .SetBoundingBox(playerBoundingBox)
                .SetMeleeHitArcProperties(meleeHitArcProperties)
                .Build();            
        }        
    }
}