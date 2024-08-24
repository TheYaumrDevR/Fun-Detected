using System;

namespace Org.Ethasia.Fundetected.Core
{
    public class AsyncResponse<T>
    {
        private bool responseReceived;
        private T responseObject;
        private Action<T> responseCallback;

        public void SetResponseObject(T value)
        {
            responseObject = value;
            responseReceived = true;

            if (null != responseCallback)
            {
                responseCallback(responseObject);
            }
        }

        public void OnResponseReceived(Action<T> callback)
        {
            responseCallback = callback;

            if (responseReceived)
            {
                responseCallback(responseObject);
            }
        }
    }
}