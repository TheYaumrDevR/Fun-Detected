using UnityEngine;
using UnityEngine.UIElements;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{
    [UxmlElement]
    public partial class FunDetectedWindow : VisualElement
    {
        private const string TITLE_LABEL_NAME = "window-title";

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
        }
    }
}