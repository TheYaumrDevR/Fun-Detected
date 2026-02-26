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

                style.left = displayInformation.PosX;
                style.top = displayInformation.PosY;
                style.visibility = Visibility.Visible;
            }
        }

        public void Reposition(float posX, float posY)
        {
            style.left = posX;
            style.top = posY;
        }

        public void Hide()
        {
            style.visibility = Visibility.Hidden;
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