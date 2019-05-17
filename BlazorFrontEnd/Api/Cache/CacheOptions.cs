using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFrontEnd.Api.Cache
{
    public class CacheOptions
    {
        public TimeSpan TTL { get; }  = TimeSpan.FromMinutes(10);
        public HashSet<string> Blacklist { get; } = new HashSet<string>();

        public CacheOptions()
        {
        }
        public CacheOptions(TimeSpan ttl)
        {
            TTL = ttl;
        }
        public CacheOptions(HashSet<string> blackList)
        {
            Blacklist = blackList;
        }
        public CacheOptions(TimeSpan ttl, HashSet<string> blackList)
        {
            TTL = ttl;
            Blacklist = blackList;
        }
    }
}
