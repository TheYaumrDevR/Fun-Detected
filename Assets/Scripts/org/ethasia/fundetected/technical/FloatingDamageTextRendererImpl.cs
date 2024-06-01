using TMPro;
using UnityEngine;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class FloatingDamageTextRendererImpl : MonoBehaviour, IFloatingDamageTextRenderer
    {

        private static FloatingDamageTextRendererImpl instance;
        public GameObject floatingDamageTextPrefab;
        public TMP_Text floatingDamageText;

        public static FloatingDamageTextRendererImpl GetInstance()
        {
            return instance;
        }

        void Awake()
        {
            instance = this;
        }

        public void RenderFloatingDamageText(int damageAmount, float posX, float posY)
        {
            Vector3 position = new Vector3(posX, posY, 0.0f);
            floatingDamageText.text = damageAmount.ToString();
            GameObject.Instantiate(floatingDamageTextPrefab, position, Quaternion.identity);
        }
    }
}