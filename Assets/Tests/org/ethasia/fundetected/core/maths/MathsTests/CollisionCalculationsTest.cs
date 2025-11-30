using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Core.Maths.Tests
{
    public class CollisionCalculationsTest
    {
        [Test]
        public void TestAreBoundingBoxesOverlappingRightBorderInTopBorderIn()
        {
            CollisionCalculations.CollisionBoundingBoxContext firstObject = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(91)
                .SetPositionY(-30)
                .SetDistanceToLeftEdge(6)
                .SetDistanceToRightEdge(6)
                .SetDistanceToTopEdge(6)
                .SetDistanceToBottomEdge(6)
                .Build();

            CollisionCalculations.CollisionBoundingBoxContext secondObject = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(100)
                .SetPositionY(-22)
                .SetDistanceToLeftEdge(6)
                .SetDistanceToRightEdge(6)
                .SetDistanceToTopEdge(3)
                .SetDistanceToBottomEdge(3)
                .Build();

            bool result = CollisionCalculations.AreBoundingBoxesOverlapping(firstObject, secondObject);

            Assert.That(result, Is.True);
        }

        [Test]
        public void TestAreBoundingBoxesOverlappingRightBorderInBottomBorderIn()
        {
            CollisionCalculations.CollisionBoundingBoxContext firstObject = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(91)
                .SetPositionY(-24)
                .SetDistanceToLeftEdge(4)
                .SetDistanceToRightEdge(4)
                .SetDistanceToTopEdge(4)
                .SetDistanceToBottomEdge(4)
                .Build();

            CollisionCalculations.CollisionBoundingBoxContext secondObject = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(100)
                .SetPositionY(-31)
                .SetDistanceToLeftEdge(7)
                .SetDistanceToRightEdge(7)
                .SetDistanceToTopEdge(4)
                .SetDistanceToBottomEdge(4)
                .Build();

            bool result = CollisionCalculations.AreBoundingBoxesOverlapping(firstObject, secondObject);

            Assert.That(result, Is.True);
        }      

        [Test]
        public void TestAreBoundingBoxesOverlappingLeftBorderInTopBorderIn()
        {
            CollisionCalculations.CollisionBoundingBoxContext firstObject = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(91)
                .SetPositionY(-30)
                .SetDistanceToLeftEdge(6)
                .SetDistanceToRightEdge(6)
                .SetDistanceToTopEdge(6)
                .SetDistanceToBottomEdge(6)
                .Build();

            CollisionCalculations.CollisionBoundingBoxContext secondObject = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(100)
                .SetPositionY(-22)
                .SetDistanceToLeftEdge(6)
                .SetDistanceToRightEdge(6)
                .SetDistanceToTopEdge(3)
                .SetDistanceToBottomEdge(3)
                .Build();

            bool result = CollisionCalculations.AreBoundingBoxesOverlapping(secondObject, firstObject);

            Assert.That(result, Is.True);
        }           

        [Test]
        public void TestAreBoundingBoxesOverlappingLeftBorderInBottomBorderIn()
        {
            CollisionCalculations.CollisionBoundingBoxContext firstObject = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(91)
                .SetPositionY(-24)
                .SetDistanceToLeftEdge(4)
                .SetDistanceToRightEdge(4)
                .SetDistanceToTopEdge(4)
                .SetDistanceToBottomEdge(4)
                .Build();

            CollisionCalculations.CollisionBoundingBoxContext secondObject = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(100)
                .SetPositionY(-31)
                .SetDistanceToLeftEdge(7)
                .SetDistanceToRightEdge(7)
                .SetDistanceToTopEdge(4)
                .SetDistanceToBottomEdge(4)
                .Build();

            bool result = CollisionCalculations.AreBoundingBoxesOverlapping(secondObject, firstObject);

            Assert.That(result, Is.True);
        }   

        [Test]
        public void TestAreBoundingBoxesOverlappingRightBorderInTopAndBottomBordersIncluding()
        {
            CollisionCalculations.CollisionBoundingBoxContext firstObject = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(-499)
                .SetPositionY(266)
                .SetDistanceToLeftEdge(5)
                .SetDistanceToRightEdge(5)
                .SetDistanceToTopEdge(8)
                .SetDistanceToBottomEdge(8)                
                .Build();

            CollisionCalculations.CollisionBoundingBoxContext secondObject = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(-490)
                .SetPositionY(260)
                .SetDistanceToLeftEdge(5)
                .SetDistanceToRightEdge(5)
                .SetDistanceToTopEdge(1)
                .SetDistanceToBottomEdge(1)                   
                .Build();

            bool result = CollisionCalculations.AreBoundingBoxesOverlapping(firstObject, secondObject);

            Assert.That(result, Is.True);                
        }    

        [Test]
        public void TestAreBoundingBoxesOverlappingLeftBorderInTopAndBottomBordersIncluding()
        {
            CollisionCalculations.CollisionBoundingBoxContext firstObject = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(575)
                .SetPositionY(-651)
                .SetDistanceToLeftEdge(10)
                .SetDistanceToRightEdge(10)
                .SetDistanceToTopEdge(5)
                .SetDistanceToBottomEdge(3)                
                .Build();

            CollisionCalculations.CollisionBoundingBoxContext secondObject = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(560)
                .SetPositionY(-650)
                .SetDistanceToLeftEdge(7)
                .SetDistanceToRightEdge(7)
                .SetDistanceToTopEdge(2)
                .SetDistanceToBottomEdge(2)                   
                .Build();

            bool result = CollisionCalculations.AreBoundingBoxesOverlapping(firstObject, secondObject);

            Assert.That(result, Is.True);  
        }       

        [Test]
        public void TestAreBoundingBoxesOverlappingRightAndLeftBordersIncludingBottomBorderIn()
        {
            CollisionCalculations.CollisionBoundingBoxContext firstObject = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(-674)
                .SetPositionY(-459)
                .SetDistanceToLeftEdge(12)
                .SetDistanceToRightEdge(2)
                .SetDistanceToTopEdge(5)
                .SetDistanceToBottomEdge(5)                
                .Build();

            CollisionCalculations.CollisionBoundingBoxContext secondObject = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(-680)
                .SetPositionY(-470)
                .SetDistanceToLeftEdge(4)
                .SetDistanceToRightEdge(4)
                .SetDistanceToTopEdge(7)
                .SetDistanceToBottomEdge(3)                   
                .Build();

            bool result = CollisionCalculations.AreBoundingBoxesOverlapping(firstObject, secondObject);

            Assert.That(result, Is.True);                  
        }            

        [Test]
        public void TestAreBoundingBoxesOverlappingRightAndLeftBordersIncludingTopBorderIn()
        {
            CollisionCalculations.CollisionBoundingBoxContext firstObject = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(-674)
                .SetPositionY(-459)
                .SetDistanceToLeftEdge(12)
                .SetDistanceToRightEdge(2)
                .SetDistanceToTopEdge(5)
                .SetDistanceToBottomEdge(5)                
                .Build();

            CollisionCalculations.CollisionBoundingBoxContext secondObject = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(-680)
                .SetPositionY(-470)
                .SetDistanceToLeftEdge(4)
                .SetDistanceToRightEdge(4)
                .SetDistanceToTopEdge(7)
                .SetDistanceToBottomEdge(3)                   
                .Build();

            bool result = CollisionCalculations.AreBoundingBoxesOverlapping(secondObject, firstObject);

            Assert.That(result, Is.True); 
        }  

        [Test]
        public void TestAreBoundingBoxesOverlappingAllBordersInside()
        {
            CollisionCalculations.CollisionBoundingBoxContext firstObject = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(329)
                .SetPositionY(-281)
                .SetDistanceToLeftEdge(1)
                .SetDistanceToRightEdge(1)
                .SetDistanceToTopEdge(1)
                .SetDistanceToBottomEdge(1)                
                .Build();

            CollisionCalculations.CollisionBoundingBoxContext secondObject = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(320)
                .SetPositionY(-280)
                .SetDistanceToLeftEdge(1)
                .SetDistanceToRightEdge(12)
                .SetDistanceToTopEdge(1)
                .SetDistanceToBottomEdge(5)                   
                .Build();

            bool result = CollisionCalculations.AreBoundingBoxesOverlapping(firstObject, secondObject);

            Assert.That(result, Is.True);                 
        }  

        [Test]
        public void TestAreBoundingBoxesOverlappingAllBordersIncluding()
        {
            CollisionCalculations.CollisionBoundingBoxContext firstObject = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(329)
                .SetPositionY(-281)
                .SetDistanceToLeftEdge(1)
                .SetDistanceToRightEdge(1)
                .SetDistanceToTopEdge(1)
                .SetDistanceToBottomEdge(1)                
                .Build();

            CollisionCalculations.CollisionBoundingBoxContext secondObject = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(320)
                .SetPositionY(-280)
                .SetDistanceToLeftEdge(1)
                .SetDistanceToRightEdge(12)
                .SetDistanceToTopEdge(1)
                .SetDistanceToBottomEdge(5)                   
                .Build();

            bool result = CollisionCalculations.AreBoundingBoxesOverlapping(secondObject, firstObject);

            Assert.That(result, Is.True);  
        } 

        [Test]
        public void TestAreBoundingBoxesOverlappingAllBordersOutside()
        {
            CollisionCalculations.CollisionBoundingBoxContext firstObject = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(75)
                .SetPositionY(-354)
                .SetDistanceToLeftEdge(2)
                .SetDistanceToRightEdge(2)
                .SetDistanceToTopEdge(2)
                .SetDistanceToBottomEdge(2)                
                .Build();

            CollisionCalculations.CollisionBoundingBoxContext secondObject = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(70)
                .SetPositionY(-350)
                .SetDistanceToLeftEdge(2)
                .SetDistanceToRightEdge(2)
                .SetDistanceToTopEdge(4)
                .SetDistanceToBottomEdge(1)                   
                .Build();

            bool result = CollisionCalculations.AreBoundingBoxesOverlapping(secondObject, firstObject);

            Assert.That(result, Is.False);                  
        }    

        [Test]
        public void TestIsMousePointerInsideBoundingBox()
        {
            CollisionCalculations.CollisionBoundingBoxContext collisionShape = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(15)
                .SetPositionY(25)
                .SetDistanceToLeftEdge(4)
                .SetDistanceToRightEdge(4)
                .SetDistanceToTopEdge(4)
                .SetDistanceToBottomEdge(4)                
                .Build();

            bool result = CollisionCalculations.IsMousePointerInsideBoundingBox(17, 23, collisionShape);

            Assert.That(result, Is.True); 
        }   

        [Test]
        public void TestIsMousePointerInsideBoundingBoxPointerIsLeftOfBoundingBox()
        {
            CollisionCalculations.CollisionBoundingBoxContext collisionShape = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(15)
                .SetPositionY(25)
                .SetDistanceToLeftEdge(4)
                .SetDistanceToRightEdge(4)
                .SetDistanceToTopEdge(4)
                .SetDistanceToBottomEdge(4)                
                .Build();

            bool result = CollisionCalculations.IsMousePointerInsideBoundingBox(10, 23, collisionShape);

            Assert.That(result, Is.False); 
        }              

        [Test]
        public void TestIsMousePointerInsideBoundingBoxPointerIsRightOfBoundingBox()
        {
            CollisionCalculations.CollisionBoundingBoxContext collisionShape = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(15)
                .SetPositionY(25)
                .SetDistanceToLeftEdge(4)
                .SetDistanceToRightEdge(4)
                .SetDistanceToTopEdge(4)
                .SetDistanceToBottomEdge(4)                
                .Build();

            bool result = CollisionCalculations.IsMousePointerInsideBoundingBox(20, 23, collisionShape);

            Assert.That(result, Is.False); 
        }  

        [Test]
        public void TestIsMousePointerInsideBoundingBoxPointerIsAboveBoundingBox()
        {
            CollisionCalculations.CollisionBoundingBoxContext collisionShape = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(15)
                .SetPositionY(25)
                .SetDistanceToLeftEdge(4)
                .SetDistanceToRightEdge(4)
                .SetDistanceToTopEdge(4)
                .SetDistanceToBottomEdge(4)                
                .Build();

            bool result = CollisionCalculations.IsMousePointerInsideBoundingBox(17, 30, collisionShape);

            Assert.That(result, Is.False); 
        }  

        [Test]
        public void TestIsMousePointerInsideBoundingBoxPointerIsBelowBoundingBox()
        {
            CollisionCalculations.CollisionBoundingBoxContext collisionShape = new CollisionCalculations.CollisionBoundingBoxContext.Builder()
                .SetPositionX(15)
                .SetPositionY(25)
                .SetDistanceToLeftEdge(4)
                .SetDistanceToRightEdge(4)
                .SetDistanceToTopEdge(4)
                .SetDistanceToBottomEdge(4)                
                .Build();

            bool result = CollisionCalculations.IsMousePointerInsideBoundingBox(17, 20, collisionShape);

            Assert.That(result, Is.False); 
        }                               
    }
}