using UnityEngine;
using UnityEngine.UI;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class IconOnCursorRenderer : MonoBehaviour, IIconOnCursorRenderer
    {
        private static IconOnCursorRenderer instance;

        public Image icon;

        public static IconOnCursorRenderer GetInstance()
        {
            return instance;
        }

        public void ShowIcon(string imageName)
        {
            icon.sprite = Resources.Load<Sprite>(imageName);
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
            HideIcon();
        }
    }
}