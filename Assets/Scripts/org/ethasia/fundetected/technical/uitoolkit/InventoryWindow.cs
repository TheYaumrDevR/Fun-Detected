using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{
    [UxmlElement]
    public partial class InventoryWindow : FunDetectedWindowExtension
    {
        protected override string GetBaseWindowName() 
        {
            return "base-window";
        }

        protected override void Initialize()
        {
            var visualTree = Resources.Load<VisualTreeAsset>("UIElements/InventoryWindow");
            visualTree.CloneTree(this);
        }

        protected override List<VisualElement> FindChildrenToMoveToContentArea()
        {
            var result = new List<VisualElement>();

            if (BaseWindow != null)
            {
                foreach (var child in BaseWindow.Children())
                {
                    if (child.name.StartsWith("inventory"))
                    {
                        result.Add(child);
                    }
                }
            }

            return result;
        }
    }
}