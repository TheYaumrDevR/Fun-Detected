using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class CharacterClassMasterdataProvider : ICharacterClassMasterDataProvider
    {
        public CharacterClassMasterData CreateJockMasterData()
        {
            CharacterClassMasterData result = new CharacterClassMasterData();

            result.CharacterClass = CharacterClasses.JOCK;
            result.Intelligence = 14;
            result.Agility = 14;
            result.Strength = 32;
            result.MaxBasePhysicalDamageWithMeleeAttacks = 8;
            
            return result;
        }

        public CharacterClassMasterData CreateDuelistMasterData()
        {
            CharacterClassMasterData result = new CharacterClassMasterData();

            result.CharacterClass = CharacterClasses.DUELIST;
            result.Intelligence = 14;
            result.Agility = 23;
            result.Strength = 23;
            result.MaxBasePhysicalDamageWithMeleeAttacks = 6;            
            
            return result;
        }  

        public CharacterClassMasterData CreateBattleMageMasterData()
        {
            CharacterClassMasterData result = new CharacterClassMasterData();

            result.CharacterClass = CharacterClasses.BATTLE_MAGE;
            result.Intelligence = 23;
            result.Agility = 14;
            result.Strength = 23;
            result.MaxBasePhysicalDamageWithMeleeAttacks = 6;

            return result;
        }   

        public CharacterClassMasterData CreateZoomerMasterData()
        {
            CharacterClassMasterData result = new CharacterClassMasterData();

            result.CharacterClass = CharacterClasses.ZOOMER;
            result.Intelligence = 14;
            result.Agility = 32;
            result.Strength = 14;
            result.MaxBasePhysicalDamageWithMeleeAttacks = 5;

            return result;
        }   

        public CharacterClassMasterData CreateMagicianMasterData()
        {
            CharacterClassMasterData result = new CharacterClassMasterData();

            result.CharacterClass = CharacterClasses.MAGICIAN;
            result.Intelligence = 32;
            result.Agility = 14;
            result.Strength = 14;
            result.MaxBasePhysicalDamageWithMeleeAttacks = 5;

            return result;
        }     

        public CharacterClassMasterData CreateCuckMasterData()
        {
            CharacterClassMasterData result = new CharacterClassMasterData();

            result.CharacterClass = CharacterClasses.CUCK;
            result.Intelligence = 23;
            result.Agility = 23;
            result.Strength = 14;
            result.MaxBasePhysicalDamageWithMeleeAttacks = 5;

            return result;
        }                                    
    }
}