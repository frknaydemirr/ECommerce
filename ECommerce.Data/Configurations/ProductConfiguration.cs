using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name)
               .HasMaxLength(250);


            builder.Property(x => x.Image)
           .HasMaxLength(100);


            builder.Property(x => x.ProductCode)
         .HasMaxLength(50);

        }
    }
}
