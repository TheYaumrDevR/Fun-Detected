using System.Collections.Generic;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class InteractablesRendererDelayedInitializationProxy : IInteractablesRenderer
    {
        private static InteractablesRenderer realInteractablesRenderer;

        private List<InteractableRenderProxy> storedCallParameters;   

        public InteractablesRendererDelayedInitializationProxy()
        {
            storedCallParameters = new List<InteractableRenderProxy>();
            InteractablesRenderer.RegisterInteractablesRendererProxy(this);
        }         

        public void ClearRenderedInteractables()
        {
            if (null != realInteractablesRenderer)
            {
                realInteractablesRenderer.ClearRenderedInteractables();
            }

            storedCallParameters.Clear();
        }     

        public void RenderInteractable(InteractableRenderProxy renderData)
        {
            if (null == realInteractablesRenderer)
            {
                storedCallParameters.Add(renderData);
            }
            else
            {
                realInteractablesRenderer.RenderInteractable(renderData);
            }
        }  

        public void OnInteractablesRendererAwake(InteractablesRenderer interactablesRenderer)
        {
            realInteractablesRenderer = interactablesRenderer;

            foreach (InteractableRenderProxy renderData in storedCallParameters)
            {
                realInteractablesRenderer.RenderInteractable(renderData);
            }
        }               
    }
}