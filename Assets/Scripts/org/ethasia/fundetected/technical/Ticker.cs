using UnityEngine;

using Org.Ethasia.Fundetected.Core.Map;
using Org.Ethasia.Fundetected.Interactors;
using Org.Ethasia.Fundetected.Interactors.Combat;

namespace Org.Ethasia.Fundetected.Technical
{
    public class Ticker : MonoBehaviour
    {
        private PlayerRepeatedUpdateInteractor playerRepeatedUpdateInteractor;
        private EnemyRepeatedUpdateInteractor enemyRepeatedUpdateInteractor;

        public Ticker()
        {
            playerRepeatedUpdateInteractor = new PlayerRepeatedUpdateInteractor();
            enemyRepeatedUpdateInteractor = new EnemyRepeatedUpdateInteractor();
        }

        void Update()
        {
            playerRepeatedUpdateInteractor.Update(Time.deltaTime);
            enemyRepeatedUpdateInteractor.Update(Time.deltaTime);

            if (Area.ActiveArea != null)
            {
                Area.ActiveArea.Update(Time.deltaTime);
            }
        }
    }
}