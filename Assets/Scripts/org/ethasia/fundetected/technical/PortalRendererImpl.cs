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

        public void RenderPortal(SingleColorRectangularRenderShapeProxy renderData)
        {
            Vector3 position = new Vector3(renderData.X, renderData.Y, 0.0f);
            GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);

            quad.transform.position = position;
            quad.transform.localScale = new Vector3(renderData.Width, renderData.Height, 1.0f);

            quad.GetComponent<Renderer>().material = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply"));
            quad.GetComponent<Renderer>().material.color = Color.white;

            quad.GetComponent<Renderer>().enabled = false;

            quad.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            quad.GetComponent<Renderer>().receiveShadows = false;

            BoxCollider collider = quad.AddComponent<BoxCollider>();
            collider.size = new Vector3(1.0f, 1.0f, 1.0f);

            quad.AddComponent<PortalHoverEffect>();

            quad.transform.SetParent(transform);
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
                quadRenderer.enabled = true;
            }

            void OnMouseExit()
            {
                quadRenderer.enabled = false;
            }
        }            
    }
}