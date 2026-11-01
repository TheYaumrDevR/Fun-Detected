using UnityEngine;
using UnityEngine.UIElements;

using Org.Ethasia.Fundetected.Ioadapters.Presentation;
using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{
    [UxmlElement]
    public partial class DeathScreenOverlay : VisualElement
    {
        private const string OVERLAY_NAME = "death-screen-overlay";
        private const string TITLE_LABEL_NAME = "death-screen-title";
        private const string CONTINUE_HINT_LABEL_NAME = "death-screen-hint";
        private const string LOSS_HINT_LABEL_NAME = "death-screen-loss-hint";

        private const string OVERLAY_VISIBLE_CLASS = "death-screen-overlay--visible";

        private const string TITLE_KEY = "death-screen-title";
        private const string CONTINUE_HINT_KEY = "death-screen-continue-hint";
        private const string LOSS_HINT_KEY = "death-screen-loss-hint";

        private readonly ILocalizationGateway localizationGateway = TechnicalFactory.GetInstance().CreateLocalizationGateway();

        private VisualElement overlay;
        private Label titleLabel;
        private Label continueHintLabel;
        private Label lossHintLabel;

        public DeathScreenOverlay()
        {
            var visualTree = Resources.Load<VisualTreeAsset>("UIElements/DeathScreenOverlay");
            visualTree.CloneTree(this);

            overlay = this.Q<VisualElement>(OVERLAY_NAME);
            titleLabel = this.Q<Label>(TITLE_LABEL_NAME);
            continueHintLabel = this.Q<Label>(CONTINUE_HINT_LABEL_NAME);
            lossHintLabel = this.Q<Label>(LOSS_HINT_LABEL_NAME);

            SetStaticTexts();
        }

        public void Show(int lostExperiencePoints)
        {
            if (null != lossHintLabel)
            {
                string lossHintTemplate = localizationGateway.GetLocalizedString(LOSS_HINT_KEY);
                lossHintLabel.text = TechnicalUtils.ReplacePlaceHoldersInText(lossHintTemplate, lostExperiencePoints.ToString());
            }

            overlay?.AddToClassList(OVERLAY_VISIBLE_CLASS);
        }

        public void Hide()
        {
            overlay?.RemoveFromClassList(OVERLAY_VISIBLE_CLASS);
        }

        private void SetStaticTexts()
        {
            if (null != titleLabel)
            {
                titleLabel.text = localizationGateway.GetLocalizedString(TITLE_KEY);
            }

            if (null != continueHintLabel)
            {
                continueHintLabel.text = localizationGateway.GetLocalizedString(CONTINUE_HINT_KEY);
            }
        }
    }
}