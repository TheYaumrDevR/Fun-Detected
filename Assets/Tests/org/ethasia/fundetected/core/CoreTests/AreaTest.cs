using NUnit.Framework;

using Org.Ethasia.Fundetected.Ioadapters.Mocks;
using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected.Core.Tests
{
    public class AreaTest
    {
        [OneTimeSetUp] 
        public void Init()
        {
            IoAdaptersFactoryForCore.SetInstance(new MockedIoAdaptersFactoryForCore());
        }

        [Test]
        public void TestCalculateFallDepthFallsDownInAir()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(30, 50)
                .SetIsColliding(9, 4)
                .Build();

            Area.ActiveArea = testArea;

            PlayerCharacter playerCharacter = new PlayerCharacter.PlayerCharacterBuilder()
                .Build();  

            testArea.AddPlayerAt(playerCharacter, 11, 30);

            int result = testArea.CalculateFallDepth();
            Assert.That(result, Is.EqualTo(10)); 
        }

        [Test]
        public void TestCalculateFallDepthFallsDownToZero()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(30, 50)
                .SetIsColliding(3, 10)
                .Build();

            Area.ActiveArea = testArea;

            PlayerCharacter playerCharacter = new PlayerCharacter.PlayerCharacterBuilder()
                .Build();  

            testArea.AddPlayerAt(playerCharacter, 8, 30);

            int result = testArea.CalculateFallDepth();
            Assert.That(result, Is.EqualTo(14)); 
        }

        [Test]
        public void TestCalculateFallDepthDoesNotFallWhileOnGround()
        {
            Area testArea = new Area.Builder()
                .SetWidthAndHeight(50, 50)
                .SetIsColliding(37, 24)
                .Build();

            Area.ActiveArea = testArea;

            PlayerCharacter playerCharacter = new PlayerCharacter.PlayerCharacterBuilder()
                .Build();  

            testArea.AddPlayerAt(playerCharacter, 41, 40);

            int result = testArea.CalculateFallDepth();
            Assert.That(result, Is.EqualTo(0)); 
        }
    }
}