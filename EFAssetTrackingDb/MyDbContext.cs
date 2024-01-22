using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace EFAssetTrackingDb
{
    internal class MyDbContext : DbContext
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFAssetTrackingDb;Integrated Security=True";
        public DbSet<HQ> HQs { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Phone> Phones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // We tell the app to use the connectionstring.
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            // Headquarters
            ModelBuilder.Entity<HQ>().HasData(new HQ { Id = 1, HQCountry = "Sweden", HQName = "Stockholm" });
            ModelBuilder.Entity<HQ>().HasData(new HQ { Id = 2, HQCountry = "Denmark", HQName = "Copenhagen" });

            // Offices
            ModelBuilder.Entity<Office>().HasData(new Office { Id = 1, HQId = 1, OfficeName = "Svea Kontoret", OfficeCountry = "Sverige" });
            ModelBuilder.Entity<Office>().HasData(new Office { Id = 2, HQId = 2, OfficeName = "Zoo Kontoret", OfficeCountry = "Denmark" });
            ModelBuilder.Entity<Office>().HasData(new Office { Id = 3, HQId = 2, OfficeName = "Sisak Ured", OfficeCountry = "Kroatien" });
            ModelBuilder.Entity<Office>().HasData(new Office { Id = 4, HQId = 1, OfficeName = "Oslo Kontoret", OfficeCountry = "Norge" });
            ModelBuilder.Entity<Office>().HasData(new Office { Id = 5, HQId = 1, OfficeName = "Helsinki", OfficeCountry = "Finland" });

            // Computers
            ModelBuilder.Entity<Computer>().HasData(new Computer { 
                Id = 1, 
                Brand = 
                "HP", 
                Model = "Spectre x360", 
                Price = 1180, 
                OfficeId = 1, 
                PurchaseDate = Convert.ToDateTime("2022-06-10"), 
                Type = "2in1 Laptop" 
            });

            ModelBuilder.Entity<Computer>().HasData(new Computer
            {
                Id = 2,
                Brand = "HP",
                Model = "Envy x360",
                Price = 1180,
                OfficeId = 1,
                PurchaseDate = DateTime.ParseExact("2022-06-10", "yyyy-MM-dd", CultureInfo.InvariantCulture).Date,
                Type = "2in1 Laptop"
            });

            ModelBuilder.Entity<Computer>().HasData(new Computer
            {
                Id = 3,
                Brand = "Dell",
                Model = "Latetude XPS",
                Price = 1220,
                OfficeId = 3,
                PurchaseDate = DateTime.ParseExact("2023-06-01", "yyyy-MM-dd", CultureInfo.InvariantCulture).Date,
                Type = "2in1 Laptop"
            });

            ModelBuilder.Entity<Computer>().HasData(new Computer
            {
                Id = 4,
                Brand = "Dell",
                Model = "Alienware",
                Price = 1855,
                OfficeId = 4,
                PurchaseDate = DateTime.ParseExact("2023-09-11", "yyyy-MM-dd", CultureInfo.InvariantCulture).Date,
                Type = "Stationär"
            });

            // Phones
            ModelBuilder.Entity<Phone>().HasData(new Phone
            {
                Id = 1,
                Brand = "Apple",
                Model = "Iphone 15 Pro Max",
                Price = 1406,
                OfficeId = 1,
                PurchaseDate = DateTime.ParseExact("2023-08-19", "yyyy-MM-dd", CultureInfo.InvariantCulture).Date,
                Type = "Smartphone"
            });

            ModelBuilder.Entity<Phone>().HasData(new Phone
            {
                Id = 2,
                Brand = "Apple",
                Model = "Iphone 13",
                Price = 781,
                OfficeId = 4,
                PurchaseDate = DateTime.ParseExact("2021-06-19", "yyyy-MM-dd", CultureInfo.InvariantCulture).Date,
                Type = "Smartphone"
            });

            ModelBuilder.Entity<Phone>().HasData(new Phone
            {
                Id = 3,
                Brand = "Samsung",
                Model = "S23 Ultra",
                Price = 1016,
                OfficeId = 2,
                PurchaseDate = DateTime.ParseExact("2023-09-19", "yyyy-MM-dd", CultureInfo.InvariantCulture).Date,
                Type = "Smartphone"
            });

            ModelBuilder.Entity<Phone>().HasData(new Phone
            {
                Id = 4,
                Brand = "Google",
                Model = "Pixel 8 Pro",
                Price = 1023,
                OfficeId = 1,
                PurchaseDate = DateTime.ParseExact("2023-09-25", "yyyy-MM-dd", CultureInfo.InvariantCulture).Date,
                Type = "Smartphone"
            });

            ModelBuilder.Entity<Phone>().HasData(new Phone
            {
                Id = 5,
                Brand = "Doro",
                Model = "901c",
                Price = 27,
                OfficeId = 1,
                PurchaseDate = DateTime.ParseExact("2020-02-25", "yyyy-MM-dd", CultureInfo.InvariantCulture).Date,
                Type = "Smartphone"
            });

            ModelBuilder.Entity<Phone>().HasData(new Phone
            {
                Id = 6,
                Brand = "Iphone",
                Model = "X",
                Price = 632,
                OfficeId = 4,
                PurchaseDate = DateTime.ParseExact("2020-06-25", "yyyy-MM-dd", CultureInfo.InvariantCulture).Date,
                Type = "Smartphone"
            });

            ModelBuilder.Entity<Phone>().HasData(new Phone
            {
                Id = 7,
                Brand = "Samsung",
                Model = "Galaxy S10",
                Price = 752,
                OfficeId = 5,
                PurchaseDate = DateTime.ParseExact("2020-11-25", "yyyy-MM-dd", CultureInfo.InvariantCulture).Date,
                Type = "Smartphone"
            });
        }
    }
}
