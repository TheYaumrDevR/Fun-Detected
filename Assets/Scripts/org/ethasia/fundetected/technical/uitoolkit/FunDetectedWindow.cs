using UnityEngine;
using UnityEngine.UIElements;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{
    [UxmlElement]
    public partial class FunDetectedWindow : VisualElement
    {
        private const string TITLE_LABEL_NAME = "window-title";
        private const string CLOSE_BUTTON_NAME = "window-close-button";

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
            var visualTree = Resources.Load<VisualTreeAsset>("UIElements/FunDetectedUiWindow");
            visualTree.CloneTree(this);

            var closeWindowButton = this.Q<Button>(CLOSE_BUTTON_NAME);
            if (closeWindowButton != null)
            {
                closeWindowButton.RegisterCallback<ClickEvent>(OnCloseWindowClick);
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