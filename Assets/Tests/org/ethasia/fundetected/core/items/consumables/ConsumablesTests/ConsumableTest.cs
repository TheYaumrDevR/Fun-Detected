using NUnit.Framework;

using Org.Ethasia.Fundetected.Core.Items.Consumables.Glyphs;

namespace Org.Ethasia.Fundetected.Core.Items.Consumables.Tests
{
    public class ConsumableTest
    {
        [Test]
        public void TestConsumeRemovesOneStack()
        {
            GlyphOfVitality.Builder builder = new GlyphOfVitality.Builder();
            builder.SetStackSize(5);

            GlyphOfVitality testCandidate = builder.Build();

            testCandidate.Consume();

            Assert.That(testCandidate.StackSize, Is.EqualTo(4));
        }

        [Test]
        public void TestConsumeCannotConsumesWhenStackSizeIsZero()
        {
            GlyphOfVitality.Builder builder = new GlyphOfVitality.Builder();
            builder.SetStackSize(0);

            GlyphOfVitality testCandidate = builder.Build();

            testCandidate.Consume();

            Assert.That(testCandidate.StackSize, Is.EqualTo(0));
        }

        [Test]
        public void TestAddToStackAddsFittingStackSize()
        {
            GlyphOfVitality.Builder builder = new GlyphOfVitality.Builder();
            builder.SetStackSize(5);     

            GlyphOfVitality testCandidate = builder.Build();

            builder.SetStackSize(3);
            GlyphOfVitality otherStack = builder.Build();

            Consumable restStack = testCandidate.AddToStack(otherStack);

            Assert.That(testCandidate.StackSize, Is.EqualTo(8));
            Assert.That(restStack, Is.Null);
        }

        [Test]
        public void TestAddToStackDoesNotAddZeroStackSize()
        {
            GlyphOfVitality.Builder builder = new GlyphOfVitality.Builder();
            builder.SetStackSize(4);

            GlyphOfVitality testCandidate = builder.Build();

            builder.SetStackSize(0);
            GlyphOfVitality otherStack = builder.Build();            

            Consumable restStack = testCandidate.AddToStack(otherStack);

            Assert.That(testCandidate.StackSize, Is.EqualTo(4));  
            Assert.That(restStack, Is.Null);          
        }

        [Test]
        public void TestAddToStackDoesNotAddNegativeStackSize()
        {
            GlyphOfVitality.Builder builder = new GlyphOfVitality.Builder();
            builder.SetStackSize(3);

            GlyphOfVitality testCandidate = builder.Build();

            builder.SetStackSize(-1);
            GlyphOfVitality otherStack = builder.Build();                

            Consumable restStack = testCandidate.AddToStack(otherStack);

            Assert.That(testCandidate.StackSize, Is.EqualTo(3));  
            Assert.That(restStack, Is.Null);            
        }        

        [Test]
        public void TestAddToStackAddsTooBigStackSizeAndCreatesNewStack()
        {
            GlyphOfVitality.Builder builder = new GlyphOfVitality.Builder();
            builder.SetStackSize(7);

            GlyphOfVitality testCandidate = builder.Build();

            builder.SetStackSize(7);
            GlyphOfVitality otherStack = builder.Build();               

            Consumable restStack = testCandidate.AddToStack(otherStack);

            Assert.That(testCandidate.StackSize, Is.EqualTo(10));
            Assert.That(restStack.StackSize, Is.EqualTo(4));
        }    

        [Test]
        public void TestSplitStackSplitsWhenEnoughIsLeft()
        {
            GlyphOfVitality.Builder builder = new GlyphOfVitality.Builder();
            builder.SetStackSize(6);

            GlyphOfVitality testCandidate = builder.Build();

            Consumable newStack = testCandidate.SplitStack(3);

            Assert.That(testCandidate.StackSize, Is.EqualTo(3));
            Assert.That(newStack.StackSize, Is.EqualTo(3));
        }     

        [Test]
        public void TestSplitStackDoesNotSplitWhenNotEnoughIsLeft()
        {
            GlyphOfVitality.Builder builder = new GlyphOfVitality.Builder();
            builder.SetStackSize(8);

            GlyphOfVitality testCandidate = builder.Build();

            Consumable newStack = testCandidate.SplitStack(9);

            Assert.That(testCandidate.StackSize, Is.EqualTo(8));
            Assert.That(newStack, Is.Null);
        }

        [Test]
        public void TestSplitStackDoesNotSplitWhenZeroIsSplit()
        {
            GlyphOfVitality.Builder builder = new GlyphOfVitality.Builder();
            builder.SetStackSize(9);

            GlyphOfVitality testCandidate = builder.Build();

            Consumable newStack = testCandidate.SplitStack(0);

            Assert.That(testCandidate.StackSize, Is.EqualTo(9));
            Assert.That(newStack, Is.Null);
        }

        [Test]
        public void TestSplitStackDoesNotSplitWhenNegativeIsSplit()
        {
            GlyphOfVitality.Builder builder = new GlyphOfVitality.Builder();
            builder.SetStackSize(2);

            GlyphOfVitality testCandidate = builder.Build();

            Consumable newStack = testCandidate.SplitStack(-1);

            Assert.That(testCandidate.StackSize, Is.EqualTo(2));
            Assert.That(newStack, Is.Null);
        }        
    }
}