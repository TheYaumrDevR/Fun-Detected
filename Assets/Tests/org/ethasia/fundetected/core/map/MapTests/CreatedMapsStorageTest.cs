using NUnit.Framework;

namespace Org.Ethasia.Fundetected.Core.Map.Tests
{
    public class CreatedMapsStorageTest
    {
        [SetUp]
        public void ResetTestState()
        {
            CreatedMapsStorage.GetInstance().ClearAllMaps();
        }

        [Test]
        public void TestAddMapByIdWithThreeDifferentIdsAreAllAdded()
        {
            CreatedMapsStorage testCandidate = CreatedMapsStorage.GetInstance();

            Area firstMap = new Area.Builder()
                .SetWidthAndHeight(10, 10)
                .Build();

            Area secondMap = new Area.Builder()
                .SetWidthAndHeight(11, 11)
                .Build();

            Area thirdMap = new Area.Builder()
                .SetWidthAndHeight(12, 12)
                .Build();

            Area fourthMap = new Area.Builder()
                .SetWidthAndHeight(13, 13)
                .Build();

            Area fifthMap = new Area.Builder()
                .SetWidthAndHeight(14, 14)
                .Build();

            Area sixthMap = new Area.Builder()
                .SetWidthAndHeight(15, 15)
                .Build();                                                

            testCandidate.AddMapById("Hill", firstMap);
            testCandidate.AddMapById("Hill", fourthMap);
            testCandidate.AddMapById("Town", secondMap);
            testCandidate.AddMapById("Forest", thirdMap);
            testCandidate.AddMapById("Forest", fifthMap);
            testCandidate.AddMapById("Forest", sixthMap);

            Assert.That(testCandidate.GetStoredMapsById("Hill").Count, Is.EqualTo(2));
            Assert.That(testCandidate.GetStoredMapsById("Town").Count, Is.EqualTo(1));
            Assert.That(testCandidate.GetStoredMapsById("Forest").Count, Is.EqualTo(3));
        }
    }
}