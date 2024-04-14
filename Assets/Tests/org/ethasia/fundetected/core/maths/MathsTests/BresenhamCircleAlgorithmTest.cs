using NUnit.Framework;

namespace Org.Ethasia.Fundetected.Core.Maths.Tests
{
    public class BresenhamCircleAlgorithmTest
    {
        [Test]
        public void TestCircleWithRadiusTwoIsDrawnCorrectly()
        {
            BresenhamCircleAlgorithm testCandidate = new BresenhamCircleAlgorithm();
            testCandidate.SetCirclePoints(2);

            bool[,] result = testCandidate.SetPixels;

            Assert.That(result[0, 0], Is.False); 
            Assert.That(result[0, 1], Is.True); 
            Assert.That(result[0, 2], Is.True); 
            Assert.That(result[0, 3], Is.True); 
            Assert.That(result[0, 4], Is.False);
            Assert.That(result[1, 4], Is.True);
            Assert.That(result[2, 4], Is.True);
            Assert.That(result[3, 4], Is.True);
            Assert.That(result[4, 4], Is.False);
            Assert.That(result[4, 3], Is.True);
            Assert.That(result[4, 2], Is.True);
            Assert.That(result[4, 1], Is.True);
            Assert.That(result[4, 0], Is.False);
            Assert.That(result[3, 0], Is.True);  
            Assert.That(result[2, 0], Is.True);
            Assert.That(result[1, 0], Is.True);
            Assert.That(result[1, 1], Is.False);     
            Assert.That(result[2, 2], Is.True); 
            Assert.That(result[3, 3], Is.False);                   
        }

        [Test]
        public void TestCircleWithRadiusThreeIsDrawnCorrectly()
        {
            BresenhamCircleAlgorithm testCandidate = new BresenhamCircleAlgorithm();
            testCandidate.SetCirclePoints(3);

            bool[,] result = testCandidate.SetPixels;

            Assert.That(result[0, 0], Is.False);      
            Assert.That(result[0, 1], Is.False); 
            Assert.That(result[0, 2], Is.True);  
            Assert.That(result[0, 3], Is.True);  
            Assert.That(result[0, 4], Is.True);   
            Assert.That(result[0, 5], Is.False);   
            Assert.That(result[0, 6], Is.False);  
            Assert.That(result[1, 6], Is.False);       
            Assert.That(result[2, 6], Is.True);
            Assert.That(result[3, 6], Is.True);
            Assert.That(result[4, 6], Is.True);     
            Assert.That(result[5, 6], Is.False);  
            Assert.That(result[6, 6], Is.False);
            Assert.That(result[6, 5], Is.False); 
            Assert.That(result[6, 4], Is.True);   
            Assert.That(result[6, 3], Is.True);  
            Assert.That(result[6, 2], Is.True);  
            Assert.That(result[6, 1], Is.False); 
            Assert.That(result[6, 0], Is.False); 
            Assert.That(result[5, 0], Is.False); 
            Assert.That(result[4, 0], Is.True); 
            Assert.That(result[3, 0], Is.True); 
            Assert.That(result[2, 0], Is.True); 
            Assert.That(result[1, 0], Is.False); 
            Assert.That(result[1, 1], Is.True); 
            Assert.That(result[1, 5], Is.True); 
            Assert.That(result[5, 5], Is.True); 
            Assert.That(result[5, 1], Is.True); 
            Assert.That(result[3, 3], Is.True);
            Assert.That(result[1, 2], Is.False);
            Assert.That(result[2, 2], Is.False);
            Assert.That(result[3, 2], Is.False);
            Assert.That(result[4, 2], Is.False);
            Assert.That(result[5, 2], Is.False);
            Assert.That(result[1, 4], Is.False);
            Assert.That(result[2, 4], Is.False);
            Assert.That(result[3, 4], Is.False);
            Assert.That(result[4, 4], Is.False);
            Assert.That(result[5, 4], Is.False);
        }        
    }
}