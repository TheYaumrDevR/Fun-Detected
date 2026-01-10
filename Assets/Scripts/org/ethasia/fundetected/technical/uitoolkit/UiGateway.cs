using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{
    public class UiGateway : IUiGateway
    {
        public bool IsMouseOverInventoryWindow()
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            
            var uiDocument = Object.FindAnyObjectByType<UnityEngine.UIElements.UIDocument>();
            if (uiDocument?.rootVisualElement != null)
            {
                var inventoryWindow = uiDocument.rootVisualElement.Q<UIToolkit.FunDetectedWindow>();
                
                return inventoryWindow != null && 
                    inventoryWindow.visible && 
                    inventoryWindow.worldBound.Contains(mousePosition);
            }
            
            return false;
        }        
    }
}