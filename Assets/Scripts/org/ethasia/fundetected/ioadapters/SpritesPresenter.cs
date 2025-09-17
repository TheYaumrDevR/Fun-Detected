namespace Org.Ethasia.Fundetected.Ioadapters
{
    public abstract class SpritesPresenter
    {
        protected float ConvertMapPositionToScreenPosition(int mapPosition)
        {
            return mapPosition / 10.0f;
        }
    }
}