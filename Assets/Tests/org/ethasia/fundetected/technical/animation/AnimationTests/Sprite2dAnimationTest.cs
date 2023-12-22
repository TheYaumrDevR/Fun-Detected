using NUnit.Framework;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Technical.Animation.Mocks;

namespace Org.Ethasia.Fundetected.Technical.Animation.Tests
{
    public class Sprite2dAnimationTest
    {

        [Test]
        public void TestAnimationSwitchesFramesEverySecond()
        {
            TestableSprite2dAnimation.Builder builder = new TestableSprite2dAnimation.Builder();

            builder.AddEmptyAnimationFrame()
                .AddEmptyAnimationFrame()
                .AddEmptyAnimationFrame()
                .AddEmptyAnimationFrame()
                .SetIsLooping(true);

            TestableSprite2dAnimation testCandidate = builder.Build();

            testCandidate.Update(0.3f);
            testCandidate.Update(0.3f);
            testCandidate.Update(0.3f);
            testCandidate.Update(0.3f);
            testCandidate.Update(3.5f);

            List<int> result = testCandidate.SpriteFramesSet;

            Assert.That(result.Count, Is.EqualTo(4));    
            Assert.That(result[0], Is.EqualTo(1));
            Assert.That(result[1], Is.EqualTo(2));
            Assert.That(result[2], Is.EqualTo(3));
            Assert.That(result[3], Is.EqualTo(0));         
        }
    }
}