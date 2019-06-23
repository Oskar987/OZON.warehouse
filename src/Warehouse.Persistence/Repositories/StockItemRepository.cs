using Warehouse.Contracts.Repositories;
using Warehouse.Entities.DbEntities;

namespace Warehouse.Persistence.Repositories
{
    public sealed class StockItemRepository : BaseRepository<StockItem, int>, IStockItemRepository
    {
        public StockItemRepository(WarehouseDataContext warehouseDataContext) : base(warehouseDataContext)
        {
        }
    }
}
