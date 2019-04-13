using System;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorFrontEnd
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            var httpClient = app.Services.GetRequiredService<HttpClient>();
            httpClient.BaseAddress = new Uri("https://leader-board-api.kinexplorer.com");

            app.AddComponent<App>("app");
        }
    }
}
