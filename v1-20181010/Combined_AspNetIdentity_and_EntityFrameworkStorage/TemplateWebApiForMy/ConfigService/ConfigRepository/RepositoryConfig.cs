using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateWebApiForMy.Repository.ImplRepository;
using TemplateWebApiForMy.Repository.InterfaceRepository;

namespace TemplateWebApiForMy.ConfigService.ConfigRepository
{
    public static class RepositoryConfig
    {
        public static void service(IServiceCollection services)
        {
            services.AddTransient<ICustomer_Repository, ImplCustomer_Repository>();
        }
    }
}
