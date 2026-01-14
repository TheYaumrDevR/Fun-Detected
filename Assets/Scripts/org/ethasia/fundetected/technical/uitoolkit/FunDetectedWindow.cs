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
        private const string ROOT_ELEMENT_CLASS_NAME = "fundetected-window";
        private const string WINDOW_HEADER_CLASS_NAME = "fundetected-window-header";

        private string titleKey;

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

        public FunDetectedWindow()
        {
            var childrenToMove = FindChildrenToMoveToContentArea();

            var visualTree = Resources.Load<VisualTreeAsset>("UIElements/FunDetectedUiWindow");
            visualTree.CloneTree(this);

            var closeWindowButton = this.Q<Button>(CLOSE_BUTTON_NAME);
            if (closeWindowButton != null)
            {
                closeWindowButton.RegisterCallback<ClickEvent>(OnCloseWindowClick);
            }

            MoveChildrenToContentArea(childrenToMove);
        }

        private void MoveChildrenToContentArea(List<VisualElement> childrenToMove)
        {
            var contentContainer = this.Q<VisualElement>(CONTENT_CONTAINER_NAME);
            if (contentContainer == null) 
            {
                return;
            }

            MoveChildrenToContainer(childrenToMove, contentContainer);
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

        private List<VisualElement> FindChildrenToMoveToContentArea()
        {
            var result = new List<VisualElement>();

            foreach (var child in this.Children())
            {
                result.Add(child);
            }

            return result;
        }

        private void MoveChildrenToContainer(List<VisualElement> children, VisualElement container)
        {
            foreach (var child in children)
            {
                child.RemoveFromHierarchy();
                container.Add(child);
            }
        }
    }
}