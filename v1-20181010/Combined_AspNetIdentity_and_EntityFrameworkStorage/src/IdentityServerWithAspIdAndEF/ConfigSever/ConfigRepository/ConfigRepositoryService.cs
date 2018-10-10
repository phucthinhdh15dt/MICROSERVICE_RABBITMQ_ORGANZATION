using IdentityServerWithAspIdAndEF.Communication;
using IdentityServerWithAspIdAndEF.Repository.IRepository;
using IdentityServerWithAspIdAndEF.Repository.RepositoryImpl;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerWithAspIdAndEF.ConfigSever.ConfigRepository
{
    public static class ConfigRepositoryService
    {
        public static void configReponsitory(IServiceCollection service)
        {
            service.AddTransient<IProfileRepository, ImpProfileRepository>();
            service.AddTransient<ICommunication, IdentityServerWithAspIdAndEF.Communication.Communication>();
        }
    }
}
