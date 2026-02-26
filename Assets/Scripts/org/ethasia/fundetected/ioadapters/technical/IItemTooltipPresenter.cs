using Org.Ethasia.Fundetected.Technical.UIToolkit;

namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public interface IItemTooltipPresenter
    {
        void ShowItemTooltip(NormalItemTooltip.TooltipDisplayInformation displayInformation);
        void RepositionItemTooltip(float posX, float posY);
        void HideItemTooltip();
    }
}