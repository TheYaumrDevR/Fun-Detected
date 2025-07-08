namespace Org.Ethasia.Fundetected.Core.Equipment
{
    public class Jewelry : Equipment
    {
        protected override void ApplyLocalAffixes() { }

        new public class Builder : Equipment.Builder
        {
            public Jewelry Build()
            {
                Jewelry result = new Jewelry();
                FillEquipmentFields(result);

                return result;
            }
        } 
    }
}