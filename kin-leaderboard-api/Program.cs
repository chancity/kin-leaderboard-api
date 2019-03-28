using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using kin_leaderboard_api.Entities;
using kin_leaderboard_api.Models;
using kin_leaderboard_api.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace kin_leaderboard_api
{
    public class Program
    {
        private static readonly Dictionary<string, string> DefaultConfiguration = new Dictionary<string, string>
        {
            {"ConnectionStrings_ApplicationDatabase", "server=localhost;database=application_api;uid=root;pwd=password"},
            {"Horizon_Url", "https://horizon.kinfederation.com/"},
            {"HorizonNetwork_Id", "Kin Mainnet ; December 2018" },
            {"Api_Key", "SuperSecretYo" },
            {"Swagger_Enabled", "True" },
        };

        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(DefaultConfiguration).AddEnvironmentVariables();
            IConfiguration configuration = builder.Build();

            var host = CreateWebHostBuilder(args).UseConfiguration(configuration).Build();
            DbSeed(host).Wait();
            host.Run();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseUrls("http://0.0.0.0:5000")
                .UseStartup<Startup>();
            
        public static async Task DbSeed(IWebHost host)
        {
            using (IServiceScope scope = host.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<ApplicationContext>();


                    await context.Database.EnsureCreatedAsync().ConfigureAwait(false);
                    await context.Database.MigrateAsync().ConfigureAwait(false);
                    var appService = services.GetRequiredService<AppService>();

                    try
                    {
                        var ret = await appService.Get("aggregate").ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        if (e.Message.Contains("'aggregate' not found"))
                        {
                            var epochTime = DateTimeOffset.Now.ToUnixTimeSeconds();

                            await appService.Post(new App()
                                { AppId = "aggregate", FirstSeen = epochTime, FriendlyName = "Aggregated Data", LastSeen = epochTime }).ConfigureAwait(false);
                        }
                    }
                  
                }
                catch (InvalidCastException ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    foreach (DictionaryEntry dictionaryEntry in ex.Data)
                    {
                        logger.LogError(ex, $"{dictionaryEntry.Key}={dictionaryEntry.Value}");
                    }
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
        }
    }
}
