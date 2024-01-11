using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Interactors
{
    public interface IEnemyPresenter
    {
        void PresentEnemies(List<EnemyRenderData> renderData);
    }
}