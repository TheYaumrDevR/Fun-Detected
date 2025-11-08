using System.Collections.Generic;
using UnityEngine;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class DroppableItemRenderer : MonoBehaviour, IDroppableItemRenderer
    {
        private static DroppableItemRenderer instance;

        private Dictionary<string, GameObject> renderedItemById = new Dictionary<string, GameObject>();

        public static DroppableItemRenderer GetInstance()
        {
            return instance;
        }

        public DroppableItemRenderer()
        {
            renderedItemById = new Dictionary<string, GameObject>();
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

        public void MoveDroppedItemVertically(string itemId, int units)
        {
            if (renderedItemById.ContainsKey(itemId) && units != 0)
            {
                GameObject droppedItem = renderedItemById[itemId];
                droppedItem.transform.Translate(0, 0.1f * units, 0);
            }
        }

        public void MoveDroppedItemLeft(string itemId, int units)
        {
            if (renderedItemById.ContainsKey(itemId) && units > 0)
            {
                GameObject droppedItem = renderedItemById[itemId];
                droppedItem.transform.Translate(-0.1f * units, 0, 0);
            }
        }

        public void MoveDroppedItemRight(string itemId, int units)
        {
            if (renderedItemById.ContainsKey(itemId) && units > 0)
            {
                GameObject droppedItem = renderedItemById[itemId];
                droppedItem.transform.Translate(0.1f * units, 0, 0);
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
            }
        }
    }
}