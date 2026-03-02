using System;

namespace Org.Ethasia.Fundetected.Interactors
{
    public interface IEnumLocalizationGateway
    {
        string GetLocalizedEnumString<T>(T enumValue) where T : Enum;
    }
}