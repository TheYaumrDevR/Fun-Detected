using Org.Ethasia.Fundetected.Interactors.Combat;

namespace Org.Ethasia.Fundetected.Interactors.Initialization
{
    public struct CharacterCreationMasterData
    {
        public CharacterClassMasterData CharacterClassMasterData
        {
            get;
            set;
        }

        public MeleeHitArcMasterData MeleeHitArcMasterData
        {
            get;
            set;
        }

        public BoundingBoxMasterData BoundingBoxMasterData
        {
            get;
            set;
        }
    }
}