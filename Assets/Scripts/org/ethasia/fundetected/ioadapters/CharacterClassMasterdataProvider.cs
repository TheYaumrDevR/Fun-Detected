using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class CharacterClassMasterdataProvider
    {
        public CharacterClassMasterData CreateStrongManMasterData()
        {
            CharacterClassMasterData result = new CharacterClassMasterData();

            result.CharacterClass = CharacterClasses.STRONGMAN;
            result.Intelligence = 14;
            result.Dexterity = 14;
            result.Strength = 32;
            result.Life = 66;
            result.Mana = 47;
            
            return result;
        }

        public CharacterClassMasterData CreateDuelistMasterData()
        {
            CharacterClassMasterData result = new CharacterClassMasterData();

            result.CharacterClass = CharacterClasses.DUELIST;
            result.Intelligence = 14;
            result.Dexterity = 23;
            result.Strength = 23;
            result.Life = 62;
            result.Mana = 47;
            
            return result;
        }  

        public CharacterClassMasterData CreateBattleMageMasterData()
        {
            CharacterClassMasterData result = new CharacterClassMasterData();

            result.CharacterClass = CharacterClasses.BATTLE_MAGE;
            result.Intelligence = 23;
            result.Dexterity = 14;
            result.Strength = 23;
            result.Life = 62;
            result.Mana = 52;
            
            return result;
        }   

        public CharacterClassMasterData CreateZoomerMasterData()
        {
            CharacterClassMasterData result = new CharacterClassMasterData();

            result.CharacterClass = CharacterClasses.ZOOMER;
            result.Intelligence = 14;
            result.Dexterity = 32;
            result.Strength = 14;
            result.Life = 57;
            result.Mana = 47;
            
            return result;
        }   

        public CharacterClassMasterData CreateMagicianMasterData()
        {
            CharacterClassMasterData result = new CharacterClassMasterData();

            result.CharacterClass = CharacterClasses.MAGICIAN;
            result.Intelligence = 32;
            result.Dexterity = 14;
            result.Strength = 14;
            result.Life = 57;
            result.Mana = 56;
            
            return result;
        }     

        public CharacterClassMasterData CreateCuckMasterData()
        {
            CharacterClassMasterData result = new CharacterClassMasterData();

            result.CharacterClass = CharacterClasses.CUCK;
            result.Intelligence = 23;
            result.Dexterity = 23;
            result.Strength = 14;
            result.Life = 57;
            result.Mana = 52;
            
            return result;
        }                                    
    }
}