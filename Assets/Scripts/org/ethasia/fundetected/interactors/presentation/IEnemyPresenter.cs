using System.Collections.Generic;

namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public interface IEnemyPresenter
    {
        void PresentEnemies(List<EnemyRenderData> renderData);
        void PresentNothing();
    }
}