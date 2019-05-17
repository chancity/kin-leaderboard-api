using System;
using System.Threading.Tasks;
using Cloudcrate.AspNetCore.Blazor.Browser.Storage;
using Newtonsoft.Json;

namespace BlazorFrontEnd.Api.Cache
{
    public class CacheService
    {
        private readonly LocalStorage _storage;
        private readonly CacheOptions _cacheOptions;
        public CacheService(LocalStorage storage, CacheOptions cacheOptions = null)
        {
            _storage = storage;
            _cacheOptions = cacheOptions ?? new CacheOptions();
        }

        public bool IsBlacklisted(string key)
        {
            return _cacheOptions.Blacklist.Contains(key);
            
        }
        public bool TryGet<T>(string key, out T value) where T : class
        {
            value = null;
            if (IsBlacklisted(key))
            {
                return false;
            }

            try
            {
                var cachedResponse = _storage.GetItem<CachedResponse<T>>(key);
                if (DateTimeOffset.UtcNow >= cachedResponse.Expires)
                {
                    throw new CacheExpiredException();
                }

                value = cachedResponse.Data;
                return true;
            }
            catch (Exception e)
            {
               Console.WriteLine(e.Message);
               return false;
            }
        }

        public bool TrySet<T>(string key, T value) where T: class
        {
            if (IsBlacklisted(key))
            {
                return false;
            }
            try
            {
                var cachedResponse = new CachedResponse<T>(value, DateTimeOffset.UtcNow.Add(_cacheOptions.TTL));
                _storage.SetItem(key, JsonConvert.SerializeObject(cachedResponse));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
