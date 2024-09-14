using System;

namespace Org.Ethasia.Fundetected.Core
{
    public class AsyncResponse<T>
    {
        public bool ResponseReceived
        {
            get;
            private set;
        }

        private T responseObject;
        private Action<T> responseCallback;

        public void SetResponseObject(T value)
        {
            responseObject = value;
            ResponseReceived = true;

            if (null != responseCallback)
            {
                responseCallback(responseObject);
            }
        }

        public void OnResponseReceived(Action<T> callback)
        {
            responseCallback = callback;

            if (ResponseReceived)
            {
                responseCallback(responseObject);
            }
        }
    }
}