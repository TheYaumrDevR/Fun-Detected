using System.Collections.Generic;
using UnityEngine;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class DroppableItemRenderer : MonoBehaviour, IDroppableItemRenderer
    {
        private static DroppableItemRenderer instance;

        private const string ITEM_BEAM_RESOURCE_PATH = "Images/Items/ItemBeam";
        private const string ITEM_BEAM_MATERIAL_RESOURCE_PATH = "Materials/ItemBeamPulse";

        private static readonly int itemBeamPulsePhaseId = Shader.PropertyToID("_PulsePhase");

        private Material itemBeamMaterial;
        private MaterialPropertyBlock itemBeamPropertyBlock;

        private Dictionary<string, GameObject> renderedItemById = new Dictionary<string, GameObject>();
        private Dictionary<string, GameObject> renderedItemLabelById = new Dictionary<string, GameObject>();
        private Dictionary<string, GameObject> renderedItemBeamById = new Dictionary<string, GameObject>();

        public static DroppableItemRenderer GetInstance()
        {
            return instance;
        }

        public DroppableItemRenderer()
        {
            renderedItemById = new Dictionary<string, GameObject>();
            renderedItemLabelById = new Dictionary<string, GameObject>();
            renderedItemBeamById = new Dictionary<string, GameObject>();
        }

        void Awake()
        {
            instance = this;
        }

        public void ClearRenderedDroppedItems()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            renderedItemById.Clear();
            renderedItemLabelById.Clear();
            renderedItemBeamById.Clear();
        }

        public void RenderDroppedItem(DroppedItemRenderProxy renderData)
        {
            GameObject droppedItem = new GameObject(renderData.Id);

            Sprite sprite = Resources.Load<Sprite>(renderData.RenderImageName);

            Shader shader = Shader.Find("Unlit/VertexSpinSprite");
            Material material = new Material(shader);
            material.SetFloat("_Speed", 15.0f);

            SpriteRenderer spriteRenderer = droppedItem.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
            spriteRenderer.sortingLayerName = "Sprites";
            spriteRenderer.sortingOrder = 1;
            spriteRenderer.material = material;

            droppedItem.transform.position = new Vector3(renderData.PosX, renderData.PosY, 0.0f);
            droppedItem.transform.SetParent(transform);

            renderedItemById.Add(renderData.Id, droppedItem);
        }

        public void MoveDroppedItemVertically(string itemId, float units)
        {
            if (renderedItemById.ContainsKey(itemId) && units != 0)
            {
                GameObject droppedItem = renderedItemById[itemId];
                droppedItem.transform.Translate(0, units, 0);
            }
        }

        public void MoveDroppedItemLeft(string itemId, float units)
        {
            if (renderedItemById.ContainsKey(itemId) && units > 0)
            {
                GameObject droppedItem = renderedItemById[itemId];
                droppedItem.transform.Translate(-units, 0, 0);
            }
        }

        public void MoveDroppedItemRight(string itemId, float units)
        {
            if (renderedItemById.ContainsKey(itemId) && units > 0)
            {
                GameObject droppedItem = renderedItemById[itemId];
                droppedItem.transform.Translate(units, 0, 0);
            }
        }

        public void RenderDroppedItemLabel(DroppedItemRenderProxy renderData)
        {
            if (renderedItemById.ContainsKey(renderData.Id))
            {
                GameObject droppedItem = renderedItemById[renderData.Id];

                GameObject itemLabel = InteractableLabelFactory.CreateInteractableLabel(renderData, "ItemLabel " + renderData.Id);

                itemLabel.transform.position = new Vector3(droppedItem.transform.position.x, droppedItem.transform.position.y + 0.5f, 0);
                itemLabel.transform.SetParent(transform);

                renderedItemLabelById.Add(renderData.Id, itemLabel);

                RenderItemBeam(renderData, droppedItem);
                StopSpinning(renderData.Id);
            }
        }

        public void ClearRenderedItem(string itemId)
        {
            ClearRenderedItemFromDictionary(itemId, renderedItemById);
            ClearRenderedItemFromDictionary(itemId, renderedItemLabelById);
            ClearRenderedItemFromDictionary(itemId, renderedItemBeamById);
        }

        private void RenderItemBeam(DroppedItemRenderProxy renderData, GameObject droppedItem)
        {
            if (!renderData.RenderBeam || renderedItemBeamById.ContainsKey(renderData.Id))
            {
                return;
            }

            Sprite beamSprite = Resources.Load<Sprite>(ITEM_BEAM_RESOURCE_PATH);

            if (null == beamSprite)
            {
                return;
            }

            GameObject beam = new GameObject("ItemBeam " + renderData.Id);

            SpriteRenderer beamRenderer = beam.AddComponent<SpriteRenderer>();
            beamRenderer.sprite = beamSprite;
            beamRenderer.sortingLayerName = "Sprites";
            beamRenderer.sortingOrder = 0;

            SetupBeamShader(beamRenderer);

            if (!string.IsNullOrEmpty(renderData.BeamColor) && ColorUtility.TryParseHtmlString(renderData.BeamColor, out Color beamColor))
            {
                beamRenderer.color = beamColor;
            }

            beam.transform.SetParent(transform);
            beam.transform.position = droppedItem.transform.position;

            AlignBeamBottomWithItemBottom(beamRenderer, droppedItem.GetComponent<SpriteRenderer>());

            renderedItemBeamById.Add(renderData.Id, beam);
        }

        private void SetupBeamShader(SpriteRenderer beamRenderer)
        {
            if (null == itemBeamMaterial)
            {
                itemBeamMaterial = Resources.Load<Material>(ITEM_BEAM_MATERIAL_RESOURCE_PATH);
            }           

            if (null != itemBeamMaterial)
            {
                beamRenderer.sharedMaterial = itemBeamMaterial;

                if (null == itemBeamPropertyBlock)
                {
                    itemBeamPropertyBlock = new MaterialPropertyBlock();
                }

                beamRenderer.GetPropertyBlock(itemBeamPropertyBlock);
                itemBeamPropertyBlock.SetFloat(itemBeamPulsePhaseId, Random.value);
                beamRenderer.SetPropertyBlock(itemBeamPropertyBlock);
            }  
        }

        private static void AlignBeamBottomWithItemBottom(SpriteRenderer beamRenderer, SpriteRenderer itemRenderer)
        {
            float itemBottom = itemRenderer.bounds.min.y;
            float beamBottom = beamRenderer.bounds.min.y;

            beamRenderer.transform.Translate(0f, itemBottom - beamBottom, 0f, Space.World);
        }

        private void ClearRenderedItemFromDictionary(string itemId, Dictionary<string, GameObject> dictionary)
        {
            if (dictionary.ContainsKey(itemId))
            {
                GameObject renderedItem = dictionary[itemId];

                Destroy(renderedItem);
                dictionary.Remove(itemId);
            }
        }

        private void StopSpinning(string itemId)
        {
            GameObject droppedItem = renderedItemById[itemId];
            SpriteRenderer spriteRenderer = droppedItem.GetComponent<SpriteRenderer>();

            MaterialPropertyBlock block = new MaterialPropertyBlock();

            spriteRenderer.GetPropertyBlock(block);
            block.SetFloat("_Speed", 0f);
            spriteRenderer.SetPropertyBlock(block);
        }
    }
}