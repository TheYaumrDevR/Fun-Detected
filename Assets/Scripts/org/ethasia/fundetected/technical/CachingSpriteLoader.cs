using UnityEngine;
using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Technical
{
    public class CachingSpriteLoader
    {
        private static Dictionary<string, Sprite[]> loadedSpriteSetsByName = new Dictionary<string, Sprite[]>();
        private static Dictionary<string, Dictionary<string, Sprite>> loadedSpritesWithNameBySpriteSetName = new Dictionary<string, Dictionary<string, Sprite>>();

        public static Dictionary<string, Sprite> LoadSpritesByNameFromSpriteSetName(string spriteSetName)
        {
            if (loadedSpritesWithNameBySpriteSetName.ContainsKey(spriteSetName))
            {
                return loadedSpritesWithNameBySpriteSetName[spriteSetName];
            }

            Dictionary<string, Sprite> result = new Dictionary<string, Sprite>();

            Sprite[] spriteSet = LoadSpritesFromSpriteSetName(spriteSetName);

            foreach (Sprite sprite in spriteSet)
            {
                result.Add(sprite.name, sprite);
            }

            loadedSpritesWithNameBySpriteSetName.Add(spriteSetName, result);

            return result;
        }

        private static Sprite[] LoadSpritesFromSpriteSetName(string spriteSetName)
        {
            if (loadedSpriteSetsByName.ContainsKey(spriteSetName))
            {
                return loadedSpriteSetsByName[spriteSetName];
            }

            Sprite[] result = Resources.LoadAll<Sprite>(spriteSetName);
            loadedSpriteSetsByName.Add(spriteSetName, result);

            return result;
        }
    }
}