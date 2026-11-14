namespace Org.Ethasia.Fundetected.Technical.Mocks
{
    public class InternalTechnicalMockFactory : InternalTechnicalFactory
    {
        private IResourceLoader resourceLoader;

        public InternalTechnicalMockFactory(IResourceLoader resourceLoader)
        {
            this.resourceLoader = resourceLoader;
        }

        public override IResourceLoader GetResourceLoaderInstance()
        {
            return resourceLoader;
        }
    }
}