using TMPro;
using UnityEngine;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class ExperienceBarRenderer : MonoBehaviour, IExperienceBarRenderer
    {
        private static ExperienceBarRenderer instance;

        private float leftInset = 4f;
        private float rightInset = 32f;

        [SerializeField]
        private RectTransform experienceBarFillRect;

        [SerializeField]
        private RectTransform experienceBarFullWidthReference;

        [SerializeField]
        private TextMeshProUGUI levelText;

        public static ExperienceBarRenderer GetInstance()
        {
            return instance;
        }

        void Awake()
        {
            instance = this;
        }

        public void FillExperienceBarBasedOnExperiencePercentage(float experiencePercentage)
        {
            float maxFillWidth = experienceBarFullWidthReference.rect.width - leftInset - rightInset;
            float targetWidth = maxFillWidth * experiencePercentage;

            experienceBarFillRect.sizeDelta = new Vector2(targetWidth, experienceBarFillRect.sizeDelta.y);
        }

        public void UpdateLevelText(int currentLevel)
        {
            // levelText.text = currentLevel.ToString();
        }
    }
}