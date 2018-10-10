using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplateWebApiForMy.ConfigService.ConfigGenaral
{
    //Class nay dung de cau hinh cors nghia la nhung duong dan nao co the truy cap vao api .
    public static class CORSConfig
    {
        
        public static void Service(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("default",
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                 );

                options.AddPolicy("setOrigins", policy =>
                {
                    policy.WithOrigins("http://localhost:5003", "https://security-api-react-identity.herokuapp.com", "http://security-api-react-identity.herokuapp.com")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });

                  options.AddPolicy("setFull", p => p.WithOrigins("http://localhost:1233")
                                               .WithMethods("GET")
                                               .WithHeaders("name"));
            });

        }
        public static void Service(IApplicationBuilder app,string policy)
        {
            app.UseCors(policy);
        }
    }
}
