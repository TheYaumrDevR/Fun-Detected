using System.Collections.Generic;
using UnityEngine;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class StaticPlaceablesRenderer : MonoBehaviour, IStaticPlaceablesRenderer
    {
        private const string TOMBSTONE_RESOURCE_PATH = "Images/StaticPlaceables/Tombstone";

        private static List<StaticPlaceablesRendererDelayedInitializationProxy> proxies = new List<StaticPlaceablesRendererDelayedInitializationProxy>();
        private static StaticPlaceablesRenderer instance;

        private Dictionary<string, GameObject> renderedTombstoneById = new Dictionary<string, GameObject>();

        public static StaticPlaceablesRenderer GetInstance()
        {
            return instance;
        }

        public static void RegisterProxy(StaticPlaceablesRendererDelayedInitializationProxy proxy)
        {
            proxies.Add(proxy);
        }

        void Awake()
        {
            instance = this;

            foreach (StaticPlaceablesRendererDelayedInitializationProxy proxy in proxies)
            {
                proxy.OnStaticPlaceablesRendererAwake(this);
            }
        }

        public void RenderTombstone(string id, float posX, float posY)
        {
            Sprite sprite = Resources.Load<Sprite>(TOMBSTONE_RESOURCE_PATH);

            GameObject tombstone = new GameObject("Tombstone " + id);

            SpriteRenderer spriteRenderer = tombstone.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
            spriteRenderer.sortingLayerName = "Sprites";

            tombstone.transform.position = new Vector3(posX, posY, 0.0f);
            tombstone.transform.SetParent(transform);

            renderedTombstoneById[id] = tombstone;
        }

        public void MoveTombstoneVertically(string id, float units)
        {
            if (renderedTombstoneById.TryGetValue(id, out GameObject tombstone))
            {
                tombstone.transform.Translate(0f, units, 0f);
            }
        }

        public void ClearRenderedStaticPlaceables()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            renderedTombstoneById.Clear();
        }
    }
}