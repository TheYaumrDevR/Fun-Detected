using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected.Interactors
{
    public struct CharacterClassMasterData
    {
        public CharacterClasses CharacterClass
        {
            get;
            set;
        }

        public int Intelligence
        {
            get;
            set;
        }

        public int Agility
        {
            get;
            set;
        }

        public int Strength
        {
            get;
            set;
        }

        public int Life
        {
            get 
            {
                return 50;
            }
        }

        public int Mana
        {
            get 
            {
                return 40;
            }
        }

        public int MinBasePhysicalDamage
        {
            get
            {
                return 2;
            }
        }

        public int MaxBasePhysicalDamage
        {
            get;
            set;
        }

        public double AttacksPerSecond
        {
            get
            {
                return 1.2f;
            }
        }        

        public int MovementSpeed
        {
            get
            {
                return 200;
            }
        }
    }
}