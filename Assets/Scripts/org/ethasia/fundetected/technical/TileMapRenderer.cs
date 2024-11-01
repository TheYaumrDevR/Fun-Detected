using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class TileMapRenderer : MonoBehaviour, ITileMapRenderer
    {
        private static TileMapRenderer instance;
        private static List<IInitializationObserver> initializationObservers;

        public Tilemap Ground;
        public Tilemap Terrain;

        public static TileMapRenderer GetInstance()
        {
            return instance;
        }        

        public static void RegisterInitializationObserver(IInitializationObserver observer)
        {
            if (null == initializationObservers)
            {
                initializationObservers = new List<IInitializationObserver>();
            }

            initializationObservers.Add(observer);
        }

        void Awake()
        {
            instance = this;

            if (null != initializationObservers)
            {
                foreach (IInitializationObserver observer in initializationObservers)
                {
                    observer.NotifyInitializationCompleted();
                }
            }
        }  

        public void RenderGroundTileAtPosition(TileRenderContext tileRenderContext)
        {
            RenderTileAtPosition(Ground, tileRenderContext);
        }   

        public void RenderTerrainTileAtPosition(TileRenderContext tileRenderContext)
        {
            RenderTileAtPosition(Terrain, tileRenderContext);
        }   

        private void RenderTileAtPosition(Tilemap tilemap, TileRenderContext tileRenderContext)
        {
            int x = tileRenderContext.X;
            int y = tileRenderContext.Y;

            tilemap.SetTile(new Vector3Int(x, y, 0), GetTileBySetNameAndIndex(tileRenderContext.TileSetName, tileRenderContext.TileName));
        }

        private Tile GetTileBySetNameAndIndex(string tileSetName, string tileName)
        {
            Dictionary<string, Sprite> spritesByName = CachingSpriteLoader.LoadSpritesByNameFromSpriteSetName(tileSetName);

            if (!spritesByName.ContainsKey(tileName))
            {
                return null;
            }

            Tile result = ScriptableObject.CreateInstance<Tile>();
            result.sprite = spritesByName[tileName];

            return result;
        }
    }
}