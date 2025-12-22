using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors.Initialization;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{
    public class CharacterClassMasterDataProviderMock : ICharacterClassMasterDataProvider
    {
        public CharacterClassMasterData CreateJockMasterData()
        {
            CharacterClassMasterData result = new CharacterClassMasterData();

            result.CharacterClass = CharacterClasses.JOCK;
            result.Intelligence = 14;
            result.Agility = 14;
            result.Strength = 32;
            result.MaxRightHandBasePhysicalDamageWithMeleeAttacks = 8;
            
            return result;
        }

        public CharacterClassMasterData CreateDuelistMasterData()
        {
            CharacterClassMasterData result = new CharacterClassMasterData();

            result.CharacterClass = CharacterClasses.DUELIST;
            result.Intelligence = 14;
            result.Agility = 23;
            result.Strength = 23;
            result.MaxRightHandBasePhysicalDamageWithMeleeAttacks = 6;

            return result;
        }  

        public CharacterClassMasterData CreateBattleMageMasterData()
        {
            CharacterClassMasterData result = new CharacterClassMasterData();

            result.CharacterClass = CharacterClasses.BATTLE_MAGE;
            result.Intelligence = 23;
            result.Agility = 14;
            result.Strength = 23;
            result.MaxRightHandBasePhysicalDamageWithMeleeAttacks = 6;

            return result;
        }   

        public CharacterClassMasterData CreateZoomerMasterData()
        {
            CharacterClassMasterData result = new CharacterClassMasterData();

            result.CharacterClass = CharacterClasses.ZOOMER;
            result.Intelligence = 14;
            result.Agility = 32;
            result.Strength = 14;
            result.MaxRightHandBasePhysicalDamageWithMeleeAttacks = 5;

            return result;
        }   

        public CharacterClassMasterData CreateMagicianMasterData()
        {
            CharacterClassMasterData result = new CharacterClassMasterData();

            result.CharacterClass = CharacterClasses.MAGICIAN;
            result.Intelligence = 32;
            result.Agility = 14;
            result.Strength = 14;
            result.MaxRightHandBasePhysicalDamageWithMeleeAttacks = 5;

            return result;
        }     

        public CharacterClassMasterData CreateCuckMasterData()
        {
            CharacterClassMasterData result = new CharacterClassMasterData();

            result.CharacterClass = CharacterClasses.CUCK;
            result.Intelligence = 23;
            result.Agility = 23;
            result.Strength = 14;
            result.MaxRightHandBasePhysicalDamageWithMeleeAttacks = 5;

            return result;
        }  
    }
}