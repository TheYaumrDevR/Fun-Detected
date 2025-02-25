using UnityEngine;

namespace Org.Ethasia.Fundetected.Technical
{
    public class InteractableLabelFactory
    {
        public static GameObject CreateInteractableLabel(string labelText, string labelObjectName)
        {
            GameObject result = new GameObject(labelObjectName);
            TextMesh textMesh = result.AddComponent<TextMesh>();

            textMesh.text = labelText;
            textMesh.fontSize = 28;
            textMesh.characterSize = 0.1f;
            textMesh.color = Color.white;

            textMesh.anchor = TextAnchor.MiddleCenter;
            textMesh.alignment = TextAlignment.Center;

            Renderer textRenderer = textMesh.GetComponent<Renderer>();
            textRenderer.sortingLayerName = "IngameLabels";
            textRenderer.sortingOrder = 1;        

            GameObject backGroundQuad = AddLabelBackground(textMesh);

            // Position the background behind the text
            backGroundQuad.transform.SetParent(result.transform);
            backGroundQuad.transform.localPosition = new Vector3(0, 0, 0); // Ensure it is behind the text  

            return result;           
        }

        private static GameObject AddLabelBackground(TextMesh textMesh)
        {
            Renderer textRenderer = textMesh.GetComponent<Renderer>();
            Vector3 textSize = textRenderer.bounds.size;

            GameObject result = new GameObject("BackgroundRectangle");

            SpriteRenderer spriteRenderer = result.AddComponent<SpriteRenderer>();

            int pixelsPerUnit = 100;
            Texture2D texture = CreateBackgroundRectangleTexture(textSize, pixelsPerUnit);

            Rect rect = new Rect(0, 0, texture.width, texture.height);
            Vector2 pivot = new Vector2(0.5f, 0.5f);
            Sprite sprite = Sprite.Create(texture, rect, pivot, pixelsPerUnit);
            spriteRenderer.sprite = sprite; 

            spriteRenderer.sortingLayerName = "IngameLabels";
            spriteRenderer.sortingOrder = 0;           

            return result;       
        }

        private static Texture2D CreateBackgroundRectangleTexture(Vector3 textSize, int pixelsPerUnit)
        {
            int textureWidth = (int)((textSize.x + 0.1f) * pixelsPerUnit);
            int textureHeight = (int)(textSize.y * pixelsPerUnit);

            Texture2D result = new Texture2D(textureWidth, textureHeight);

            Color backgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.7f);
            for (int i = 0; i < textureWidth; i++)
            {
                for (int j = 0; j < textureHeight; j++)
                {
                    result.SetPixel(i, j, backgroundColor);
                }
            }

            result.Apply();

            return result;
        }
    }
}