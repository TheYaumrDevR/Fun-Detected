using System.Collections.Generic;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class PortalRendererDelayedInitializationProxy : IPortalRenderer
    {
        private static PortalRendererImpl realPortalRenderer;

        private List<SingleColorRectangularRenderShapeProxy> storedCallParameters;   

        public PortalRendererDelayedInitializationProxy()
        {
            storedCallParameters = new List<SingleColorRectangularRenderShapeProxy>();
            PortalRendererImpl.RegisterPortalRendererProxy(this);
        }     

        public void RenderPortal(SingleColorRectangularRenderShapeProxy renderData)
        {
            if (null == realPortalRenderer)
            {
                storedCallParameters.Add(renderData);
            }
            else
            {
                realPortalRenderer.RenderPortal(renderData);
            }
        }

        public void OnPortalRendererAwake(PortalRendererImpl portalRenderer)
        {
            realPortalRenderer = portalRenderer;

            foreach (SingleColorRectangularRenderShapeProxy renderData in storedCallParameters)
            {
                realPortalRenderer.RenderPortal(renderData);
            }
        }
    }
}