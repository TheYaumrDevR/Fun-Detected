using UnityEngine;

namespace Org.Ethasia.Fundetected.Technical.Animation
{
    public class SpriteMaterialApplier
    {
        private SpriteRenderer spriteRenderer;
        private Material defaultMaterial;

        public SpriteMaterialApplier(SpriteRenderer spriteRenderer)
        {
            this.spriteRenderer = spriteRenderer;
            defaultMaterial = spriteRenderer.sharedMaterial;
        }

        public void Apply(string materialName)
        {
            if (string.IsNullOrEmpty(materialName))
            {
                spriteRenderer.sharedMaterial = defaultMaterial;
                return;
            }

            Material material = Resources.Load<Material>(materialName);

            if (null == material)
            {
                Debug.LogWarning("Material not found for animation: " + materialName);
                spriteRenderer.sharedMaterial = defaultMaterial;
                return;
            }

            spriteRenderer.sharedMaterial = material;
        }
    }
}