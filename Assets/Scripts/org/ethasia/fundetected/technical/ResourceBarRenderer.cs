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
    }
}