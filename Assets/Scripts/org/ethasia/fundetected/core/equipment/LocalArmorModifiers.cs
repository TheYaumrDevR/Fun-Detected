namespace Org.Ethasia.Fundetected.Core.Equipment
{
    public class LocalArmorModifiers
    {
        public int IncreasedArmorInPercent
        {
            get;
            private set;
        }

        public void IncreaseIncreasedArmorInPercentBy(int value)
        {
            IncreasedArmorInPercent += value;
        }

        public void DecreaseIncreasedArmorInPercentBy(int value)
        {
            IncreasedArmorInPercent -= value;
        }
    }
}