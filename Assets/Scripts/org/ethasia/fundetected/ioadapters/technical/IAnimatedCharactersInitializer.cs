using UnityEngine;

namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public interface IAnimatedCharactersInitializer
    {
        void InitializeAnimatedCharacter(GameObjectProxy animatedCharacter);
        void ClearAnimatedCharacters();
    }
}