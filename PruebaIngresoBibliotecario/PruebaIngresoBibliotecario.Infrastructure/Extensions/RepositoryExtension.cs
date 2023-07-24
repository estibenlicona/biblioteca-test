using Microsoft.Extensions.DependencyInjection;
using PruebaIngresoBibliotecario.Infrastructure.Adapters;
using PruebaIngresoBibliotecario.Domain.Ports;

namespace PruebaIngresoBibliotecario.Infrastructure.Extensions
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            return services;
        }
    }
}
