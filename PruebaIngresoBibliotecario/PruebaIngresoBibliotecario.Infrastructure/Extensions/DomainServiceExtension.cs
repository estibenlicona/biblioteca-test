using Microsoft.Extensions.DependencyInjection;
using PruebaIngresoBibliotecario.Domain.DomainServices.Loans;

namespace PruebaIngresoBibliotecario.Infrastructure.Extensions
{
    public static class DomainServiceExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<ILoanService, LoanService>();
            return services;
        }
    }
}
