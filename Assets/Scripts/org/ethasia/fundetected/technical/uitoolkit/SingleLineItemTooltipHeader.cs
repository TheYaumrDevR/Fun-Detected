using UnityEngine;
using UnityEngine.UIElements;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{
    [UxmlElement]
    public partial class SingleLineItemTooltipHeader : VisualElement
    {
        private const string OUTER_BORDER_NAME = "header-outer-border";
        private const string INNER_BORDER_NAME = "header-inner-border";
        private const string BACKGROUND_NAME = "header-background";
        private const string ITEM_NAME_LABEL_ID = "item-name";

        private const string OUTER_BORDER_NORMAL_STYLE = "tooltip-header-normal-border1";
        private const string INNER_BORDER_NORMAL_STYLE = "tooltip-header-normal-border2";
        private const string BACKGROUND_NORMAL_STYLE = "tooltip-header-normal-border3";
        private const string ITEM_NAME_LABEL_NORMAL_STYLE = "tooltip-header-normal-title";

        private VisualElement outerBorder;
        private VisualElement innerBorder;
        private VisualElement background;
        private Label itemNameLabel;

        private bool isInitialized;

        public SingleLineItemTooltipHeader()
        {
            var visualTree = Resources.Load<VisualTreeAsset>("UIElements/SingleLineItemTooltipHeader");
            visualTree.CloneTree(this);

            outerBorder = this.Q<VisualElement>(OUTER_BORDER_NAME);
            innerBorder = this.Q<VisualElement>(INNER_BORDER_NAME);
            background = this.Q<VisualElement>(BACKGROUND_NAME);
            itemNameLabel = this.Q<Label>(ITEM_NAME_LABEL_ID);
        }

        public void SetItemName(string value)
        {
            if (!isInitialized)
            {
                InitializeStyles();
                isInitialized = true;
            }

            if (itemNameLabel != null)
            {
                itemNameLabel.text = value;
            }
        }

        private void InitializeStyles()
        {
            if (outerBorder != null)
            {
                outerBorder.AddToClassList(OUTER_BORDER_NORMAL_STYLE);
            }

            if (innerBorder != null)
            {
                innerBorder.AddToClassList(INNER_BORDER_NORMAL_STYLE);
            }

            if (background != null)
            {
                background.AddToClassList(BACKGROUND_NORMAL_STYLE);
            }

            if (itemNameLabel != null)
            {
                itemNameLabel.AddToClassList(ITEM_NAME_LABEL_NORMAL_STYLE);
            }
        }
    }
}