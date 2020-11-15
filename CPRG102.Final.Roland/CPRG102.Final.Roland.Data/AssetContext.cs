using CPRG102.Final.Roland.Domain;
using Microsoft.EntityFrameworkCore;

namespace CPRG102.Final.Roland.Data
{
    public class AssetContext : DbContext
    {
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=AssetDb;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer { Id = 1, Name = "Apple" },
                new Manufacturer { Id = 2, Name = "Samsung" },
                new Manufacturer { Id = 3, Name = "Acer" },
                new Manufacturer { Id = 4, Name = "LG" },
                new Manufacturer { Id = 5, Name = "HP" },
                new Manufacturer { Id = 6, Name = "Avaya" },
                new Manufacturer { Id = 7, Name = "Polycom" },
                new Manufacturer { Id = 8, Name = "Cisco" }
                );

            modelBuilder.Entity<AssetType>().HasData(
                new AssetType { Id = 1, Name = "Tablet" },
                new AssetType { Id = 2, Name = "Monitor" },
                new AssetType { Id = 3, Name = "Mobile Phone" },
                new AssetType { Id = 4, Name = "Desk Phone" }                
                );

            modelBuilder.Entity<Model>().HasData(
               new Model { Id = 1, Name = "iPad mini", ManufacturerId = 1 },
               new Model { Id = 2, Name = "iPad air", ManufacturerId = 1 },
               new Model { Id = 3, Name = "iPhone 5", ManufacturerId = 1 },
               new Model { Id = 4, Name = "iPhone 6", ManufacturerId = 1 },
               new Model { Id = 5, Name = "Galaxy Tab3", ManufacturerId = 2 },
               new Model { Id = 6, Name = "Galaxy S4", ManufacturerId = 2 },
               new Model { Id = 7, Name = "Galaxy S5", ManufacturerId = 2 },
               new Model { Id = 8, Name = "Galaxy Note5", ManufacturerId = 2 },
               new Model { Id = 9, Name = "S200", ManufacturerId = 3 },
               new Model { Id = 10, Name = "STQ414", ManufacturerId = 3 },
               new Model { Id = 11, Name = "22MP", ManufacturerId = 4 },
               new Model { Id = 12, Name = "Pavilion", ManufacturerId = 5 },
               new Model { Id = 13, Name = "9612G", ManufacturerId = 6 },
               new Model { Id = 14, Name = "SoundPoint 331", ManufacturerId = 7 },
               new Model { Id = 15, Name = "SPA525G2", ManufacturerId = 8 }
               );
        }
    }
}
