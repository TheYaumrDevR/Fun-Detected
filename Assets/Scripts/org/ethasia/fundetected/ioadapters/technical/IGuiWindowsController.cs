namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public interface IGuiWindowsController
    {
        void OpenMapSelectionWindow(MapSelectionWindowContent windowContent);
        void CloseCurrentlyOpenWindow();      
    }
}