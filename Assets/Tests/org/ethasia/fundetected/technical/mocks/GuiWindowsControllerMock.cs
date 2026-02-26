using Org.Ethasia.Fundetected.Ioadapters.Technical;
using Org.Ethasia.Fundetected.Technical.UIToolkit;

namespace Org.Ethasia.Fundetected.Technical.Mocks
{
    public class GuiWindowsControllerMock : IGuiWindowsController
    {
        public InventoryRenderContext LastOpenedInventoryContext
        {
            get; 
            private set;
        }

        public void OpenMapSelectionWindow(MapSelectionWindowContext windowContent)
        {
        }

        public void OpenInventoryWindow(InventoryRenderContext context)
        {
            LastOpenedInventoryContext = context;
        }

        public void CloseCurrentlyOpenWindow()
        {
        }

        public void ToggleInventoryWindow()
        {
        }

        public void ShowItemTooltip(NormalItemTooltip.TooltipDisplayInformation displayInformation)
        {
        }

        public void RepositionItemTooltip(float posX, float posY)
        {
        }

        public void HideItemTooltip()
        {
        }
    }
}