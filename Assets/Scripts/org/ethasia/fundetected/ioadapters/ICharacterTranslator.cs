using UnityEngine;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public interface ICharacterTranslator
    {
        void SetCharacterTransform(Transform transform);
        void SetSpriteRenderer(SpriteRenderer spriteRenderer);
    }
}