using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using kin_leaderboard_api.Authentication;
using kin_leaderboard_api.Entities;
using kin_leaderboard_api.Exceptions;
using kin_leaderboard_api.Models;
using kin_leaderboard_api.Repository;
using kin_leaderboard_api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using Operation = Swashbuckle.AspNetCore.Swagger.Operation;

namespace kin_leaderboard_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var isProduction = Configuration["ASPNETCORE_ENVIRONMENT"].Equals("Production");

            services.AddTransient<OperationsService>();
            services.AddTransient<AppService>();

            services.AddAutoMapper(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<AppOperationDto, Operation>().ReverseMap();
                cfg.CreateMap<AppDto, App>().ReverseMap();
                cfg.CreateMap<AppInfoDto, AppInfo>().ReverseMap();
                cfg.CreateMap<AppWalletDto, AppWallet>().ReverseMap();
                
            });
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });
            services.AddSingleton(Configuration);
            services.AddDbContext<ApplicationContext>(options =>
                options.UseMySql(Configuration["ConnectionStrings_ApplicationDatabase"]));


                services.AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = "CustomScheme";
                        options.DefaultChallengeScheme = "CustomScheme";
                    })
                    .AddCustomAuth(o =>
                    {
                        o.ApiKey = Configuration["Api_Key"];
                    });
            


            if (bool.TryParse(Configuration["Swagger_Enabled"], out var ret) && ret)
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "Kin Leader Board API", Version = "v1" });
                    c.DescribeAllEnumsAsStrings();
                    c.DescribeStringEnumsInCamelCase();


                        c.AddSecurityDefinition("Bearer",
                            new ApiKeyScheme
                            {
                                In = "header",
                                Description = "Please enter API key with Bearer into field",
                                Name = "Authorization",
                                Type = "apiKey"
                            });

                        c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                        {
                            {"Bearer", Enumerable.Empty<string>()},
                        });
                    
                });
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseHttpStatusCodeExceptionMiddleware();
                // app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpStatusCodeExceptionMiddleware();
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            if (bool.TryParse(Configuration["Swagger_Enabled"], out var ret) && ret)
            {
                app.UseStaticFiles();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kin Leader Board API");

                });

            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}");
            });
        }
    }
}