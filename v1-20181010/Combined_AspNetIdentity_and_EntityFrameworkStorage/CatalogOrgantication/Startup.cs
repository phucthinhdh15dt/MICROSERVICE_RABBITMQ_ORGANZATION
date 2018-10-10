using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogOrgantication.Communication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace CatalogOrgantication
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
            services.AddSingleton<Reponse>();
            services.AddMvc();

            //ReponsServiceCommunication.communicationService("localhost","",n);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseRabbitListener();
    }
    }
}
        public static class ApplicationBuilderExtentions
        {
            public static Reponse Listener { get; set; }

            public static IApplicationBuilder UseRabbitListener( this IApplicationBuilder app)
            {
                Listener = app.ApplicationServices.GetService<Reponse>();
                var life = app.ApplicationServices.GetService<IApplicationLifetime>();
                life.ApplicationStarted.Register(OnStarted);
                //press Ctrl+C to reproduce if your app runs in Kestrel as a console app
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
    
    
    
