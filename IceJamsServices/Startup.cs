using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IceJamsAgent;
using Microsoft.AspNetCore.Mvc;
using WiM.Services.Middleware;
using WiM.Services.Analytics;
using WiM.Utilities.ServiceAgent;
using WiM.Services.Resources;
using IceJamsServices.Filters;
using IceJamsDB;
using System;
using WiM.Security.Authentication.Basic;
using Microsoft.AspNetCore.Authorization;

namespace IceJamsServices
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
            if (env.IsDevelopment()) {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }//end startup       

        public IConfigurationRoot Configuration { get; }

        //Method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //add functionality to inject IOptions<T>
            services.AddOptions();
            //Configure injectable obj
            services.Configure<APIConfigSettings>(Configuration.GetSection("APIConfigSettings"));
            // Add framework services
            services.AddDbContext<IceJamsDBContext>(options =>
                                                        options.UseNpgsql(String.Format(Configuration
                                                            .GetConnectionString("IceJamsConnection"), Configuration["dbuser"], Configuration["dbpassword"], Configuration["dbHost"]),
                                                            //default is 1000, if > maxbatch, then EF will group requests in maxbatch size
                                                            opt => { opt.MaxBatchSize(1000); opt.UseNetTopologySuite(); })
                                                            .EnableSensitiveDataLogging());

            services.AddScoped<IIceJamsAgent, IceJamsAgent.IceJamsAgent>();
            services.AddScoped<IBasicUserAgent, IceJamsAgent.IceJamsAgent>();

            services.AddScoped<IAnalyticsAgent, GoogleAnalyticsAgent>((gaa)=> new GoogleAnalyticsAgent(Configuration["AnalyticsKey"]));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = BasicDefaults.AuthenticationScheme;
            }).AddBasicAuthentication();
            services.AddAuthorization(options => loadAutorizationPolicies(options));

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
                                                                 .AllowAnyMethod()
                                                                 .AllowAnyHeader()
                                                                 .AllowCredentials());
            });

            services.AddMvc(options => { options.RespectBrowserAcceptHeader = true;
                //Resources must inherit from IHypermedia for this to work.
                //options.Filters.Add(new IceJamsHypermedia());
            }).AddJsonOptions(options => loadJsonOptions(options));                                
                                
        }     

        // Method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAuthentication();
            app.UseCors("CorsPolicy");
            app.Use_Analytics();
            app.UseX_Messages();

            app.UseMvc();            
        }

        #region Helper Methods
        private void loadAutorizationPolicies(AuthorizationOptions options)
        {
            options.AddPolicy(
                "Restricted",
                policy => policy.RequireRole("Administrator", "Internal"));
            options.AddPolicy(
                "AdminOnly",
                policy => policy.RequireRole("Administrator"));
        }

        private void loadJsonOptions(MvcJsonOptions options)
        {
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            options.SerializerSettings.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;
            options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            options.SerializerSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.None;
            options.SerializerSettings.TypeNameAssemblyFormatHandling = Newtonsoft.Json.TypeNameAssemblyFormatHandling.Simple;
            options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.None;
        }
        #endregion
    }
}
