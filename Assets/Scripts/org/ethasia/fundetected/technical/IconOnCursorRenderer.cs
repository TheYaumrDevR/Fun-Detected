using UnityEngine;
using UnityEngine.UI;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class IconOnCursorRenderer : MonoBehaviour, IIconOnCursorRenderer
    {
        private static IconOnCursorRenderer instance;

        public Canvas parentCanvas;
        public Image icon;

        public static IconOnCursorRenderer GetInstance()
        {
            return instance;
        }

        public void ShowIcon(string imageName)
        {
            icon.sprite = Resources.Load<Sprite>(imageName);
            ScaleIconToPixelAccurate();

            icon.enabled = true;
            icon.gameObject.SetActive(true);
        }

        void Update()
        {
            if (icon.gameObject.activeSelf)
            {
                icon.transform.position = Input.mousePosition;
            }
        }

        public void HideIcon()
        {
            icon.gameObject.SetActive(false);
        }

        private void Awake()
        {
            instance = this;
            icon.SetNativeSize();
            HideIcon();
        }

        private void ScaleIconToPixelAccurate()
        {
            float scaleFactor = parentCanvas.scaleFactor;
            Sprite iconSprite = icon.sprite;

            RectTransform iconRectTransform = icon.rectTransform;
            iconRectTransform.sizeDelta = new Vector2(
                iconSprite.rect.width / scaleFactor, 
                iconSprite.rect.height / scaleFactor
            );
        }
    }
}