using System.ComponentModel.DataAnnotations;

namespace Warehouse.API.Models
{
    public class StockItemCreateRequest
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Brand { get; set; }
        public decimal? Price { get; set; }
    }
}
