using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Entities.DbEntities;

namespace Warehouse.Contracts.Services
{
    public interface IStockItemService
    {
        Task<ICollection<StockItem>> GetAsync();
        Task<StockItem> GetAsync(int id);
        Task<StockItem> CreateAsync(StockItem item);
        Task<StockItem> UpdateAsync(StockItem item);
        Task DeleteAsync(int id);
    }
}