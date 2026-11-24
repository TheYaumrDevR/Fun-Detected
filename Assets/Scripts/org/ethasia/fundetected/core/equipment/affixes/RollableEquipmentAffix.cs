namespace Org.Ethasia.Fundetected.Core.Equipment.Affixes
{
    public abstract class RollableEquipmentAffix
    {
        public string UniqueId
        {
            get;
            protected set;
        }

        public EquipmentAffix RerolledAffix
        {
            get;
            private set;
        }

        public RollableEquipmentAffix(EquipmentAffix rerolledAffix)
        {
            this.RerolledAffix = rerolledAffix;
        }

        public RollableEquipmentAffix Clone()
        {
            RollableEquipmentAffix copy = CreateCopy();
            copy.UniqueId = UniqueId;

            return copy;
        }

        public abstract void RerollAffix();
        public abstract bool Equals(RollableEquipmentAffix other);
        protected abstract RollableEquipmentAffix CreateCopy();

        public abstract class BuilderBase<TBuilder, TAffix>
            where TBuilder : BuilderBase<TBuilder, TAffix>
            where TAffix : RollableEquipmentAffix
        {
            private string uniqueId;

            public TBuilder SetUniqueId(string id)
            {
                uniqueId = id;
                return (TBuilder) this;
            }

            public TAffix Build()
            {
                TAffix result = CreateAffix();
                result.UniqueId = uniqueId;

                return result;
            }

            protected abstract TAffix CreateAffix();
        }
    }
}