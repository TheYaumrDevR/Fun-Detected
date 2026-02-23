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

        public void Show(ToolDisplayInformation displayInformation)
        {
            if (null != tooltipHeader)
            {
                tooltipHeader.SetItemName(displayInformation.ItemName);

                style.left = displayInformation.PosX;
                style.top = displayInformation.PosY;
                style.display = DisplayStyle.Flex;
            }
        }

        public void Hide()
        {
            style.display = DisplayStyle.None;
        }

        public struct ToolDisplayInformation
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
                private ToolDisplayInformation product;

                public Builder()
                {
                    product = new ToolDisplayInformation();
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

                public ToolDisplayInformation Build()
                {
                    return product;
                }
            }
        }
    }
}