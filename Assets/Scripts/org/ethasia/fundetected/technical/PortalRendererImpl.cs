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

        private void AddPortalLabel(GameObject portalQuad, string portalLabel)
        {
            GameObject label = new GameObject("PortalLabel");
            TextMesh textMesh = label.AddComponent<TextMesh>();

            textMesh.text = portalLabel;
            textMesh.fontSize = 28;
            textMesh.characterSize = 0.1f;
            textMesh.color = Color.white;

            textMesh.anchor = TextAnchor.MiddleCenter;
            textMesh.alignment = TextAlignment.Center;

            // Set the z position value to be in front of the portal quad
            label.transform.position = portalQuad.transform.position;
            label.transform.SetParent(portalQuad.transform);

            Renderer textRenderer = textMesh.GetComponent<Renderer>();
            textRenderer.sortingLayerName = "IngameLabels";
            textRenderer.sortingOrder = 1;        

            GameObject backGroundQuad = AddPortalLabelBackground(textMesh);

            // Position the background behind the text
            backGroundQuad.transform.SetParent(label.transform);
            backGroundQuad.transform.localPosition = new Vector3(0, 0, 0); // Ensure it is behind the text             
        }

        private GameObject AddPortalLabelBackground(TextMesh textMesh)
        {
            Renderer textRenderer = textMesh.GetComponent<Renderer>();
            Vector3 textSize = textRenderer.bounds.size;

            GameObject result = new GameObject("BackgroundRectangle");

            SpriteRenderer spriteRenderer = result.AddComponent<SpriteRenderer>();

            int pixelsPerUnit = 100;
            Texture2D texture = CreateBackgroundRectangleTexture(textSize, pixelsPerUnit);

            Rect rect = new Rect(0, 0, texture.width, texture.height);
            Vector2 pivot = new Vector2(0.5f, 0.5f);
            Sprite sprite = Sprite.Create(texture, rect, pivot, pixelsPerUnit);
            spriteRenderer.sprite = sprite; 

            spriteRenderer.sortingLayerName = "IngameLabels";
            spriteRenderer.sortingOrder = 0;           

            return result;       
        }

        private Texture2D CreateBackgroundRectangleTexture(Vector3 textSize, int pixelsPerUnit)
        {
            int textureWidth = (int)((textSize.x + 0.1f) * pixelsPerUnit);
            int textureHeight = (int)(textSize.y * pixelsPerUnit);

            Texture2D result = new Texture2D(textureWidth, textureHeight);

            Color backgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.7f);
            for (int i = 0; i < textureWidth; i++)
            {
                for (int j = 0; j < textureHeight; j++)
                {
                    result.SetPixel(i, j, backgroundColor);
                }
            }

            result.Apply();

            return result;
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