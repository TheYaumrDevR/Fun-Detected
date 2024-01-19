using System.Collections.Generic;

using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{
    public class EnemiesPresenterMock : IEnemyPresenter
    {
        private static List<EnemyRenderData> presentedEnemiesRenderData;

        public static List<EnemyRenderData> GetPresentedEnemiesRenderData()
        {
            return presentedEnemiesRenderData;
        }

        public void PresentEnemies(List<EnemyRenderData> renderData) 
        {
            presentedEnemiesRenderData = renderData;
        }
    }
}