namespace Org.Ethasia.Fundetected.Core.Map
{
    public interface ITile
    {
        string Id
        {
            get;
        }

        int StartX
        {
            get;
        }

        int StartY
        {
            get;
        }

        int Width
        {
            get;
        }

        int Height
        {
            get;
        }
    }
}