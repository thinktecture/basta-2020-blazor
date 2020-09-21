using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace BastaLiveReal.Client.Services
{
    public static class DialogServiceCollectionExtensions
    {
        public static IServiceCollection AddAlerts(this IServiceCollection services)
        {
            services.AddSingleton<IAlertService, AlertService>();

            return services;
        }
    }

}
