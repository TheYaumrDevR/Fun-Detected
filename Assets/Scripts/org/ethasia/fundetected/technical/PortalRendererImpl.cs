using System.Collections.Generic;
using UnityEngine;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class PortalRendererImpl : MonoBehaviour, IPortalRenderer
    {
        private static List<PortalRendererDelayedInitializationProxy> portalRendererProxies = new List<PortalRendererDelayedInitializationProxy>();
        private static PortalRendererImpl instance;

        public static PortalRendererImpl GetInstance()
        {
            return instance;
        }

        public static void RegisterPortalRendererProxy(PortalRendererDelayedInitializationProxy proxy)
        {
            portalRendererProxies.Add(proxy);
        }

        void Awake()
        {
            instance = this;
            NotifyProxiesAboutAwake();
        }

        public void ClearRenderedPortals()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }

        public void RenderPortal(SingleColorRectangularRenderShapeProxy renderData)
        {
            GameObject quad = CreatePortalQuad(renderData); 
            SetupOnHoverEffect(quad);
            GameObject portalLabel = InteractableLabelFactory.CreateInteractableLabel(renderData.Label, "PortalLabel");

            portalLabel.transform.position = quad.transform.position;
            portalLabel.transform.SetParent(quad.transform);            

            quad.transform.SetParent(transform);
        }

        private GameObject CreatePortalQuad(SingleColorRectangularRenderShapeProxy renderData)
        {
            Vector3 position = new Vector3(renderData.X, renderData.Y, 0.0f);
            GameObject result = GameObject.CreatePrimitive(PrimitiveType.Quad);

            result.transform.position = position;
            result.transform.localScale = new Vector3(renderData.Width, renderData.Height, 1.0f);

            result.GetComponent<Renderer>().material = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply"));
            result.GetComponent<Renderer>().material.color = Color.white;

            result.GetComponent<Renderer>().enabled = false;

            result.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            result.GetComponent<Renderer>().receiveShadows = false;

            return result;
        }

        private void SetupOnHoverEffect(GameObject quad)
        {
            BoxCollider collider = quad.AddComponent<BoxCollider>();
            collider.size = new Vector3(1.0f, 1.0f, 1.0f);

            quad.AddComponent<PortalHoverEffect>();
        }

        private void NotifyProxiesAboutAwake()
        {
            foreach (PortalRendererDelayedInitializationProxy proxy in portalRendererProxies)
            {
                proxy.OnPortalRendererAwake(this);
            }
        }    

        private class PortalHoverEffect : MonoBehaviour
        {
            private Renderer quadRenderer;

            void Start()
            {
                quadRenderer = GetComponent<Renderer>();
            }

            void OnMouseEnter()
            {
                if (quadRenderer != null)
                {
                    quadRenderer.enabled = true;
                }
            }

            void OnMouseExit()
            {
                quadRenderer.enabled = false;
            }
        }            
    }
}