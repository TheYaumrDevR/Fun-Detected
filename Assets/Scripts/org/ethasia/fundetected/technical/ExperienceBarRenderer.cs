using TMPro;
using UnityEngine;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical
{
    public class ExperienceBarRenderer : MonoBehaviour, IExperienceBarRenderer
    {
        private static ExperienceBarRenderer instance;

        [SerializeField]
        private RectTransform experienceBarFillRect;

        [SerializeField]
        private RectTransform experienceBarFullWidthReference;

        [SerializeField]
        private float leftInset = 4f;

        [SerializeField]
        private float rightInset = 5f;

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
            levelText.text = currentLevel.ToString();
        }
    }
}