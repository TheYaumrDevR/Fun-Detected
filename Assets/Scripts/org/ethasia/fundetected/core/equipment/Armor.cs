using Org.Ethasia.Fundetected.Core.Equipment.Affixes;

namespace Org.Ethasia.Fundetected.Core.Equipment
{
    public class Armor : Equipment
    {
        // TODO
        // Plate Armor types give a lot of armor, but reduce movement speed
        // Leather / Synthetic Armor types give less armor, but add movement speed. They can also have effects like "Ground effects have a chance to skip a damage tick"
        // Cloth Armor types give even less armor, but can give elemental resistances. Or Maximum ele res. Or can reserve flat mana to give additional armor.
        // There can also be a double mix of each
        // All armor has str requirement. However the lighter armor types have a lot less.

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

        public LocalArmorModifiers LocalModifiers
        {
            get;
            private set;
        }

        protected override void ApplyLocalAffixes()
        {
            foreach (EquipmentAffix prefix in prefixes)
            {
                prefix.ApplyLocalArmorEffects(LocalModifiers);
            }

            foreach (EquipmentAffix suffix in suffixes)
            {
                suffix.ApplyLocalArmorEffects(LocalModifiers);
            }
        }

        new public class Builder : Equipment.Builder
        {
            private int armorValue;
            private int movementSpeedAddend;

            public Builder SetArmorValue(int value)
            {
                armorValue = value;
                return this;
            }

            public Builder SetMovementSpeedAddend(int value)
            {
                movementSpeedAddend = value;
                return this;
            }

            public Armor Build()
            {
                Armor result = new Armor();
                result.ArmorValue = armorValue;
                result.MovementSpeedAddend = movementSpeedAddend;
                result.LocalModifiers = new LocalArmorModifiers();

                FillEquipmentFields(result);

                return result;
            }
        }
    }
}