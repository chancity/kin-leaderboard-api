using System.Net.Http;
using System.Threading.Tasks;
using BlazorFrontEnd.Api.Cache;
using Microsoft.AspNetCore.Components;

namespace BlazorFrontEnd.Api
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly CacheService _cacheService;
        private readonly bool _cacheEnabled;
        public ApiClient(HttpClient httpClient, CacheService cacheService = null)
        {
            _httpClient = httpClient;
            _cacheService = cacheService;
            _cacheEnabled = _cacheService != null;
        }

        public async Task<T> GetJsonAsync<T>(string path) where T : class
        {
           
            if (_cacheEnabled && _cacheService.TryGet(path, out T value))
            {
                return value;
            }

            value = await _httpClient.GetJsonAsync<T>(path).ConfigureAwait(false);

            if (_cacheEnabled)
            {
                _cacheService.TrySet(path, value);
            }
           
            return value;
        }


    }
}
