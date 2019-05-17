using System;

namespace BlazorFrontEnd.Api.Cache
{
    public class CachedResponse<T>
    {
        public DateTimeOffset Expires { get; private set; }
        public T Data { get; private set; }

        private CachedResponse()
        {

        }
        public CachedResponse(T data, DateTimeOffset expires)
        {
            Data = data;
            Expires = expires;
        }
    }
}
