using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.Property(x => x.Name)
         .IsRequired()
         .HasMaxLength(50);


            builder.Property(x => x.Image)
       .HasMaxLength(50);

            //test data
            builder.HasData(new Category
            {
                Id = 1,
                Name = "Elektronik",
                IsActive = true,
                IsTopMenu=true,
                ParentId=0,
                OrderNo = 1,
            },
            new Category
            {
                Id = 2,
                Name = "Bilgisayar",
                IsActive = true,
                IsTopMenu = true,
                ParentId = 0,
                OrderNo = 2,
            }


            );
        }
    }
}
