using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using kin_leaderboard_api.Authentication;
using kin_leaderboard_api.Entities;
using kin_leaderboard_api.Exceptions;
using kin_leaderboard_api.Services;
using kin_leaderboard_api.Services.Abstract;
using kin_leaderboard_frontend.Shared.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace kin_leaderboard_api
{
    public class Startup
    {
        private const string AllOriginPolicyName = "_AllOriginPolicy";

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            bool isProduction = Configuration["ASPNETCORE_ENVIRONMENT"].Equals("Production");

            services.AddTransient<AppService>();
            services.AddTransient<AppMetricService>();
            services.AddTransient<UserWalletService>();
            services.AddTransient<AbstractService<AppOperationEntity, Operation, long>>();
            services.AddTransient<AbstractService<PagingTokenEntity, PagingToken, string>>();

            services.AddAutoMapper(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<AppOperationEntity, Operation>().ReverseMap();
                cfg.CreateMap<AppEntity, App>().ReverseMap();
                cfg.CreateMap<AppInfoEntity, AppInfo>().ReverseMap();
                cfg.CreateMap<PagingTokenEntity, PagingToken>().ReverseMap();
                cfg.CreateMap<AppWalletEntity, AppWallet>().ReverseMap();
                cfg.CreateMap<AppMetricEntity, AppMetric>().ReverseMap();
                cfg.CreateMap<UserWalletEntity, UserWallet>().ReverseMap();
                cfg.CreateMap<AppPaymentEntity, AppPayment>().ReverseMap();
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
                .AddCustomAuth(o => { o.ApiKey = Configuration["Api_Key"]; });

            services.AddCors(options =>
            {
                options.AddPolicy(AllOriginPolicyName,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });


            if (bool.TryParse(Configuration["Swagger_Enabled"], out bool ret) && ret)
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo() {Title = "Kin Leader Board API", Version = "v1"});
                    c.DescribeAllEnumsAsStrings();
                    c.DescribeStringEnumsInCamelCase();

                    var key = new OpenApiSecurityScheme()
                    {
                        In = ParameterLocation.Header,
                        Description = "Please enter API key with Bearer into field",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    };

                    c.AddSecurityDefinition("Bearer", key);
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {key,Enumerable.Empty<string>().ToList()}
                    });

                   


                });
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
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
                // app.UseHttpsRedirection();
            }

            app.UseCors(AllOriginPolicyName);

            if (bool.TryParse(Configuration["Swagger_Enabled"], out bool ret) && ret)
            {
                app.UseStaticFiles();
                app.UseSwagger();
                app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kin Leader Board API"); });
            }

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