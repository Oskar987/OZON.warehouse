using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouse.Entities.DbEntities;

namespace Warehouse.Persistence.DbConfigurations
{
    internal sealed class StockItemConfiguration : IEntityTypeConfiguration<StockItem>
    {
        public void Configure(EntityTypeBuilder<StockItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Brand).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Price);
            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.Modified);
            builder.Property(x => x.Deleted);
        }
    }
}
