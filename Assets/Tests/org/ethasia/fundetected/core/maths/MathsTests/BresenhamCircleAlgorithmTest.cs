using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Core.Maths.Tests
{
    public class BresenhamCircleAlgorithmTest
    {
        [Test]
        public void TestCircleArcWithRadiusTwoIsDrawnFromTopRightToBottomRight()
        {
            BresenhamCircleAlgorithm testCandidate = new BresenhamCircleAlgorithm();

            testCandidate.CreateFilledCircleArc(-1.5708, 0.383972, 2);

            List<HitboxTilePosition> result = testCandidate.HitboxTilePositions;
            
            Assert.That(result.Count, Is.EqualTo(6)); 

            Assert.That(result[1].X, Is.EqualTo(2)); 
            Assert.That(result[1].Y, Is.EqualTo(0));     

            Assert.That(result[2].X, Is.EqualTo(3)); 
            Assert.That(result[2].Y, Is.EqualTo(0)); 

            Assert.That(result[3].X, Is.EqualTo(4)); 
            Assert.That(result[3].Y, Is.EqualTo(1)); 

            Assert.That(result[4].X, Is.EqualTo(4)); 
            Assert.That(result[4].Y, Is.EqualTo(2)); 

            Assert.That(result[5].X, Is.EqualTo(4)); 
            Assert.That(result[5].Y, Is.EqualTo(3));                                                   
        }

        [Test]
        public void TestCircleArcWithRadiusTwoIsDrawnFromTopRightToBottomLeft()
        {
            BresenhamCircleAlgorithm testCandidate = new BresenhamCircleAlgorithm();

            testCandidate.CreateFilledCircleArc(-1.5708, 2.74017, 2);

            List<HitboxTilePosition> result = testCandidate.HitboxTilePositions;
            
            Assert.That(result.Count, Is.EqualTo(10)); 

            Assert.That(result[1].X, Is.EqualTo(2)); 
            Assert.That(result[1].Y, Is.EqualTo(0));     

            Assert.That(result[2].X, Is.EqualTo(3)); 
            Assert.That(result[2].Y, Is.EqualTo(0)); 

            Assert.That(result[3].X, Is.EqualTo(4)); 
            Assert.That(result[3].Y, Is.EqualTo(1)); 

            Assert.That(result[4].X, Is.EqualTo(4)); 
            Assert.That(result[4].Y, Is.EqualTo(2)); 

            Assert.That(result[5].X, Is.EqualTo(4)); 
            Assert.That(result[5].Y, Is.EqualTo(3));    

            Assert.That(result[6].X, Is.EqualTo(3)); 
            Assert.That(result[6].Y, Is.EqualTo(4));  

            Assert.That(result[7].X, Is.EqualTo(2)); 
            Assert.That(result[7].Y, Is.EqualTo(4));  

            Assert.That(result[8].X, Is.EqualTo(1)); 
            Assert.That(result[8].Y, Is.EqualTo(4));       

            Assert.That(result[9].X, Is.EqualTo(0)); 
            Assert.That(result[9].Y, Is.EqualTo(3));                                                                                            
        }      

        [Test]
        public void TestCircleArcWithRadiusTwoIsDrawnFromTopRightToTopLeft()
        {
            BresenhamCircleAlgorithm testCandidate = new BresenhamCircleAlgorithm();

            testCandidate.CreateFilledCircleArc(-1.5708, -2.74017, 2);

            List<HitboxTilePosition> result = testCandidate.HitboxTilePositions;
            
            Assert.That(result.Count, Is.EqualTo(12)); 

            Assert.That(result[1].X, Is.EqualTo(2)); 
            Assert.That(result[1].Y, Is.EqualTo(0));     

            Assert.That(result[2].X, Is.EqualTo(3)); 
            Assert.That(result[2].Y, Is.EqualTo(0)); 

            Assert.That(result[3].X, Is.EqualTo(4)); 
            Assert.That(result[3].Y, Is.EqualTo(1)); 

            Assert.That(result[4].X, Is.EqualTo(4)); 
            Assert.That(result[4].Y, Is.EqualTo(2)); 

            Assert.That(result[5].X, Is.EqualTo(4)); 
            Assert.That(result[5].Y, Is.EqualTo(3));    

            Assert.That(result[6].X, Is.EqualTo(3)); 
            Assert.That(result[6].Y, Is.EqualTo(4));  

            Assert.That(result[7].X, Is.EqualTo(2)); 
            Assert.That(result[7].Y, Is.EqualTo(4));  

            Assert.That(result[8].X, Is.EqualTo(1)); 
            Assert.That(result[8].Y, Is.EqualTo(4));       

            Assert.That(result[9].X, Is.EqualTo(0)); 
            Assert.That(result[9].Y, Is.EqualTo(3));     

            Assert.That(result[10].X, Is.EqualTo(0)); 
            Assert.That(result[10].Y, Is.EqualTo(2)); 

            Assert.That(result[11].X, Is.EqualTo(0)); 
            Assert.That(result[11].Y, Is.EqualTo(1));                                                                                                                
        }   

        [Test]
        public void TestCircleArcWithRadiusThreeIsDrawnFromBottomRightToBottomLeft()
        {
            BresenhamCircleAlgorithm testCandidate = new BresenhamCircleAlgorithm();

            testCandidate.CreateFilledCircleArc(0.785398, 2.74017, 3);

            List<HitboxTilePosition> result = testCandidate.HitboxTilePositions;
            
            Assert.That(result.Count, Is.EqualTo(7)); 

            Assert.That(result[1].X, Is.EqualTo(5)); 
            Assert.That(result[1].Y, Is.EqualTo(5));     

            Assert.That(result[2].X, Is.EqualTo(4)); 
            Assert.That(result[2].Y, Is.EqualTo(6)); 

            Assert.That(result[3].X, Is.EqualTo(3)); 
            Assert.That(result[3].Y, Is.EqualTo(6)); 

            Assert.That(result[4].X, Is.EqualTo(2)); 
            Assert.That(result[4].Y, Is.EqualTo(6)); 

            Assert.That(result[5].X, Is.EqualTo(1)); 
            Assert.That(result[5].Y, Is.EqualTo(5));    

            Assert.That(result[6].X, Is.EqualTo(0)); 
            Assert.That(result[6].Y, Is.EqualTo(4));                                                                                                              
        }                     
    }
}