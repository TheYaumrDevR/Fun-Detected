using System.Collections.Generic;
using UnityEngine;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class DroppableItemRenderer : MonoBehaviour, IDroppableItemRenderer
    {
        private static DroppableItemRenderer instance;

        private Dictionary<string, GameObject> renderedItemById = new Dictionary<string, GameObject>();
        private Dictionary<string, GameObject> renderedItemLabelById = new Dictionary<string, GameObject>();

        public static DroppableItemRenderer GetInstance()
        {
            return instance;
        }

        public DroppableItemRenderer()
        {
            renderedItemById = new Dictionary<string, GameObject>();
            renderedItemLabelById = new Dictionary<string, GameObject>();
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
        }

        public void RenderDroppedItem(DroppedItemRenderProxy renderData)
        {
            GameObject droppedItem = new GameObject(renderData.Id);

            Sprite sprite = Resources.Load<Sprite>(renderData.RenderImageName);

            SpriteRenderer spriteRenderer = droppedItem.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
            spriteRenderer.sortingLayerName = "Sprites";
            spriteRenderer.sortingOrder = 1;

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

                GameObject itemLabel = InteractableLabelFactory.CreateInteractableLabel(renderData.ItemName, "ItemLabel " + renderData.Id);

                itemLabel.transform.position = new Vector3(droppedItem.transform.position.x, droppedItem.transform.position.y + 0.5f, 0);
                itemLabel.transform.SetParent(transform);

                renderedItemLabelById.Add(renderData.Id, itemLabel);
            }
        }

        public void ClearRenderedItem(string itemId)
        {
            ClearRenderedItemFromDictionary(itemId, renderedItemById);
            ClearRenderedItemFromDictionary(itemId, renderedItemLabelById);
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
    }
}