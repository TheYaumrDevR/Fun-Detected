using UnityEngine;

using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Technical
{
    public class IngameGuiInitializer : MonoBehaviour
    {
        void Start()
        {
            GuiSetupInteractor guiSetupInteractor = new GuiSetupInteractor();
            guiSetupInteractor.InitializeGui();
        }
    }
}