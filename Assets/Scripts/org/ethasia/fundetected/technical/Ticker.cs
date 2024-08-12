using UnityEngine;

using Org.Ethasia.Fundetected.Interactors;

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
        }
    }
}