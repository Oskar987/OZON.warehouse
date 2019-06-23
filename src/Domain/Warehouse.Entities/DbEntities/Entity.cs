using System;

namespace Warehouse.Entities.DbEntities
{
    public class Entity<TKey> where TKey : struct
    {
        public TKey Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Deleted { get; set; }
        public DateTime? Modified { get; set; }
    }
}