using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class EnemyRepeatedUpdateInteractor
    {
        public void Update(double deltaTime)
        {
            Area activeArea = Area.ActiveArea;

            foreach (Enemy spawnedEnemy in activeArea.Enemies)
            {
                spawnedEnemy.Update(deltaTime, activeArea);
            }            
        }
    }   
}