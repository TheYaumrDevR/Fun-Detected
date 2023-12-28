using System;

namespace Org.Ethasia.Fundetected.Interactors
{
    public class AssetLoadFailureException : Exception 
    {
        public AssetLoadFailureException(string message) : base(message) {}
    }
}