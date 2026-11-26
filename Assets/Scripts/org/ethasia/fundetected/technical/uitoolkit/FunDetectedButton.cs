using UnityEngine.UIElements;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{
    [UxmlElement]
    public partial class FunDetectedButton : Button
    {
        private string labelKey;

        [UxmlAttribute]
        public string LabelKey
        {
            get
            {
                return labelKey;
            }

            set
            {
                labelKey = value;

                if (!string.IsNullOrEmpty(value))
                {
                    var localizationGateway = new DictionaryBasedLocalizationGateway();
                    text = localizationGateway.GetLocalizedString(value);
                }
            }
        }
    }
}