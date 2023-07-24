using Microsoft.EntityFrameworkCore;
using PruebaIngresoBibliotecario.Domain.Entities.Base;
using PruebaIngresoBibliotecario.Domain.Ports;
using PruebaIngresoBibliotecario.Infrastructure.Contexts;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Infrastructure.Adapters
{
    public class GenericRepository<Entity, TypeId> : IGenericRepository<Entity, TypeId> where Entity : BaseEntity<TypeId>
    {
        public readonly PersistenceContext _persistenceContext;
        public GenericRepository(PersistenceContext persistenceContext)
        {
            _persistenceContext = persistenceContext ?? throw new ArgumentNullException(nameof(persistenceContext));
        }

        public async Task<bool> AnyAsync(Expression<Func<Entity, bool>> condition)
        {
            return await _persistenceContext.Set<Entity>().AnyAsync(condition);
        }
        public async Task<Entity> AddAsync(Entity entity)
        {
            _ = entity ?? throw new ArgumentNullException(nameof(entity), "Entity can not be null");
            _persistenceContext.Set<Entity>().Add(entity);
            await _persistenceContext.CommitAsync().ConfigureAwait(false);
            return entity;
        }

        public async Task<Entity> FindAsync(Expression<Func<Entity, bool>> condition)
        {
            IQueryable<Entity> query = _persistenceContext.Set<Entity>();
            query = query.Where(condition);

            Entity entity = await query.FirstOrDefaultAsync();
            return entity;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            this._persistenceContext.Dispose();
        }
    }
}
