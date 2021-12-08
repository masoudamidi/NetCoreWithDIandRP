using BusinessLogic.BLL;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Interfaces
{
    public static class MyServices
    {
        public static IServiceCollection AddMyServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ILocationsRepository, LocationsRepository>();
            return services;
        }
    }

}
