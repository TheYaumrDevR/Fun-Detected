using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

using Org.Ethasia.Fundetected.Core.Items;
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

        private float requestedPosX;
        private float requestedPosY;

        public NormalItemTooltip()
        {
            var visualTree = Resources.Load<VisualTreeAsset>("UIElements/NormalItemTooltip");
            visualTree.CloneTree(this);

            tooltipHeader = this.Q<SingleLineItemTooltipHeader>(HEADER_NAME);
            contentArea = this.Q<VisualElement>(CONTENT_AREA_NAME);

            SetPickingModeIgnoreRecursively(this);
            RegisterCallback<GeometryChangedEvent>(OnGeometryChanged);
        }

        public void Show(TooltipDisplayInformation displayInformation)
        {
            if (null != tooltipHeader)
            {
                if (displayInformation.TooltipRenderContext.ItemPotential == ItemPotential.LATENT)
                {
                    tooltipHeader.SetLatentItemName(displayInformation.ItemName);
                }
                else
                {
                    tooltipHeader.SetItemName(displayInformation.ItemName);
                }

                style.visibility = Visibility.Visible;
                requestedPosX = displayInformation.PosX;
                requestedPosY = displayInformation.PosY;
                CorrectPositionBasedOnWindowBounds(requestedPosX, requestedPosY);
            }

            if (null != contentArea)
            {
                contentArea.Clear();
                SetupToolTipContentAreaHeader(displayInformation.TooltipRenderContext.ItemHeaderLines);
                SetupToolTipContentAreaImplicits(displayInformation.TooltipRenderContext.ItemImplicitLines);
                SetupToolTipContentAreaExplicits(displayInformation.TooltipRenderContext.ItemExplicitLines);
            }
        }

        public void Reposition(float posX, float posY)
        {
            requestedPosX = posX;
            requestedPosY = posY;
            CorrectPositionBasedOnWindowBounds(posX, posY);
        }

        public void Hide()
        {
            style.visibility = Visibility.Hidden;
        }

        private static void SetPickingModeIgnoreRecursively(VisualElement element)
        {
            element.pickingMode = PickingMode.Ignore;

            foreach (VisualElement child in element.Children())
            {
                SetPickingModeIgnoreRecursively(child);
            }
        }

        private void OnGeometryChanged(GeometryChangedEvent evt)
        {
            if (style.visibility == Visibility.Visible)
            {
                CorrectPositionBasedOnWindowBounds(requestedPosX, requestedPosY);
            }
        }

        private void CorrectPositionBasedOnWindowBounds(float posX, float posY)
        {
            float width = resolvedStyle.width;
            float height = resolvedStyle.height;

            if (float.IsNaN(width) || float.IsNaN(height))
            {
                width = 0f;
                height = 0f;
            }

            float maxX = Mathf.Max(0f, Screen.width - width);
            float maxY = Mathf.Max(0f, Screen.height - height);

            float newLeft = Mathf.Min(posX, maxX);
            float newTop = Mathf.Min(posY, maxY);

            // Avoid re-triggering layout when nothing changed
            if (!Mathf.Approximately(style.left.value.value, newLeft))
            {
                style.left = newLeft;
            }

            if (!Mathf.Approximately(style.top.value.value, newTop))
            {
                style.top = newTop;
            }
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
            row.pickingMode = PickingMode.Ignore;
            row.AddToClassList(TEXT_ROW_CLASS);

            var i = 0;
            foreach (var textSegment in textSegments)
            {
                var label = new Label(textSegment.Text);
                label.pickingMode = PickingMode.Ignore;

                string labelClass = textSegment.IsBold ? TEXT_VALUE_CLASS : TEXT_LABEL_CLASS;
                label.AddToClassList(labelClass);

                if (textSegment.Color == UiDefaultColors.TEXT_BLUE)
                {
                    label.AddToClassList(TEXT_BLUE_CLASS);
                }

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

        private void SetupToolTipContentAreaExplicits(List<List<UiTextSegment>> explicitLines)
        {
            if (explicitLines != null)
            {
                if (explicitLines.Count > 0)
                {
                    contentArea.Add(CreateTooltipSegmentDivider());
                }

                foreach (var textSegments in explicitLines)
                {
                    var labelRow = ConvertTextSegmentsToVisualElement(textSegments, new string[] { TEXT_BLUE_CLASS });
                    contentArea.Add(labelRow);
                }
            }
        }

        private VisualElement CreateTooltipSegmentDivider()
        {
            var result = new VisualElement();

            result.pickingMode = PickingMode.Ignore;
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