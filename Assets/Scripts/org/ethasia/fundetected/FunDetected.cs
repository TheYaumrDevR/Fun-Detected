using UnityEngine;

using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected
{
    /**
     * Fun Detected - The Blasting ARPG (BRPG)
     */
    public class FunDetected : MonoBehaviour
    {
        void Awake()
        {
            Dependencies.Inject();
        }
    } 
}