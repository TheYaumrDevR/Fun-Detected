using NUnit.Framework;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical.Tests
{
    public class GuiContentFactoryTest
    {
        [Test]
        public void TestCreateMapSelectionRows_PopulatesAndReversesItems()
        {
            // Arrange
            MapSelectionWindowContext windowContent = new MapSelectionWindowContext("TestMap", new List<string> { "A", "B", "C" });

            // Act
            List<GuiWindowsController.MapSelectionRow> result = GuiContentFactory.CreateMapSelectionRows(windowContent);

            // Assert
            Assert.That(result.Count, Is.EqualTo(4));

            Assert.That(result[0].Type, Is.EqualTo(GuiWindowsController.MapSelectionRowType.NEW_INSTANCE));
            Assert.That(result[1].Id, Is.EqualTo("C"));
            Assert.That(result[2].Id, Is.EqualTo("B"));
            Assert.That(result[3].Id, Is.EqualTo("A"));
        }
    }
}