using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters;
using Org.Ethasia.Fundetected.Ioadapters.Technical;
using Org.Ethasia.Fundetected.Technical;

namespace Org.Ethasia.Fundetected
{

    public class Dependencies
    {
        public static void Inject()
        {
            InternalInteractorsFactory.SetInstance(new RealInternalInteractorsFactory());
            IoAdaptersFactoryForInteractors.SetInstance(new RealIoAdaptersFactoryForInteractors());
            RealIoAdaptersFactoryForCore.SetInstance(new RealIoAdaptersFactoryForCore());
            TechnicalFactory.SetInstance(new RealTechnicalFactory());
        }
    }
}