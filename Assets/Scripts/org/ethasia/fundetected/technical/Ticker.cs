using UnityEngine;

using Org.Ethasia.Fundetected.Interactors;

namespace Org.Ethasia.Fundetected.Technical
{
    public class Ticker : MonoBehaviour
    {
        private PlayerRepeatedUpdateInteractor playerRepeatedUpdateInteractor;

        public Ticker()
        {
            playerRepeatedUpdateInteractor = new PlayerRepeatedUpdateInteractor();
        }

        void Update()
        {
            playerRepeatedUpdateInteractor.Update(Time.deltaTime);
        }
    }
}