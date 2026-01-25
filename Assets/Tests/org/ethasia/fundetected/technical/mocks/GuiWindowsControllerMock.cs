using Org.Ethasia.Fundetected.Ioadapters.Technical;

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
    }
}