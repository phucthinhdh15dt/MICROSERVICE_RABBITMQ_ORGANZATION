using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IdentityServerWithAspIdAndEF.Data;
using System.Reflection;
using Swashbuckle.AspNetCore.Swagger;
using IdentityServerWithAspIdAndEF.Controller;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using IdentityServerWithAspIdAndEF.ConfigSever.CorsConfig;
using IdentityServer4.Services;
using Microsoft.Extensions.Logging;
using IdentityServerWithAspIdAndEF.ConfigSever.ConfigRepository;
using System.IO;
using IdentityServerWithAspIdAndEF.ConfigSever.ConfigCommon;
using IdentityServerWithAspIdAndEF.ConfigSever.ConfigAuthentication;

namespace IdentityServerWithAspIdAndEF
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }
        private const string SecretKey = "iNivDmHLpUA223sqsfhqGbMRdRj1PVkH"; // todo: get this from somewhere secure
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        private ILogger<DefaultCorsPolicyService> _logger;

        public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            CorsConfig.Add_CorsConfig_Service(services);
            //var cors = new DefaultCorsPolicyService(_logger)
            //{
            //    AllowAll = true,

            //};
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            ConfigIdentity.Add_Identity_Service(services,connectionString);
            ConfigJWT.Add_ConfigJWTService(services,Configuration);
            services.AddMvc();
            SwaggerConfig.Add_SwaggerConfigService(services);
            ConfigRepositoryService.configReponsitory(services);

        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            CorsConfig.Use_CorsConfig_App(app);

            ConfigIdentity.Use_Identity1_App(app);
            app.UseAuthentication();
            app.UseMvc();
            SwaggerConfig.Use_SwaggerConfigApp(app);
        }
    }
}
