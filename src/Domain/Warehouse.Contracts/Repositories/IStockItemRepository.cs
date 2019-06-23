using Warehouse.Entities.DbEntities;

namespace Warehouse.Contracts.Repositories
{
    public interface IStockItemRepository : IRepository<StockItem, int>
    {
    }
}