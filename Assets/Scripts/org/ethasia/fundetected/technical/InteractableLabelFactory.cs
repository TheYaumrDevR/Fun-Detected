using UnityEngine;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class InteractableLabelFactory
    {
        private const int DEFAULT_FONT_SIZE = 28;
        private const int PIXELS_PER_UNIT = 100;
        private const float BORDER_THICKNESS_IN_UNITS = 0.02f;

        private static readonly Color DEFAULT_BACKGROUND_COLOR = new Color(0.0f, 0.0f, 0.0f, 0.7f);

        public static GameObject CreateInteractableLabel(string labelText, string labelObjectName)
        {
            LabelStyle style = new LabelStyle(DEFAULT_FONT_SIZE, Color.white, DEFAULT_BACKGROUND_COLOR, Color.clear);
            return CreateLabel(labelText, labelObjectName, style);
        }

        public static GameObject CreateInteractableLabel(DroppedItemRenderProxy renderData, string labelObjectName)
        {
            LabelStyle style = new LabelStyle(
                renderData.ItemLabelFontSize > 0 ? renderData.ItemLabelFontSize : DEFAULT_FONT_SIZE,
                CreateColorFromHtmlStringOrElse(renderData.ItemLabelTextColor, Color.white),
                CreateColorFromHtmlStringOrElse(renderData.ItemLabelBackgroundColor, DEFAULT_BACKGROUND_COLOR),
                CreateColorFromHtmlStringOrElse(renderData.ItemLabelBorderColor, Color.clear));

            return CreateLabel(renderData.ItemName, labelObjectName, style);
        }

        private static GameObject CreateLabel(string labelText, string labelObjectName, LabelStyle labelStyle)
        {
            GameObject result = new GameObject(labelObjectName);
            TextMesh textMesh = result.AddComponent<TextMesh>();

            textMesh.text = labelText;
            textMesh.fontSize = labelStyle.FontSize;
            textMesh.characterSize = 0.1f;
            textMesh.color = labelStyle.TextColor;

            textMesh.anchor = TextAnchor.MiddleCenter;
            textMesh.alignment = TextAlignment.Center;

            Renderer textRenderer = textMesh.GetComponent<Renderer>();
            textRenderer.sortingLayerName = "IngameLabels";
            textRenderer.sortingOrder = 2;

            Vector3 textSize = textRenderer.bounds.size;

            if (labelStyle.BorderColor.a > 0f)
            {
                RectangleCreationProperties borderSpecification = new RectangleCreationProperties(textSize, BORDER_THICKNESS_IN_UNITS, labelStyle.BorderColor);
                GameObject border = CreateRectangle("BorderRectangle", borderSpecification, 0);
                border.transform.SetParent(result.transform);
                border.transform.localPosition = Vector3.zero;
            }

            RectangleCreationProperties backgroundSpecification = new RectangleCreationProperties(textSize, 0f, labelStyle.BackgroundColor);
            GameObject background = CreateRectangle("BackgroundRectangle", backgroundSpecification, 1);
            background.transform.SetParent(result.transform);
            background.transform.localPosition = Vector3.zero;

            return result;
        }

        private static Color CreateColorFromHtmlStringOrElse(string htmlColor, Color fallback)
        {
            if (!string.IsNullOrEmpty(htmlColor) && ColorUtility.TryParseHtmlString(htmlColor, out Color parsed))
            {
                return parsed;
            }

            return fallback;
        }

        private static GameObject CreateRectangle(string objectName, RectangleCreationProperties specification, int sortingOrder)
        {
            GameObject result = new GameObject(objectName);

            SpriteRenderer spriteRenderer = result.AddComponent<SpriteRenderer>();

            Texture2D texture = CreateRectangleTexture(specification, PIXELS_PER_UNIT);

            Rect spriteRect = new Rect(0, 0, texture.width, texture.height);
            Vector2 pivot = new Vector2(0.5f, 0.5f);
            spriteRenderer.sprite = Sprite.Create(texture, spriteRect, pivot, PIXELS_PER_UNIT);

            spriteRenderer.sortingLayerName = "IngameLabels";
            spriteRenderer.sortingOrder = sortingOrder;

            return result;
        }

        private static Texture2D CreateRectangleTexture(RectangleCreationProperties specification, int pixelsPerUnit)
        {
            int textureWidth = (int)((specification.TextSize.x + 0.1f + specification.ExtraSizeInUnits * 2) * pixelsPerUnit);
            int textureHeight = (int)((specification.TextSize.y + specification.ExtraSizeInUnits * 2) * pixelsPerUnit);

            Texture2D result = new Texture2D(textureWidth, textureHeight);

            Color[] pixels = new Color[textureWidth * textureHeight];
            for (int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = specification.Color;
            }

            result.SetPixels(pixels);
            result.Apply();

            return result;
        }

        private readonly struct LabelStyle
        {
            public int FontSize { get; }
            public Color TextColor { get; }
            public Color BackgroundColor { get; }
            public Color BorderColor { get; }

            public LabelStyle(int fontSize, Color textColor, Color backgroundColor, Color borderColor)
            {
                FontSize = fontSize;
                TextColor = textColor;
                BackgroundColor = backgroundColor;
                BorderColor = borderColor;
            }
        }

        private readonly struct RectangleCreationProperties
        {
            public Vector3 TextSize { get; }
            public float ExtraSizeInUnits { get; }
            public Color Color { get; }

            public RectangleCreationProperties(Vector3 textSize, float extraSizeInUnits, Color color)
            {
                TextSize = textSize;
                ExtraSizeInUnits = extraSizeInUnits;
                Color = color;
            }
        }
    }
}