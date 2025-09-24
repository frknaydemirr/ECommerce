using ECommerce.Core.Entities;
using ECommerce.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using System.Reflection;


namespace ECommerce.Data
{


    //veritabanı nesnelerimizi tutacağımız yer:
    public  class DatabaseContext : DbContext
    {

    

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Brand> Brands { get; set; }


        public DbSet<Category> Categories { get; set; }


        public DbSet<Contact> Contacts { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Slider> Sliders { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }


        //database bağlantı ayarı: 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost;Database=ECommerceDb;Trusted_Connection=True;
                TrustServerCertificate=True;");

            optionsBuilder.ConfigureWarnings(warnings =>
    warnings.Ignore(RelationalEventId.PendingModelChangesWarning));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            //modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


         



            base.OnModelCreating(modelBuilder);
        }


    }
}
