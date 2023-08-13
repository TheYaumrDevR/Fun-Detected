using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class PlayerSkillInteractor
    {
        public void ExecutePrimaryPlayerAction()
        {
            Area activeArea = Area.ActiveArea;
            Enemy enemyHit = activeArea.GetEnemyHit();

            if (null != enemyHit)
            {
                activeArea.Player.AutoAttack(enemyHit);
            }
        }
    }
}