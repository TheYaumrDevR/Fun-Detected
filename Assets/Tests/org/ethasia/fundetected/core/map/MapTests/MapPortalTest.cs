using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Core.Map.Tests
{
    public class MapPortalTest
    {
        [Test]
        public void TestGetCollisionBoundingBoxContextSubstractsOneFromLeftAndBottomBorderForEvenDimensions()
        {
            MapPortal testCandidate = new MapPortal.Builder()
                .SetPosition(new Position(-393, 94))
                .SetWidth(20)
                .SetHeight(20)
                .SetDestinationMapId("test")
                .SetDestinationPortalId("test")
                .Build();

            CollisionCalculations.CollisionBoundingBoxContext result = testCandidate.GetCollisionBoundingBoxContext();

            Assert.That(result.DistanceToLeftEdge, Is.EqualTo(9));
            Assert.That(result.DistanceToRightEdge, Is.EqualTo(10));
            Assert.That(result.DistanceToTopEdge, Is.EqualTo(10));
            Assert.That(result.DistanceToBottomEdge, Is.EqualTo(9));

            Assert.That(result.PositionX, Is.EqualTo(-393));
            Assert.That(result.PositionY, Is.EqualTo(94));
        }

        [Test]
        public void TestGetCollisionBoundingBoxContextDoesNotSubstractAnythingForUnevenDimensions()
        {
            MapPortal testCandidate = new MapPortal.Builder()
                .SetPosition(new Position(108, -51))
                .SetWidth(23)
                .SetHeight(23)
                .SetDestinationMapId("test")
                .SetDestinationPortalId("test")
                .Build();

            CollisionCalculations.CollisionBoundingBoxContext result = testCandidate.GetCollisionBoundingBoxContext();

            Assert.That(result.DistanceToLeftEdge, Is.EqualTo(11));
            Assert.That(result.DistanceToRightEdge, Is.EqualTo(11));
            Assert.That(result.DistanceToTopEdge, Is.EqualTo(11));
            Assert.That(result.DistanceToBottomEdge, Is.EqualTo(11));

            Assert.That(result.PositionX, Is.EqualTo(108));
            Assert.That(result.PositionY, Is.EqualTo(-51));
        }
    }
}