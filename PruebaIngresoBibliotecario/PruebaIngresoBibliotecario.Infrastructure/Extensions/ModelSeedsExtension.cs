using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using PruebaIngresoBibliotecario.Domain.Entities;
using PruebaIngresoBibliotecario.Infrastructure.Contexts;
using PruebaIngresoBibliotecario.Infrastructure.Seeds;

namespace PruebaIngresoBibliotecario.Infrastructure.Extensions
{
    public static class ModelSeedsBuilder
    {
        public static void AddModelSeedExtensions(this IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<PersistenceContext>();
                
                if (context != null && !context.Set<Book>().Any())
                {
                    context.Set<Book>().AddRange(BookSeed.GetBooksSeeds());
                    context.SaveChanges();
                }

                if (context != null && !context.Set<User>().Any())
                {
                    context.Set<User>().AddRange(UserSeed.GetUsersSeeds());
                    context.SaveChanges();
                }
            }
        }
    }
}
