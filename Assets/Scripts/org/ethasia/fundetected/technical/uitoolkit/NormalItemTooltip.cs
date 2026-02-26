using UnityEngine;
using UnityEngine.UIElements;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{
    [UxmlElement]
    public partial class NormalItemTooltip : VisualElement
    {
        private const string HEADER_NAME = "tooltip-header";

        private SingleLineItemTooltipHeader tooltipHeader;

        public NormalItemTooltip()
        {
            var visualTree = Resources.Load<VisualTreeAsset>("UIElements/NormalItemTooltip");
            visualTree.CloneTree(this);

            tooltipHeader = this.Q<SingleLineItemTooltipHeader>(HEADER_NAME);

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

        public struct TooltipDisplayInformation
        {
            public string ItemName
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