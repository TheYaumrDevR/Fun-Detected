using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Ioadapters;

namespace Org.Ethasia.Fundetected
{

    public class Dependencies
    {
        public static void Inject()
        {
            IoAdaptersFactory.SetInstance(new RealIoAdaptersFactory());
        }
    }
}