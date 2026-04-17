using Org.Ethasia.Fundetected.Core.Equipment;

namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public interface IUiRenderer
    {
        void RenderEquippedItemInInventoryWindow(EquipmentSlotPositions slotPosition, EquipmentSlotRenderContext renderContext);
    }
}