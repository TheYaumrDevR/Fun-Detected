using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{
    [UxmlElement]
    public partial class FunDetectedWindow : VisualElement
    {
        private const string TITLE_LABEL_NAME = "window-title";
        private const string CLOSE_BUTTON_NAME = "window-close-button";
        private const string CONTENT_CONTAINER_NAME = "window-content";

        private string titleKey;
        private bool hideCloseButton;

        [UxmlAttribute]
        public string TitleKey
        {
            get
            {
                return titleKey;
            }

            set
            {
                titleKey = value;

                var localizationGateway = new DictionaryBasedLocalizationGateway();
                Title = localizationGateway.GetLocalizedString(value);
            }
        }

        [UxmlAttribute]
        public string Title
        {
            get => this.Q<Label>(TITLE_LABEL_NAME)?.text ?? "";
            set
            {
                var label = this.Q<Label>(TITLE_LABEL_NAME);
                if (label != null) label.text = value;
            }
        }

        [UxmlAttribute]
        public bool HideCloseButton
        {
            get
            {
                return hideCloseButton;
            }

            set
            {
                EnableInClassList("fundetected-window-no-close", value);
                hideCloseButton = value;

                var closeButton = this.Q<Button>(CLOSE_BUTTON_NAME);
                if (closeButton != null)
                {
                    closeButton.style.display = value ? DisplayStyle.None : DisplayStyle.Flex;
                }
            }
        }

        public FunDetectedWindow()
        {
            var visualTree = Resources.Load<VisualTreeAsset>("UIElements/FunDetectedUiWindow");
            visualTree.CloneTree(this);

            var closeWindowButton = this.Q<Button>(CLOSE_BUTTON_NAME);
            if (closeWindowButton != null)
            {
                closeWindowButton.RegisterCallback<ClickEvent>(OnCloseWindowClick);
            }
        }

        public void MoveChildrenToContainer(List<VisualElement> children)
        {
            var contentContainer = this.Q<VisualElement>(CONTENT_CONTAINER_NAME);
            if (contentContainer == null) 
            {
                return;
            }

            foreach (var child in children)
            {
                child.RemoveFromHierarchy();
                contentContainer.Add(child);
            }
        }

        public void Close()
        {
            if (this.visible)
            {
                this.visible = false;
                GuiWindowsController.GetInstance().EnablePlayerInputIfAllWindowsAreClosed();
                SoundPlayer.GetInstance().PlayUiWindowOpenSound();
            }
        }

        private void OnCloseWindowClick(ClickEvent clickEvent)
        {
            clickEvent.StopPropagation();

            Close();
            SoundPlayer.GetInstance().PlayMouseClickSound();
        }
    }
}