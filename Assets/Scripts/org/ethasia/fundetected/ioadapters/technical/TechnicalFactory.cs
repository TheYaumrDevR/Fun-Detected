namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public abstract class TechnicalFactory
    {
        private static TechnicalFactory instance;

        public static void SetInstance(TechnicalFactory value)
        {
            instance = value;
        }

        public static TechnicalFactory GetInstance()
        {
            return instance;
        } 

        public abstract XmlFiles CreateXmlFiles();
        public abstract IAnimatedCharactersRenderer GetEnemyRendererInstance();
        public abstract IAnimatedCharactersRenderer GetPlayerCharacterRendererInstance();    
        public abstract IFloatingDamageTextRenderer GetFloatingDamageTextRendererInstance();   
    }
}