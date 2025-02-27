using System.Collections.Generic;
using UnityEngine;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class InteractablesRenderer : MonoBehaviour, IInteractablesRenderer
    {
        private static List<InteractablesRendererDelayedInitializationProxy> interactablesRendererProxies = new List<InteractablesRendererDelayedInitializationProxy>();
        private static InteractablesRenderer instance;

        public static InteractablesRenderer GetInstance()
        {
            return instance;
        }      

        public static void RegisterInteractablesRendererProxy(InteractablesRendererDelayedInitializationProxy proxy)
        {
            interactablesRendererProxies.Add(proxy);
        }          

        void Awake()
        {
            instance = this;
            NotifyProxiesAboutAwake();
        }       

        public void ClearRenderedInteractables()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }     

        public void RenderInteractable(InteractableRenderProxy renderData)
        {
            GameObject interactable = CreateInteractableSprite(renderData);
            SetupOnHoverEffect(interactable);

            GameObject interactableLabel = InteractableLabelFactory.CreateInteractableLabel(renderData.InteractableDisplayName, renderData.InteractableDisplayName + " Label");

            interactableLabel.transform.position = interactable.transform.position;
            interactableLabel.transform.SetParent(interactable.transform);  
        }   

        private GameObject CreateInteractableSprite(InteractableRenderProxy renderData)
        {
            Sprite sprite = Resources.Load<Sprite>(renderData.RenderImageName);

            GameObject result = new GameObject("Interactable");

            SpriteRenderer spriteRenderer = result.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
            spriteRenderer.sortingLayerName = "Sprites";

            result.transform.position = new Vector3(renderData.PosX, renderData.PosY, 0.0f);
            result.transform.SetParent(transform);

            return result;
        }

        private void SetupOnHoverEffect(GameObject interactable)
        {
            BoxCollider collider = interactable.AddComponent<BoxCollider>();
            collider.size = new Vector3(1.0f, 1.0f, 1.0f);

            interactable.AddComponent<OutlineHoverEffect>();
        }        

        private void NotifyProxiesAboutAwake()
        {
            foreach (InteractablesRendererDelayedInitializationProxy proxy in interactablesRendererProxies)
            {
                proxy.OnInteractablesRendererAwake(this);
            }
        } 

        private class OutlineHoverEffect : MonoBehaviour
        {
            private Renderer interactableRenderer;
            private Material originalMaterial;
            private Material outlineMaterial;

            void Start()
            {
                interactableRenderer = GetComponent<Renderer>();
                originalMaterial = interactableRenderer.material;

                outlineMaterial = Resources.Load<Material>("OutlineHoverEffectMaterial");
            }            

            void OnMouseEnter()
            {
                if (null != interactableRenderer)
                {
                    interactableRenderer.material = outlineMaterial;
                }
            }

            void OnMouseExit()
            {
                interactableRenderer.material = originalMaterial;
            }
        }         
    }    
}