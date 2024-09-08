using NUnit.Framework;

namespace Org.Ethasia.Fundetected.Core.Map.Tests
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

            Position playerPosition = new Position(11, 20);

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

            Position playerPosition = new Position(42, 17);

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

            Position playerPosition = new Position(19, 25);

            int result = testCandidate.CalculateUnitsPlayerCanMoveInHorizontalDirection(6, playerPosition);

            Assert.That(result, Is.EqualTo(5)); 
        }       

        [Test]
        public void TestMoveLeftCalculateUnitsPlayerCanMoveInHorizontalDirectionCollidesWithLeftBorder()
        {
            MoveLeftStrategy testCandidate = new MoveLeftStrategy();
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(30, 50)
                .Build();

            Area.ActiveArea = testArea;

            Position playerPosition = new Position(6, 25);

            int result = testCandidate.CalculateUnitsPlayerCanMoveInHorizontalDirection(2, playerPosition);

            Assert.That(result, Is.EqualTo(2)); 
        }           
    }
}