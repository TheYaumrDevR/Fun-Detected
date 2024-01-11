using System.Collections.Generic;
using UnityEngine;

using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class RealEnemiesPresenter : IEnemyPresenter
    {
        public void PresentEnemies(List<EnemyRenderData> renderData)
        {
            foreach (EnemyRenderData enemyRenderData in renderData)
            {
                GameObject enemy = new GameObject("Enemy" + enemyRenderData.EnemyId);
                enemy.transform.position = new Vector3(enemyRenderData.PositionX / 10.0f, enemyRenderData.PositionY / 10.0f, 0f);
                enemy.transform.localScale = new Vector3(enemyRenderData.WidthX / 10.0f, enemyRenderData.WidthY  / 10.0f, 0f); // Replace with your desired scale
            }
        }
    }
}