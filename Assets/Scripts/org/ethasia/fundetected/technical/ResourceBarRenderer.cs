using TMPro;
using UnityEngine;
using UnityEngine.UI;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class ResourceBarRenderer : MonoBehaviour, IResourceBarRenderer
    {
        private static ResourceBarRenderer instance;

        [SerializeField]
        private Image healthBarImage;

        [SerializeField]
        private Image manaBarImage;     

        [SerializeField]
        private TextMeshProUGUI healthText;

        [SerializeField]
        private TextMeshProUGUI manaText;

        public static ResourceBarRenderer GetInstance()
        {
            return instance;
        }        

        void Awake()
        {
            instance = this;
        }  

        public void FillHealthBarBasedOnHealthPercentage(float healthPercentage)
        {
            healthBarImage.fillAmount = healthPercentage;
        }      

        public void UpdateHealthText(int currentHealth, int maxHealth)
        {
            healthText.text = currentHealth + "/" + maxHealth;
        }

        public void FillManaBarBasedOnManaPercentage(float manaPercentage)
        {
            manaBarImage.fillAmount = manaPercentage;
        }

        public void UpdateManaText(int currentMana, int maxMana)
        {
            manaText.text = currentMana + "/" + maxMana;
        }
    }
}