using System;

namespace Org.Ethasia.Fundetected.Core
{
    public class AsyncResponse<T>
    {
        private T responseObject;
        private Action<T> responseCallback;

        public void SetResponseObject(T value)
        {
            responseObject = value;

            if (null != responseCallback)
            {
                responseCallback(responseObject);
            }
        }

        public void OnResponseReceived(Action<T> callback)
        {
            responseCallback = callback;

            if (null != responseObject)
            {
                responseCallback(responseObject);
            }
        }
    }
}