namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public interface IFloatingDamageTextRenderer
    {
        void RenderFloatingDamageText(string combatText, float posX, float posY);
        void RenderFloatingPlayerDamageText(string combatText, float posX, float posY);
    }
}