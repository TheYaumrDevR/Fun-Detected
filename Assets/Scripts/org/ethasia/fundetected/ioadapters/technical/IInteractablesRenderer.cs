namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public interface IInteractablesRenderer
    {
        void ClearRenderedInteractables();
        void RenderInteractable(InteractableRenderProxy renderData);
    }
}