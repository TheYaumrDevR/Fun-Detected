namespace Org.Ethasia.Fundetected.Core
{
    public class StatsFromEquipment
    {
        public int PlusIntelligence
        {
            get;
            private set;
        }

        public int PlusAgility
        {
            get;
            private set;
        }

        public int PlusStrength
        {
            get;
            private set;
        }     

        public int PlusFireResistance
        {
            get;
            private set;
        }

        public int PlusMaximumFireResistance
        {
            get;
            private set;
        }   

        public void IncreasePlusIntelligenceBy(int value)
        {
            PlusIntelligence += value;
        }

        public void IncreasePlusAgilityBy(int value)
        {
            PlusAgility += value;
        }

        public void IncreasePlusStrengthBy(int value)
        {
            PlusStrength += value;
        }

        public void IncreasePlusFireResistanceBy(int value)
        {
            PlusFireResistance += value;
        }

        public void IncreasePlusMaximumFireResistanceBy(int value)
        {
            PlusMaximumFireResistance += value;
        }        

        public void DecreasePlusIntelligenceBy(int value)
        {
            PlusIntelligence -= value;
        }

        public void DecreasePlusAgilityBy(int value)
        {
            PlusAgility -= value;
        }

        public void DecreasePlusStrengthBy(int value)
        {
            PlusStrength -= value;
        }

        public void DecreasePlusFireResistanceBy(int value)
        {
            PlusFireResistance -= value;
        }

        public void DecreasePlusMaximumFireResistanceBy(int value)
        {
            PlusMaximumFireResistance -= value;
        }        
    }
}