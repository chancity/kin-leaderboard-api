using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFrontEnd.Api.Cache
{
    public class CacheException : Exception
    {
        public CacheException(string message) : base(message) { }
        public CacheException() { }
    }

    public class CacheExpiredException : CacheException
    {
        public CacheExpiredException() { }
        public CacheExpiredException(string message) : base(message) { }
    }
}
