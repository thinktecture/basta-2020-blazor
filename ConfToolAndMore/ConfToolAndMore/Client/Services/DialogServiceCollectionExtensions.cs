using Microsoft.Extensions.DependencyInjection;

namespace ConfToolAndMore.Client.Services
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
