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

        public int Armor
        {
            get;
            private set;
        }

        public int MovementSpeedAddend
        {
            get;
            private set;
        }
    }
}