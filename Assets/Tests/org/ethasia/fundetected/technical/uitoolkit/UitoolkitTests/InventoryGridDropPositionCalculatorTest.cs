using NUnit.Framework;
using UnityEngine;

using Org.Ethasia.Fundetected.Ioadapters.Technical;
using Org.Ethasia.Fundetected.Technical.UIToolkit;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit.Tests
{
    public class InventoryGridDropPositionCalculatorTest
    {
        [Test]
        public void CalculateTargetDropDimensions_WhenCursorIsAtCenterOfTwoByThreeShape_ReturnsTopLeftCornerAtOneOne()
        {
            InventoryGridPanel.InventoryGridDropPositionCalculator testCandidate =
                new InventoryGridPanel.InventoryGridDropPositionCalculator(12, 5, 34);

            Vector2 cursorAtShapeCenter = new Vector2(68f, 85f);

            InventoryGridItemDimensions result = testCandidate.CalculateTargetDropDimensions(cursorAtShapeCenter, 2, 3);

            InventoryGridItemDimensions expected = new InventoryGridItemDimensions.Builder()
                .SetTopLeftCornerX(1)
                .SetTopLeftCornerY(1)
                .SetWidth(2)
                .SetHeight(3)
                .Build();

            AssertDimensions(result, expected);
        }

        [Test]
        public void CalculateTargetDropDimensions_WhenCursorIsSlightlyRightOfCenterOfTwoByThreeShape_ReturnsTopLeftCornerAtTwoOne()
        {
            InventoryGridPanel.InventoryGridDropPositionCalculator testCandidate =
                new InventoryGridPanel.InventoryGridDropPositionCalculator(12, 5, 34);

            Vector2 cursorSlightlyRightOfCenter = new Vector2(86f, 85f);

            InventoryGridItemDimensions result = testCandidate.CalculateTargetDropDimensions(cursorSlightlyRightOfCenter, 2, 3);

            InventoryGridItemDimensions expected = new InventoryGridItemDimensions.Builder()
                .SetTopLeftCornerX(2)
                .SetTopLeftCornerY(1)
                .SetWidth(2)
                .SetHeight(3)
                .Build();

            AssertDimensions(result, expected);
        }

        [Test]
        public void CalculateTargetDropDimensions_WhenCursorIsSlightlyBelowCenterOfTwoByThreeShape_ReturnsTopLeftCornerAtOneTwo()
        {
            InventoryGridPanel.InventoryGridDropPositionCalculator testCandidate =
                new InventoryGridPanel.InventoryGridDropPositionCalculator(12, 5, 34);

            Vector2 cursorSlightlyBelowCenter = new Vector2(68f, 103f);

            InventoryGridItemDimensions result = testCandidate.CalculateTargetDropDimensions(cursorSlightlyBelowCenter, 2, 3);

            InventoryGridItemDimensions expected = new InventoryGridItemDimensions.Builder()
                .SetTopLeftCornerX(1)
                .SetTopLeftCornerY(2)
                .SetWidth(2)
                .SetHeight(3)
                .Build();

            AssertDimensions(result, expected);
        }

        [Test]
        public void CalculateTargetDropDimensions_WhenCursorIsOnePixelBelowTopBorderOfGrid_ClampsTopLeftCornerToRowZero()
        {
            InventoryGridPanel.InventoryGridDropPositionCalculator testCandidate =
                new InventoryGridPanel.InventoryGridDropPositionCalculator(12, 5, 34);

            Vector2 cursorOnePixelBelowTopBorder = new Vector2(68f, 1f);

            InventoryGridItemDimensions result = testCandidate.CalculateTargetDropDimensions(cursorOnePixelBelowTopBorder, 2, 2);

            InventoryGridItemDimensions expected = new InventoryGridItemDimensions.Builder()
                .SetTopLeftCornerX(1)
                .SetTopLeftCornerY(0)
                .SetWidth(2)
                .SetHeight(2)
                .Build();

            AssertDimensions(result, expected);
        }

        [Test]
        public void CalculateTargetDropDimensions_WhenCursorIsOnePixelAboveBottomBorderOfGrid_ClampsTopLeftCornerToLastValidRow()
        {
            InventoryGridPanel.InventoryGridDropPositionCalculator testCandidate =
                new InventoryGridPanel.InventoryGridDropPositionCalculator(12, 5, 34);

            Vector2 cursorOnePixelAboveBottomBorder = new Vector2(68f, 169f);

            InventoryGridItemDimensions result = testCandidate.CalculateTargetDropDimensions(cursorOnePixelAboveBottomBorder, 2, 2);

            InventoryGridItemDimensions expected = new InventoryGridItemDimensions.Builder()
                .SetTopLeftCornerX(1)
                .SetTopLeftCornerY(3)
                .SetWidth(2)
                .SetHeight(2)
                .Build();

            AssertDimensions(result, expected);
        }

        [Test]
        public void CalculateTargetDropDimensions_WhenCursorIsOnePixelRightOfLeftBorderOfGrid_ClampsTopLeftCornerToColumnZero()
        {
            InventoryGridPanel.InventoryGridDropPositionCalculator testCandidate =
                new InventoryGridPanel.InventoryGridDropPositionCalculator(12, 5, 34);

            Vector2 cursorOnePixelRightOfLeftBorder = new Vector2(1f, 51f);

            InventoryGridItemDimensions result = testCandidate.CalculateTargetDropDimensions(cursorOnePixelRightOfLeftBorder, 2, 2);

            InventoryGridItemDimensions expected = new InventoryGridItemDimensions.Builder()
                .SetTopLeftCornerX(0)
                .SetTopLeftCornerY(1)
                .SetWidth(2)
                .SetHeight(2)
                .Build();

            AssertDimensions(result, expected);
        }

        [Test]
        public void CalculateTargetDropDimensions_WhenCursorIsOnePixelLeftOfRightBorderOfGrid_ClampsTopLeftCornerToLastValidColumn()
        {
            InventoryGridPanel.InventoryGridDropPositionCalculator testCandidate =
                new InventoryGridPanel.InventoryGridDropPositionCalculator(12, 5, 34);

            Vector2 cursorOnePixelLeftOfRightBorder = new Vector2(407f, 51f);

            InventoryGridItemDimensions result = testCandidate.CalculateTargetDropDimensions(cursorOnePixelLeftOfRightBorder, 2, 2);

            InventoryGridItemDimensions expected = new InventoryGridItemDimensions.Builder()
                .SetTopLeftCornerX(10)
                .SetTopLeftCornerY(1)
                .SetWidth(2)
                .SetHeight(2)
                .Build();

            AssertDimensions(result, expected);
        }

        private static void AssertDimensions(InventoryGridItemDimensions result, InventoryGridItemDimensions expected)
        {
            Assert.That(result.TopLeftCornerX, Is.EqualTo(expected.TopLeftCornerX));
            Assert.That(result.TopLeftCornerY, Is.EqualTo(expected.TopLeftCornerY));
            Assert.That(result.Width, Is.EqualTo(expected.Width));
            Assert.That(result.Height, Is.EqualTo(expected.Height));
        }
    }
}
