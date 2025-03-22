namespace Org.Ethasia.Fundetected.Core.Map
{
    public interface IEnvironmentInteractionInteractor
    {
        void PlayHealingWellUseSound(string playerCharacterName);
        void ActivateMapSelection(string mapName);
    }
}