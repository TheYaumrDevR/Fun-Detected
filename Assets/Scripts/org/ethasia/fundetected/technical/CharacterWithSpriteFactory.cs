using UnityEngine;

using Org.Ethasia.Fundetected.Ioadapters.Technical;
using Org.Ethasia.Fundetected.Technical.Animation;

namespace Org.Ethasia.Fundetected.Technical
{
    public class CharacterWithSpriteFactory
    {
        public static CharacterWithSpriteFactoryProduct CreateCharacterWithSprite(GameObjectProxy animatedCharacterProxy, int sortingOrder, Transform transform)
        {
            GameObject animatedCharacter = new GameObject(animatedCharacterProxy.Name);
            animatedCharacter.transform.position = new Vector3(animatedCharacterProxy.PosX, animatedCharacterProxy.PosY, 0f);
            animatedCharacter.transform.localScale = new Vector3(animatedCharacterProxy.ScaleX, animatedCharacterProxy.ScaleY, 0f);

            SpriteRenderer spriteRenderer = animatedCharacter.AddComponent<SpriteRenderer>();
            spriteRenderer.sortingLayerName = "Sprites";
            spriteRenderer.sortingOrder = sortingOrder;

            Sprite2dAnimatorBehavior animatorBehavior = animatedCharacter.AddComponent<Sprite2dAnimatorBehavior>();
            
            animatedCharacter.transform.SetParent(transform);

            AudioSource audioSource = animatedCharacter.AddComponent<AudioSource>();

            CharacterWithSpriteFactoryProduct result = new CharacterWithSpriteFactoryProduct();

            result.CharacterGameObject = animatedCharacter;
            result.CharacterSpriteRenderer = spriteRenderer;
            result.CharacterAnimatorBehavior = animatorBehavior;
            result.CharacterAudioSource = audioSource;

            return result;
        }

        public struct CharacterWithSpriteFactoryProduct
        {
            public GameObject CharacterGameObject;
            public SpriteRenderer CharacterSpriteRenderer;
            public Sprite2dAnimatorBehavior CharacterAnimatorBehavior;
            public AudioSource CharacterAudioSource;
        }        
    }
}