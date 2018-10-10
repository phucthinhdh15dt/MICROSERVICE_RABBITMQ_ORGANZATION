
using Microsoft.Extensions.DependencyInjection;
using PlusTechPlusSystem.Communication;
using PlusTechPlusSystem.Repository.ImplRepository;
using PlusTechPlusSystem.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlusTechPlusSystem.ConfigSever.ConfigRepository
{
    public static class ConfigRepositoryService
    {
        public static void configReponsitory(IServiceCollection service)
        {
            service.AddTransient<IOgranzition, ImplOgranzition>();
            service.AddTransient<IOgranzitionService, ImplOgranzitionService>();
            service.AddTransient<IProfileSystem, ImplProfileSystem>();
            service.AddTransient<IService, ImplService>();
            service.AddTransient<ICommunication, PlusTechPlusSystem.Communication.Communication>();
            //service.AddTransient<ICommunicationServiceCatalogOgranzition, ImplCommunicationServiceCatalogOgranzition>();

        }
    }
}
