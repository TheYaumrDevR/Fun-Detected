namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public struct ArmorPresentationContext
    {
        public int ArmorValue
        {
            get;
            private set;
        }

        public int MovementSpeedAddend
        {
            get;
            private set;
        }

        public class Builder
        {
            private ArmorPresentationContext result;

            public Builder WithArmorValue(int value)
            {
                result.ArmorValue = value;
                return this;
            }

            public Builder WithMovementSpeedAddend(int value)
            {
                result.MovementSpeedAddend = value;
                return this;
            }

            public ArmorPresentationContext Build()
            {
                return result;
            }
        }
    }
}