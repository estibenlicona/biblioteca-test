using PruebaIngresoBibliotecario.Domain.Entities.Base;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Domain.Ports
{
    public interface IGenericRepository<Entity, TypeId> where Entity : BaseEntity<TypeId>
    {
        Task<Entity> AddAsync(Entity entity);
        Task<Entity> FindAsync(Expression<Func<Entity, bool>> condition);
        Task<bool> AnyAsync(Expression<Func<Entity, bool>> condition);
    }
}
