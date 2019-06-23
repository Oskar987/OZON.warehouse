namespace Warehouse.Entities.DbEntities
{
    public class StockItem : Entity<int>
    {
        public StockItem()
        {
            
        }

        public StockItem(int id, string name, string brand, decimal? price = null)
        {
            Id = id;
            Name = name;
            Brand = brand;
            Price = price;
        }

        public StockItem(string name, string brand, decimal? price = null)
        {
            Name = name;
            Brand = brand;
            Price = price;
        }

        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal? Price { get; set; }
    }
}