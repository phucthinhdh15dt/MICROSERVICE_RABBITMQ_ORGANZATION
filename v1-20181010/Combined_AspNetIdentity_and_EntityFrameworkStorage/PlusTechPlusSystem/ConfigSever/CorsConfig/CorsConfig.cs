using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlusTechPlusSystem.ConfigSever.CorsConfig
{
    public static class CorsConfig
    {
        public static void Add_CorsConfig_Service(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
                //chi su dung cho identityserver
                options.AddPolicy("CorsPolicy",
                   r => r.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials());
            });
        }
        public static void Use_CorsConfig_App(IApplicationBuilder app)
        {

            app.UseCors("default");
        }
    }
}
