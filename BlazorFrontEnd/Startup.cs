using System;
using System.Net.Http;
using BlazorFrontEnd.Api;
using BlazorFrontEnd.Api.Cache;
using Cloudcrate.AspNetCore.Blazor.Browser.Storage;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorFrontEnd
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddStorage();
            var cacheOptions = new CacheOptions();
            services.AddSingleton(cacheOptions);
            services.AddSingleton<CacheService>();
            services.AddSingleton<ApiClient>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
