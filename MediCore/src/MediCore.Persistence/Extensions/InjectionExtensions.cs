using MediCore.Application.Interface.Interface;
using MediCore.Persistence.Context;
using MediCore.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MediCore.Persistence.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
        {
            services.AddSingleton<ApplicationDbContext>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
