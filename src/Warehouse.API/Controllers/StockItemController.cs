using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Warehouse.API.Models;
using Warehouse.Contracts.Services;
using Warehouse.Entities.DbEntities;

namespace Warehouse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class StockItemController : ControllerBase
    {
        private readonly IStockItemService _stockItemService;

        public StockItemController(IStockItemService stockItemService)
        {
            _stockItemService = stockItemService ?? throw new ArgumentNullException(nameof(stockItemService));
        }

        // GET: api/StockItem
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _stockItemService.GetAsync());
        }

        // GET: api/StockItem/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _stockItemService.GetAsync(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // POST: api/StockItem
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] StockItemCreateRequest request)
        {
            if (ModelState.IsValid)
            {
                var item = await _stockItemService.CreateAsync(new StockItem(request.Name, request.Brand, request.Price));
                return Created(nameof(Post), item);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT: api/StockItem/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put(int id, [FromBody] StockItemUpdateRequest request)
        {
            if (ModelState.IsValid)
            {
                var item = await _stockItemService.UpdateAsync(new StockItem(id, request.Name, request.Brand,
                    request.Price));

                return Ok(item);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete(int id)
        {
            await _stockItemService.DeleteAsync(id);
            return Ok();
        }
    }
}