namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public abstract class RollableEquipmentAffix
    {
        public EquipmentAffix RerolledAffix
        {
            get;
            private set;
        }

        public RollableEquipmentAffix(EquipmentAffix rerolledAffix)
        {
            this.RerolledAffix = rerolledAffix;
        }

        public abstract void RerollAffix();
        public abstract bool Equals(RollableEquipmentAffix other);
        public abstract RollableEquipmentAffix Clone();
    }
}