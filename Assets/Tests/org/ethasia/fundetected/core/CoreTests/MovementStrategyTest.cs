using NUnit.Framework;

using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected.Core.Tests
{
    public class MovementStrategyTest
    {
        [Test]
        public void TestMoveRightCalculateUnitsPlayerCanMoveInHorizontalDirectionCollidesWithCollisionTypeInTheMiddle()
        {
            MoveRightStrategy testCandidate = new MoveRightStrategy();
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetIsColliding(20, 25)
                .Build();

            Area.ActiveArea = testArea;

            Position playerPosition = new Position();
            playerPosition.X = 11;
            playerPosition.Y = 20;

            int result = testCandidate.CalculateUnitsPlayerCanMoveInHorizontalDirection(7, playerPosition);

            Assert.That(result, Is.EqualTo(3)); 
        }

        [Test]
        public void TestMoveRightCalculateUnitsPlayerCanMoveInHorizontalDirectionCollidesWithRightBorder()
        {
            MoveRightStrategy testCandidate = new MoveRightStrategy();
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .Build();

            Area.ActiveArea = testArea;

            Position playerPosition = new Position();
            playerPosition.X = 42;
            playerPosition.Y = 17;

            int result = testCandidate.CalculateUnitsPlayerCanMoveInHorizontalDirection(4, playerPosition);

            Assert.That(result, Is.EqualTo(2)); 
        }        

        [Test]
        public void TestMoveLeftCalculateUnitsPlayerCanMoveInHorizontalDirectionCollidesWithCollisionTypeInTheMiddle()
        {
            MoveLeftStrategy testCandidate = new MoveLeftStrategy();
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetIsColliding(9, 34)
                .Build();

            Area.ActiveArea = testArea;

            Position playerPosition = new Position();
            playerPosition.X = 19;
            playerPosition.Y = 25;

            int result = testCandidate.CalculateUnitsPlayerCanMoveInHorizontalDirection(6, playerPosition);

            Assert.That(result, Is.EqualTo(4)); 
        }       

        [Test]
        public void TestMoveLeftCalculateUnitsPlayerCanMoveInHorizontalDirectionCollidesWithLeftBorder()
        {
            MoveLeftStrategy testCandidate = new MoveLeftStrategy();
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(30, 50)
                .Build();

            Area.ActiveArea = testArea;

            Position playerPosition = new Position();
            playerPosition.X = 6;
            playerPosition.Y = 25;

            int result = testCandidate.CalculateUnitsPlayerCanMoveInHorizontalDirection(2, playerPosition);

            Assert.That(result, Is.EqualTo(1)); 
        }           
    }
}