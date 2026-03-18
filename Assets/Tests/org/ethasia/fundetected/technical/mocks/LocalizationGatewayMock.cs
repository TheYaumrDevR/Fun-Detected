using Org.Ethasia.Fundetected.Ioadapters.Presentation;

namespace Org.Ethasia.Fundetected.Technical.Mocks
{
    public class LocalizationGatewayMock : ILocalizationGateway
    {
        public string GetLocalizedString(string key)
        {
            return key; 
        }
    }
}