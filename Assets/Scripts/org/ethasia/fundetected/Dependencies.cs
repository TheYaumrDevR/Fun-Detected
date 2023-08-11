using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters;

namespace Org.Ethasia.Fundetected
{

    public class Dependencies
    {
        public static void Inject()
        {
            IoAdaptersFactoryForInteractors.SetInstance(new RealIoAdaptersFactoryForInteractors());
            RealIoAdaptersFactoryForCore.SetInstance(new RealIoAdaptersFactoryForCore());
        }
    }
}