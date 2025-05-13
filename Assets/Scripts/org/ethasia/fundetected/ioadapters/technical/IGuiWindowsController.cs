namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public interface IGuiWindowsController
    {
        void OpenMapSelectionWindow(MapSelectionWindowContext windowContent);
        void CloseCurrentlyOpenWindow();      
    }
}