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

        private const string OUTER_BORDER_BASE_STYLE = "tooltip-header-base-border1";
        private const string INNER_BORDER_BASE_STYLE = "tooltip-header-base-border2";
        private const string BACKGROUND_BASE_STYLE = "tooltip-header-base-border3";
        private const string ITEM_NAME_LABEL_BASE_STYLE = "tooltip-header-base-title";

        private const string OUTER_BORDER_NORMAL_STYLE = "tooltip-header-normal-border1";
        private const string INNER_BORDER_NORMAL_STYLE = "tooltip-header-normal-border2";
        private const string BACKGROUND_NORMAL_STYLE = "tooltip-header-normal-border3";
        private const string ITEM_NAME_LABEL_NORMAL_STYLE = "tooltip-header-normal-title";

        private const string OUTER_BORDER_LATENT_STYLE = "tooltip-header-latent-border1";
        private const string INNER_BORDER_LATENT_STYLE = "tooltip-header-latent-border2";
        private const string BACKGROUND_LATENT_STYLE = "tooltip-header-latent-border3";
        private const string ITEM_NAME_LABEL_LATENT_STYLE = "tooltip-header-latent-title";

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
            EnsureBaseStylesAreInitialized();
            RemoveLatentStyles();
            AddNormalStyles();

            SetNameText(value);
        }

        public void SetLatentItemName(string value)
        {
            EnsureBaseStylesAreInitialized();
            RemoveNormalStyles();
            AddLatentStyles();

            SetNameText(value);
        }

        private void SetNameText(string value)
        {
            if (itemNameLabel != null)
            {
                itemNameLabel.text = value;
            }
        }

        private void EnsureBaseStylesAreInitialized()
        {
            if (isInitialized)
            {
                return;
            }

            outerBorder?.AddToClassList(OUTER_BORDER_BASE_STYLE);
            innerBorder?.AddToClassList(INNER_BORDER_BASE_STYLE);
            background?.AddToClassList(BACKGROUND_BASE_STYLE);
            itemNameLabel?.AddToClassList(ITEM_NAME_LABEL_BASE_STYLE);

            isInitialized = true;
        }

        private void AddNormalStyles()
        {
            outerBorder?.AddToClassList(OUTER_BORDER_NORMAL_STYLE);
            innerBorder?.AddToClassList(INNER_BORDER_NORMAL_STYLE);
            background?.AddToClassList(BACKGROUND_NORMAL_STYLE);
            itemNameLabel?.AddToClassList(ITEM_NAME_LABEL_NORMAL_STYLE);
        }

        private void RemoveNormalStyles()
        {
            outerBorder?.RemoveFromClassList(OUTER_BORDER_NORMAL_STYLE);
            innerBorder?.RemoveFromClassList(INNER_BORDER_NORMAL_STYLE);
            background?.RemoveFromClassList(BACKGROUND_NORMAL_STYLE);
            itemNameLabel?.RemoveFromClassList(ITEM_NAME_LABEL_NORMAL_STYLE);
        }

        private void AddLatentStyles()
        {
            outerBorder?.AddToClassList(OUTER_BORDER_LATENT_STYLE);
            innerBorder?.AddToClassList(INNER_BORDER_LATENT_STYLE);
            background?.AddToClassList(BACKGROUND_LATENT_STYLE);
            itemNameLabel?.AddToClassList(ITEM_NAME_LABEL_LATENT_STYLE);
        }

        private void RemoveLatentStyles()
        {
            outerBorder?.RemoveFromClassList(OUTER_BORDER_LATENT_STYLE);
            innerBorder?.RemoveFromClassList(INNER_BORDER_LATENT_STYLE);
            background?.RemoveFromClassList(BACKGROUND_LATENT_STYLE);
            itemNameLabel?.RemoveFromClassList(ITEM_NAME_LABEL_LATENT_STYLE);
        }
    }
}