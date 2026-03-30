using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

using Org.Ethasia.Fundetected.Ioadapters.Presentation.UI;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{
    [UxmlElement]
    public partial class NormalItemTooltip : VisualElement
    {
        private const string HEADER_NAME = "tooltip-header";
        private const string CONTENT_AREA_NAME = "tooltip-content";

        private const string TEXT_ROW_CLASS = "item-tooltip-text-row";
        private const string TEXT_LABEL_CLASS = "item-tooltip-text-label";
        private const string TEXT_VALUE_CLASS = "item-tooltip-text-value";
        private const string TEXT_PADDING_LEFT_CLASS = "item-tooltip-text-padding-left";
        private const string TEXT_PADDING_RIGHT_CLASS = "item-tooltip-text-padding-right";
        private const string TEXT_BLUE_CLASS = "item-tooltip-text-blue";
        private const string SEGMENT_DIVIDER_CLASS = "item-tooltip-section-divider";

        private SingleLineItemTooltipHeader tooltipHeader;
        private VisualElement contentArea;

        public NormalItemTooltip()
        {
            var visualTree = Resources.Load<VisualTreeAsset>("UIElements/NormalItemTooltip");
            visualTree.CloneTree(this);

            tooltipHeader = this.Q<SingleLineItemTooltipHeader>(HEADER_NAME);
            contentArea = this.Q<VisualElement>(CONTENT_AREA_NAME);

            this.pickingMode = PickingMode.Ignore;
        }

        public void Show(TooltipDisplayInformation displayInformation)
        {
            if (null != tooltipHeader)
            {
                tooltipHeader.SetItemName(displayInformation.ItemName);

                style.visibility = Visibility.Visible;
                CorrectPositionBasedOnWindowBounds(displayInformation.PosX, displayInformation.PosY);
            }

            if (null != contentArea)
            {
                contentArea.Clear();
                SetupToolTipContentAreaHeader(displayInformation.TooltipRenderContext.ItemHeaderLines);
                SetupToolTipContentAreaImplicits(displayInformation.TooltipRenderContext.ItemImplicitLines);
            }
        }

        public void Reposition(float posX, float posY)
        {
            CorrectPositionBasedOnWindowBounds(posX, posY);
        }

        public void Hide()
        {
            style.visibility = Visibility.Hidden;
        }

        private void CorrectPositionBasedOnWindowBounds(float posX, float posY)
        {
            float maxX = Screen.width - resolvedStyle.width;
            float maxY = Screen.height - resolvedStyle.height;

            posX = Mathf.Min(posX, maxX);
            posY = Mathf.Min(posY, maxY);

            style.left = posX;
            style.top = posY;
        }

        private void SetupToolTipContentAreaHeader(List<List<UiTextSegment>> tooltipContext)
        {
            if (tooltipContext != null)
            {
                foreach (var textSegments in tooltipContext)
                {
                    var row = ConvertTextSegmentsToVisualElement(textSegments, new string[] {});
                    contentArea.Add(row);
                }
            }
        }

        private VisualElement ConvertTextSegmentsToVisualElement(List<UiTextSegment> textSegments, string[] additionalLabelClasses)
        {
            var row = new VisualElement();
            row.AddToClassList(TEXT_ROW_CLASS);

            var i = 0;
            foreach (var textSegment in textSegments)
            {
                var label = new Label(textSegment.Text);
                string labelClass = textSegment.IsBold ? TEXT_VALUE_CLASS : TEXT_LABEL_CLASS;
                label.AddToClassList(labelClass);

                if (i == 0)
                {
                    label.AddToClassList(TEXT_PADDING_LEFT_CLASS);
                }

                if (i == textSegments.Count - 1)
                {
                    label.AddToClassList(TEXT_PADDING_RIGHT_CLASS);
                }

                foreach (var additionalClass in additionalLabelClasses)
                {
                    label.AddToClassList(additionalClass);
                }

                row.Add(label);

                i++;
            }

            return row;
        }

        private void SetupToolTipContentAreaImplicits(List<List<UiTextSegment>> implicitsLines)
        {
            if (implicitsLines != null)
            {
                if (implicitsLines.Count > 0)
                {
                    contentArea.Add(CreateTooltipSegmentDivider());
                }

                foreach (var textSegments in implicitsLines)
                {
                    var labelRow = ConvertTextSegmentsToVisualElement(textSegments, new string[] { TEXT_BLUE_CLASS });
                    contentArea.Add(labelRow);
                }
            }
        }

        private VisualElement CreateTooltipSegmentDivider()
        {
            var result = new VisualElement();
            result.AddToClassList(SEGMENT_DIVIDER_CLASS);

            return result;
        }

        public struct TooltipDisplayInformation
        {
            public string ItemName
            {
                get;
                private set;
            }

            public ItemTooltipRenderContext TooltipRenderContext
            {
                get;
                private set;
            }

            public float PosX
            {
                get;
                private set;
            }

            public float PosY
            {
                get;
                private set;
            }

            public class Builder
            {
                private TooltipDisplayInformation product;

                public Builder()
                {
                    product = new TooltipDisplayInformation();
                }

                public Builder SetItemName(string value)
                {
                    product.ItemName = value;
                    return this;
                }

                public Builder SetTooltipRenderContext(ItemTooltipRenderContext value)
                {
                    product.TooltipRenderContext = value;
                    return this;
                }

                public Builder SetPosition(float posX, float posY)
                {
                    product.PosX = posX;
                    product.PosY = posY;
                    return this;
                }

                public TooltipDisplayInformation Build()
                {
                    return product;
                }
            }
        }
    }
}