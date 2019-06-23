using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Warehouse.Contracts.Repositories;
using Warehouse.Entities.DbEntities;

namespace Warehouse.Persistence.Repositories
{
    public class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Entity<TKey> where TKey : struct
    {
        protected readonly WarehouseDataContext WarehouseDataContext;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(WarehouseDataContext warehouseDataContext)
        {
            WarehouseDataContext = warehouseDataContext ?? throw new ArgumentNullException(nameof(warehouseDataContext));
            _dbSet = WarehouseDataContext.Set<TEntity>();
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await _dbSet
                .AsNoTracking()
                .Where(x => !x.Deleted.HasValue)
                .ToListAsync();
        }

        public async Task<ICollection<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> FindByIdAsync(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity?.Deleted != null ? null : entity;
        }

        public async Task<TEntity> FindEntityByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().SingleOrDefaultAsync(predicate);
        }

        public void Create(TEntity entity)
        {
            entity.Created = DateTime.UtcNow;
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            entity.Modified = DateTime.UtcNow;
            WarehouseDataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            entity.Deleted = DateTime.Now;
            WarehouseDataContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task SaveChangesAsync()
        {
            await WarehouseDataContext.SaveChangesAsync();
        }
    }
}
