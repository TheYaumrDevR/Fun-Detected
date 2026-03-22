using System;

using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Technical.Mocks
{
    public class EnumLocalizationGatewayMock : IEnumLocalizationGateway
    {
        public string GetLocalizedEnumString<T>(T enumValue) where T : Enum
        {
            return enumValue.ToString();
        }
    }
}