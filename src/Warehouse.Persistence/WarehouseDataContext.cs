using Microsoft.EntityFrameworkCore;
using Warehouse.Entities.DbEntities;
using Warehouse.Persistence.DbConfigurations;

namespace Warehouse.Persistence
{
    public class WarehouseDataContext : DbContext
    {
        public WarehouseDataContext(DbContextOptions<WarehouseDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StockItemConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<StockItem> StockItems { get; set; }
    }
}
