using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Warehouse.Entities.DbEntities;

namespace Warehouse.Contracts.Repositories
{
    public interface IRepository<TEntity, in TKey> where TEntity : Entity<TKey> where TKey : struct
    {
        Task<ICollection<TEntity>> GetAllAsync();
        Task<ICollection<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindByIdAsync(TKey id);
        Task<TEntity> FindEntityByAsync(Expression<Func<TEntity, bool>> predicate);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task SaveChangesAsync();
    }
}