using NUnit.Framework;

using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Items;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors.Tests
{
    public class EnvironmentInteractionInteractorTest
    {
        [Test]
        public void TestInteractWithEnvironmentPicksUpItemIfMousePointerInsideBoundingBoxAndPlayerIsNextToIt()
        {
            SetupTestAreaWithPlayerAndItem(15, 20);
            PutItemOnMap();
            EnvironmentInteractionInteractor testCandidate = new EnvironmentInteractionInteractor();

            bool itemWasPickedUp = testCandidate.InteractWithEnvironment(16, 14);

            Assert.IsTrue(itemWasPickedUp);
        }

        [Test]
        public void TestInteractWithEnvironmentDoesNotPickUpItemIfPlayerIsTooFarAway()
        {
            SetupTestAreaWithPlayerAndItem(4, 31);
            PutItemOnMap();
            EnvironmentInteractionInteractor testCandidate = new EnvironmentInteractionInteractor();

            bool itemWasPickedUp = testCandidate.InteractWithEnvironment(16, 14);

            Assert.IsFalse(itemWasPickedUp);
        }

        [Test]
        public void TestInteractWithEnvironmentDoesNotPickUpItemIfMousePointerIsNotHoveringIt()
        {
            SetupTestAreaWithPlayerAndItem(15, 20);
            PutItemOnMap();
            EnvironmentInteractionInteractor testCandidate = new EnvironmentInteractionInteractor();

            bool itemWasPickedUp = testCandidate.InteractWithEnvironment(16, 13);

            Assert.IsFalse(itemWasPickedUp);
        }

        private void SetupTestAreaWithPlayerAndItem(int playerX, int playerY)
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetPlayerSpawnPosition(new Position(playerX, playerY))
                .Build();

            Area.ActiveArea = testArea;        

            PlayerCharacterBaseStats baseStats = new PlayerCharacterBaseStats.PlayerCharacterBaseStatsBuilder()
                .Build();    

            BoundingBox playerBoundingBox = new BoundingBox
                .Builder()
                .SetDistanceToLeftEdge(1)
                .SetDistanceToRightEdge(2)
                .SetDistanceToTopEdge(9)
                .SetDistanceToBottomEdge(10)
                .Build();

            PlayerCharacter playerCharacter = new PlayerCharacter.PlayerCharacterBuilder()
                .SetPlayerCharacterBaseStats(baseStats)
                .SetBoundingBox(playerBoundingBox)
                .Build();

            testArea.SpawnPlayer(playerCharacter);
        }

        private void PutItemOnMap()
        {
            Jewelry.Builder jewelryBuilder = new Jewelry.Builder();

            jewelryBuilder.SetName("Steel Ring")
                .SetItemClass(ItemClass.RING);

            jewelryBuilder.SetCollisionShapeDistanceToLeftEdgeFromCenter(0);
            jewelryBuilder.SetCollisionShapeDistanceToRightEdgeFromCenter(1);
            jewelryBuilder.SetCollisionShapeDistanceToTopEdgeFromCenter(1);
            jewelryBuilder.SetCollisionShapeDistanceToBottomEdgeFromCenter(0);

            Jewelry steelRing = jewelryBuilder.Build();

            steelRing.CollisionShape.Position.SetFromOtherPosition(new Position(16, 14));

            Area.ActiveArea.AddItem(steelRing);
        }
    }
}