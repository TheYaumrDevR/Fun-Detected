namespace Org.Ethasia.Fundetected.Technical
{
    public class RealInternalTechnicalFactory : InternalTechnicalFactory
    {
        private ResourceLoader resourceLoader;

        public override IResourceLoader GetResourceLoaderInstance()
        {
            if (null == resourceLoader)
            {
                resourceLoader = new ResourceLoader();
            }

            return resourceLoader;
        }
    }
}