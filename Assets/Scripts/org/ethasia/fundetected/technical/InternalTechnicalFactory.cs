namespace Org.Ethasia.Fundetected.Technical
{
    public abstract class InternalTechnicalFactory
    {
        private static InternalTechnicalFactory instance;

        public static void SetInstance(InternalTechnicalFactory value)
        {
            instance = value;
        }

        public static InternalTechnicalFactory GetInstance()
        {
            return instance;
        }

        public abstract IResourceLoader GetResourceLoaderInstance();
    }
}