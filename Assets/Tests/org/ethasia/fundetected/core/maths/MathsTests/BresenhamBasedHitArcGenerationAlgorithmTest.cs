using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Core.Maths.Tests
{
    public class BresenhamBasedHitArcGenerationAlgorithmTest
    {
        [Test]
        public void TestCircleArcWithRadiusTwoIsDrawnFromTopRightToBottomRight()
        {
            BresenhamBasedHitArcGenerationAlgorithm testCandidate = new BresenhamBasedHitArcGenerationAlgorithm();

            testCandidate.CreateFilledCircleArc(-1.5708, 0.383972, 2);

            List<HitboxTilePosition> result = testCandidate.HitboxTilePositionsRight;

            Assert.That(result.Count, Is.EqualTo(10)); 

            Assert.That(result[1].X, Is.EqualTo(0)); 
            Assert.That(result[1].Y, Is.EqualTo(2));     

            Assert.That(result[2].X, Is.EqualTo(1)); 
            Assert.That(result[2].Y, Is.EqualTo(2)); 

            Assert.That(result[3].X, Is.EqualTo(2)); 
            Assert.That(result[3].Y, Is.EqualTo(1)); 

            Assert.That(result[4].X, Is.EqualTo(2)); 
            Assert.That(result[4].Y, Is.EqualTo(0)); 

            Assert.That(result[5].X, Is.EqualTo(2)); 
            Assert.That(result[5].Y, Is.EqualTo(-1));       

            Assert.That(result[6].X, Is.EqualTo(0)); 
            Assert.That(result[6].Y, Is.EqualTo(1));   

            Assert.That(result[7].X, Is.EqualTo(1)); 
            Assert.That(result[7].Y, Is.EqualTo(1));   

            Assert.That(result[8].X, Is.EqualTo(1)); 
            Assert.That(result[8].Y, Is.EqualTo(0));   

            Assert.That(result[9].X, Is.EqualTo(1)); 
            Assert.That(result[9].Y, Is.EqualTo(-1));                                                      
        }

        [Test]
        public void TestCircleArcWithRadiusTwoIsDrawnFromTopRightToBottomLeft()
        {
            BresenhamBasedHitArcGenerationAlgorithm testCandidate = new BresenhamBasedHitArcGenerationAlgorithm();

            testCandidate.CreateFilledCircleArc(-1.5708, 2.74017, 2);

            List<HitboxTilePosition> result = testCandidate.HitboxTilePositionsRight;

            Assert.That(result.Count, Is.EqualTo(16)); 

            Assert.That(result[1].X, Is.EqualTo(0)); 
            Assert.That(result[1].Y, Is.EqualTo(2));     

            Assert.That(result[2].X, Is.EqualTo(1)); 
            Assert.That(result[2].Y, Is.EqualTo(2)); 

            Assert.That(result[3].X, Is.EqualTo(2)); 
            Assert.That(result[3].Y, Is.EqualTo(1)); 

            Assert.That(result[4].X, Is.EqualTo(2)); 
            Assert.That(result[4].Y, Is.EqualTo(0)); 

            Assert.That(result[5].X, Is.EqualTo(2)); 
            Assert.That(result[5].Y, Is.EqualTo(-1));    

            Assert.That(result[6].X, Is.EqualTo(1)); 
            Assert.That(result[6].Y, Is.EqualTo(-2));  

            Assert.That(result[7].X, Is.EqualTo(0)); 
            Assert.That(result[7].Y, Is.EqualTo(-2));  

            Assert.That(result[8].X, Is.EqualTo(-1)); 
            Assert.That(result[8].Y, Is.EqualTo(-2));       

            Assert.That(result[9].X, Is.EqualTo(-2)); 
            Assert.That(result[9].Y, Is.EqualTo(-1));           

            Assert.That(result[10].X, Is.EqualTo(0)); 
            Assert.That(result[10].Y, Is.EqualTo(1));   

            Assert.That(result[11].X, Is.EqualTo(1)); 
            Assert.That(result[11].Y, Is.EqualTo(1));               

            Assert.That(result[12].X, Is.EqualTo(1)); 
            Assert.That(result[12].Y, Is.EqualTo(0));   

            Assert.That(result[13].X, Is.EqualTo(1)); 
            Assert.That(result[13].Y, Is.EqualTo(-1));   

            Assert.That(result[14].X, Is.EqualTo(0)); 
            Assert.That(result[14].Y, Is.EqualTo(-1));   

            Assert.That(result[15].X, Is.EqualTo(-1)); 
            Assert.That(result[15].Y, Is.EqualTo(-1));                                                                                    
        }      

        [Test]
        public void TestCircleArcWithRadiusTwoIsDrawnFromTopRightToTopLeft()
        {
            BresenhamBasedHitArcGenerationAlgorithm testCandidate = new BresenhamBasedHitArcGenerationAlgorithm();

            testCandidate.CreateFilledCircleArc(-1.5708, -2.74017, 2);

            List<HitboxTilePosition> result = testCandidate.HitboxTilePositionsRight;

            Assert.That(result.Count, Is.EqualTo(20)); 

            Assert.That(result[1].X, Is.EqualTo(0)); 
            Assert.That(result[1].Y, Is.EqualTo(2));     

            Assert.That(result[2].X, Is.EqualTo(1)); 
            Assert.That(result[2].Y, Is.EqualTo(2)); 

            Assert.That(result[3].X, Is.EqualTo(2)); 
            Assert.That(result[3].Y, Is.EqualTo(1)); 

            Assert.That(result[4].X, Is.EqualTo(2)); 
            Assert.That(result[4].Y, Is.EqualTo(0)); 

            Assert.That(result[5].X, Is.EqualTo(2)); 
            Assert.That(result[5].Y, Is.EqualTo(-1));    

            Assert.That(result[6].X, Is.EqualTo(1)); 
            Assert.That(result[6].Y, Is.EqualTo(-2));  

            Assert.That(result[7].X, Is.EqualTo(0)); 
            Assert.That(result[7].Y, Is.EqualTo(-2));  

            Assert.That(result[8].X, Is.EqualTo(-1)); 
            Assert.That(result[8].Y, Is.EqualTo(-2));       

            Assert.That(result[9].X, Is.EqualTo(-2)); 
            Assert.That(result[9].Y, Is.EqualTo(-1));     

            Assert.That(result[10].X, Is.EqualTo(-2)); 
            Assert.That(result[10].Y, Is.EqualTo(0)); 

            Assert.That(result[11].X, Is.EqualTo(-2)); 
            Assert.That(result[11].Y, Is.EqualTo(1));   

            Assert.That(result[12].X, Is.EqualTo(0)); 
            Assert.That(result[12].Y, Is.EqualTo(1));   

            Assert.That(result[13].X, Is.EqualTo(1)); 
            Assert.That(result[13].Y, Is.EqualTo(1));   

            Assert.That(result[14].X, Is.EqualTo(1)); 
            Assert.That(result[14].Y, Is.EqualTo(0));   

            Assert.That(result[15].X, Is.EqualTo(1)); 
            Assert.That(result[15].Y, Is.EqualTo(-1));        

            Assert.That(result[16].X, Is.EqualTo(0)); 
            Assert.That(result[16].Y, Is.EqualTo(-1));   

            Assert.That(result[17].X, Is.EqualTo(-1)); 
            Assert.That(result[17].Y, Is.EqualTo(-1));          

            Assert.That(result[18].X, Is.EqualTo(-1)); 
            Assert.That(result[18].Y, Is.EqualTo(0));  

            Assert.That(result[19].X, Is.EqualTo(-1)); 
            Assert.That(result[19].Y, Is.EqualTo(1));                                                                                                                                                              
        }   

        [Test]
        public void TestCircleArcWithRadiusThreeIsDrawnFromBottomRightToBottomLeft()
        {
            BresenhamBasedHitArcGenerationAlgorithm testCandidate = new BresenhamBasedHitArcGenerationAlgorithm();

            testCandidate.CreateFilledCircleArc(0.785398, 2.74017, 3);

            List<HitboxTilePosition> result = testCandidate.HitboxTilePositionsRight;

            Assert.That(result.Count, Is.EqualTo(15)); 

            Assert.That(result[1].X, Is.EqualTo(2)); 
            Assert.That(result[1].Y, Is.EqualTo(-2));     

            Assert.That(result[2].X, Is.EqualTo(1)); 
            Assert.That(result[2].Y, Is.EqualTo(-3)); 

            Assert.That(result[3].X, Is.EqualTo(0)); 
            Assert.That(result[3].Y, Is.EqualTo(-3)); 

            Assert.That(result[4].X, Is.EqualTo(-1)); 
            Assert.That(result[4].Y, Is.EqualTo(-3)); 

            Assert.That(result[5].X, Is.EqualTo(-2)); 
            Assert.That(result[5].Y, Is.EqualTo(-2));    

            Assert.That(result[6].X, Is.EqualTo(-3)); 
            Assert.That(result[6].Y, Is.EqualTo(-1));       

            Assert.That(result[7].X, Is.EqualTo(1)); 
            Assert.That(result[7].Y, Is.EqualTo(-1));  

            Assert.That(result[8].X, Is.EqualTo(0)); 
            Assert.That(result[8].Y, Is.EqualTo(-1));       

            Assert.That(result[9].X, Is.EqualTo(1)); 
            Assert.That(result[9].Y, Is.EqualTo(-2));     

            Assert.That(result[10].X, Is.EqualTo(0)); 
            Assert.That(result[10].Y, Is.EqualTo(-2)); 

            Assert.That(result[11].X, Is.EqualTo(-1)); 
            Assert.That(result[11].Y, Is.EqualTo(-2));   

            Assert.That(result[12].X, Is.EqualTo(-1)); 
            Assert.That(result[12].Y, Is.EqualTo(-1));   

            Assert.That(result[13].X, Is.EqualTo(-1)); 
            Assert.That(result[13].Y, Is.EqualTo(0));                                                                                                                                
        }  

        [Test]
        public void TestCircleArcWithRadiusFourIsDrawnFromBottomRightToBottomLeft()
        {
            BresenhamBasedHitArcGenerationAlgorithm testCandidate = new BresenhamBasedHitArcGenerationAlgorithm();

            testCandidate.CreateFilledCircleArc(1.22173, 2.79253, 4);

            List<HitboxTilePosition> result = testCandidate.HitboxTilePositionsRight;

            Assert.That(result.Count, Is.EqualTo(18)); 

            Assert.That(result[0].X, Is.EqualTo(0)); 
            Assert.That(result[0].Y, Is.EqualTo(0));  

            Assert.That(result[1].X, Is.EqualTo(1)); 
            Assert.That(result[1].Y, Is.EqualTo(-4));     

            Assert.That(result[2].X, Is.EqualTo(0)); 
            Assert.That(result[2].Y, Is.EqualTo(-4)); 

            Assert.That(result[3].X, Is.EqualTo(-1)); 
            Assert.That(result[3].Y, Is.EqualTo(-4)); 

            Assert.That(result[4].X, Is.EqualTo(-2)); 
            Assert.That(result[4].Y, Is.EqualTo(-3)); 

            Assert.That(result[5].X, Is.EqualTo(-3)); 
            Assert.That(result[5].Y, Is.EqualTo(-2));    

            Assert.That(result[6].X, Is.EqualTo(-4)); 
            Assert.That(result[6].Y, Is.EqualTo(-1));       

            Assert.That(result[7].X, Is.EqualTo(0)); 
            Assert.That(result[7].Y, Is.EqualTo(-1));  

            Assert.That(result[8].X, Is.EqualTo(1)); 
            Assert.That(result[8].Y, Is.EqualTo(-2));       

            Assert.That(result[9].X, Is.EqualTo(1)); 
            Assert.That(result[9].Y, Is.EqualTo(-3));     

            Assert.That(result[10].X, Is.EqualTo(0)); 
            Assert.That(result[10].Y, Is.EqualTo(-2)); 

            Assert.That(result[11].X, Is.EqualTo(0)); 
            Assert.That(result[11].Y, Is.EqualTo(-3));   

            Assert.That(result[12].X, Is.EqualTo(-1)); 
            Assert.That(result[12].Y, Is.EqualTo(-2));   

            Assert.That(result[13].X, Is.EqualTo(-1)); 
            Assert.That(result[13].Y, Is.EqualTo(-3));   

            Assert.That(result[14].X, Is.EqualTo(-1)); 
            Assert.That(result[14].Y, Is.EqualTo(-1));     

            Assert.That(result[15].X, Is.EqualTo(-2)); 
            Assert.That(result[15].Y, Is.EqualTo(-1));        

            Assert.That(result[16].X, Is.EqualTo(-1)); 
            Assert.That(result[16].Y, Is.EqualTo(0));   

            Assert.That(result[17].X, Is.EqualTo(-3)); 
            Assert.That(result[17].Y, Is.EqualTo(-1));                                                                                                                     
        }

        [Test]
        public void TestCircleArcWithRadiusTwoFromTopRightToTopLeftIsMirroredOnYProperly()
        {
            BresenhamBasedHitArcGenerationAlgorithm testCandidate = new BresenhamBasedHitArcGenerationAlgorithm();

            testCandidate.CreateFilledCircleArc(-1.5708, -2.74017, 2);

            List<HitboxTilePosition> result = testCandidate.HitboxTilePositionsLeft;

            Assert.That(result.Count, Is.EqualTo(20)); 

            Assert.That(result[1].X, Is.EqualTo(0)); 
            Assert.That(result[1].Y, Is.EqualTo(2));     

            Assert.That(result[2].X, Is.EqualTo(-1)); 
            Assert.That(result[2].Y, Is.EqualTo(2)); 

            Assert.That(result[3].X, Is.EqualTo(-2)); 
            Assert.That(result[3].Y, Is.EqualTo(1)); 

            Assert.That(result[4].X, Is.EqualTo(-2)); 
            Assert.That(result[4].Y, Is.EqualTo(0)); 

            Assert.That(result[5].X, Is.EqualTo(-2)); 
            Assert.That(result[5].Y, Is.EqualTo(-1));    

            Assert.That(result[6].X, Is.EqualTo(-1)); 
            Assert.That(result[6].Y, Is.EqualTo(-2));  

            Assert.That(result[7].X, Is.EqualTo(0)); 
            Assert.That(result[7].Y, Is.EqualTo(-2));  

            Assert.That(result[8].X, Is.EqualTo(1)); 
            Assert.That(result[8].Y, Is.EqualTo(-2));       

            Assert.That(result[9].X, Is.EqualTo(2)); 
            Assert.That(result[9].Y, Is.EqualTo(-1));     

            Assert.That(result[10].X, Is.EqualTo(2)); 
            Assert.That(result[10].Y, Is.EqualTo(0)); 

            Assert.That(result[11].X, Is.EqualTo(2)); 
            Assert.That(result[11].Y, Is.EqualTo(1));   

            Assert.That(result[12].X, Is.EqualTo(0)); 
            Assert.That(result[12].Y, Is.EqualTo(1));   

            Assert.That(result[13].X, Is.EqualTo(-1)); 
            Assert.That(result[13].Y, Is.EqualTo(1));   

            Assert.That(result[14].X, Is.EqualTo(-1)); 
            Assert.That(result[14].Y, Is.EqualTo(0));   

            Assert.That(result[15].X, Is.EqualTo(-1)); 
            Assert.That(result[15].Y, Is.EqualTo(-1));        

            Assert.That(result[16].X, Is.EqualTo(0)); 
            Assert.That(result[16].Y, Is.EqualTo(-1));   

            Assert.That(result[17].X, Is.EqualTo(1)); 
            Assert.That(result[17].Y, Is.EqualTo(-1));          

            Assert.That(result[18].X, Is.EqualTo(1)); 
            Assert.That(result[18].Y, Is.EqualTo(0));  

            Assert.That(result[19].X, Is.EqualTo(1)); 
            Assert.That(result[19].Y, Is.EqualTo(1));                                                                                                                                                              
        }    

        [Test]
        public void TestThatAlgorithmDoesNotCrashWhenAngleAndRadiusDataIsZero()
        {
            BresenhamBasedHitArcGenerationAlgorithm testCandidate = new BresenhamBasedHitArcGenerationAlgorithm();

            testCandidate.CreateFilledCircleArc(0.0, 0.0, 0);

            List<HitboxTilePosition> result = testCandidate.HitboxTilePositionsRight;

            Assert.That(result.Count, Is.EqualTo(0)); 
        }                                 
    }   
}