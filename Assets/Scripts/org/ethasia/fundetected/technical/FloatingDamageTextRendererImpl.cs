using TMPro;
using UnityEngine;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class FloatingDamageTextRendererImpl : MonoBehaviour, IFloatingDamageTextRenderer
    {

        private static FloatingDamageTextRendererImpl instance;
        public GameObject floatingDamageTextPrefab;
        public GameObject floatingPlayerDamagegTextPrefab;

        public static FloatingDamageTextRendererImpl GetInstance()
        {
            return instance;
        }

        void Awake()
        {
            instance = this;
        }

        public void RenderFloatingDamageText(string combatText, float posX, float posY)
        {
            RenderGivenFloatingDamageText(combatText, posX, posY, floatingDamageTextPrefab);
        }  

        public void RenderFloatingPlayerDamageText(string combatText, float posX, float posY)
        {
            RenderGivenFloatingDamageText(combatText, posX, posY, floatingPlayerDamagegTextPrefab);
        }             

        private void RenderGivenFloatingDamageText(string combatText, float posX, float posY, GameObject prefab)
        {
            Vector3 position = new Vector3(posX, posY, 0.0f);
            GameObject floatingDamageText = GameObject.Instantiate(prefab, position, Quaternion.identity);

            TMP_Text textComponent = floatingDamageText.GetComponentInChildren<TMP_Text>();
            textComponent.text = combatText;

            floatingDamageText.GetComponentInChildren<MeshRenderer>().sortingLayerName = "CombatText";
        }
    }
}