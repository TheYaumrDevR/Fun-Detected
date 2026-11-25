using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{
    [UxmlElement]
    public partial class MainMenuWindow : FunDetectedWindowExtension
    {
        private const string SAVE_BUTTON_NAME = "main-menu-save-button";
        private const string QUIT_BUTTON_NAME = "main-menu-quit-button";

        private Button saveButton;
        private Button quitButton;

        protected override string GetBaseWindowName()
        {
            return "base-window";
        }

        protected override void Initialize()
        {
            var visualTree = Resources.Load<VisualTreeAsset>("UIElements/MainMenuWindow");
            visualTree.CloneTree(this);

            saveButton = this.Q<Button>(SAVE_BUTTON_NAME);
            quitButton = this.Q<Button>(QUIT_BUTTON_NAME);
        }

        protected override List<VisualElement> FindChildrenToMoveToContentArea()
        {
            var result = new List<VisualElement>();

            if (BaseWindow != null)
            {
                foreach (var child in BaseWindow.Children())
                {
                    if (child.name.StartsWith("main-menu"))
                    {
                        result.Add(child);
                    }
                }
            }

            return result;
        }
    }
}