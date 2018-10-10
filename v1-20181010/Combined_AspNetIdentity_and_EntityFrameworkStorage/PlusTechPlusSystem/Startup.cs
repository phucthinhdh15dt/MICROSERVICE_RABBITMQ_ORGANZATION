using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PlusTechPlusSystem.Communication;
using PlusTechPlusSystem.ConfigSever.ConfigCommon;
using PlusTechPlusSystem.ConfigSever.ConfigRepository;
using PlusTechPlusSystem.ConfigSever.CorsConfig;
using ReflectionIT.Mvc.Paging;

namespace PlusTechPlusSystem
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
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            CorsConfig.Add_CorsConfig_Service(services);
            services.AddMvc();
            services.AddSingleton<ReponseIdentityServer>();
            services.AddPaging();
            SwaggerConfig.Add_SwaggerConfigService(services);
            ConfigRepositoryService.configReponsitory(services);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            CorsConfig.Use_CorsConfig_App(app);
            app.UseMvc();
            SwaggerConfig.Use_SwaggerConfigApp(app);
            app.UseRabbitListener();


        }
    }
}
public static class ApplicationBuilderExtentions
{
    public static ReponseIdentityServer Listener { get; set; }

    public static IApplicationBuilder UseRabbitListener(this IApplicationBuilder app)
    {
        Listener = app.ApplicationServices.GetService<ReponseIdentityServer>();
        var life = app.ApplicationServices.GetService<IApplicationLifetime>();
        life.ApplicationStarted.Register(OnStarted);
        life.ApplicationStopping.Register(OnStopping);
        return app;
    }

    private static void OnStarted()
    {
        Listener.Register();
    }

    private static void OnStopping()
    {
        Listener.Deregister();
    }
}
