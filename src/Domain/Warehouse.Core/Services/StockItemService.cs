using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Warehouse.Contracts.Repositories;
using Warehouse.Contracts.Services;
using Warehouse.Entities.DbEntities;
using Warehouse.Exceptions.Core;

namespace Warehouse.Core.Services
{
    public sealed class StockItemService : IStockItemService
    {
        private readonly IStockItemRepository _stockItemRepository;
        private readonly ILogger _logger;

        public StockItemService(IStockItemRepository stockItemRepository, ILoggerFactory loggerFactory)
        {
            _stockItemRepository = stockItemRepository ?? throw new ArgumentNullException(nameof(stockItemRepository));
            _logger = loggerFactory?.CreateLogger(GetType()) ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        public async Task<ICollection<StockItem>> GetAsync()
        {
            try
            {
                return await _stockItemRepository.GetAllAsync();
            }
            catch (Exception e)
            {
                var message = "StockItems getting operation exception";
                _logger.LogError(message, e);
                throw new WarehouseException(message, e);
            }
        }

        public async Task<StockItem> GetAsync(int id)
        {
            try
            {
                return await _stockItemRepository.FindByIdAsync(id);
            }
            catch (Exception e)
            {
                var message = $"StockItems getting by id={id} operation exception";
                _logger.LogError(message, e);
                throw new WarehouseException(message, e);
            }
        }

        public async Task<StockItem> CreateAsync(StockItem item)
        {
            try
            {
                _stockItemRepository.Create(item);
                await _stockItemRepository.SaveChangesAsync();

                return item;
            }
            catch (Exception e)
            {
                var message = $"StockItems creation by request = {JsonConvert.SerializeObject(item)} operation exception";
                _logger.LogError(message, e);
                throw new WarehouseException(message, e);
            }
        }

        public async Task<StockItem> UpdateAsync(StockItem item)
        {
            try
            {
                var stockItem = await _stockItemRepository.FindByIdAsync(item.Id);

                if(stockItem == null)
                    throw new InvalidOperationException($"stockItem not found for modification by id {item.Id}");

                stockItem.Brand = item.Brand;
                stockItem.Name = item.Name;
                stockItem.Price = item.Price;

                _stockItemRepository.Update(stockItem);
                await _stockItemRepository.SaveChangesAsync();
                
                return stockItem;
            }
            catch (InvalidOperationException e)
            {
                _logger.LogError(e.Message, e);
                throw new WarehouseException(e.Message, e);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var item = await _stockItemRepository.FindByIdAsync(id);

                if (item == null)
                    throw new InvalidOperationException($"StockItem not found for deletion by id {id}");

                _stockItemRepository.Delete(item);
                await _stockItemRepository.SaveChangesAsync();
            }
            catch (InvalidOperationException e)
            {
                _logger.LogError(e.Message, e);
                throw new WarehouseException(e.Message, e);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }
        }
    }
}
