using Catalog.Host.Data.Entities;

namespace Catalog.Host.Data;

public static class DbInitializer
{
    public static async Task Initialize(ApplicationDbContext context)
    {
        await context.Database.EnsureCreatedAsync();

        if (!context.CatalogManufacturers.Any() && !context.CatalogCars.Any())
        {
            var catalogManufacturer1 = new CatalogManufacturer() { Name = "BMW", FoundationYear = new DateTime(1932, 12, 11).ToUniversalTime(), HeadquartersLocation = "Berlin" };
            var catalogManufacturer2 = new CatalogManufacturer() { Name = "Mercedes", FoundationYear = new DateTime(1944, 11, 11).ToUniversalTime(), HeadquartersLocation = "Stuttgart" };
            var catalogManufacturer3 = new CatalogManufacturer() { Name = "Audi", FoundationYear = new DateTime(1922, 5, 22).ToUniversalTime(), HeadquartersLocation = "Kyiv" };
            var catalogManufacturer4 = new CatalogManufacturer() { Name = "Volkswagen", FoundationYear = new DateTime(1922, 7, 21).ToUniversalTime(), HeadquartersLocation = "Berlin" };
            var catalogManufacturer5 = new CatalogManufacturer() { Name = "Porsche", FoundationYear = new DateTime(1912, 3, 17).ToUniversalTime(), HeadquartersLocation = "Stuttgart" };

            var catalogCar1 = new CatalogCar() { Model = "X5", Year = new DateTime(2022, 11, 22).ToUniversalTime(), Transmission = "Auto", Price = 102000M, Description = "It`s a very fast car", PictureFileName = "1.png", EngineDisplacement = 3.0, CatalogManufacturerId = 1, CatalogManufacturer = catalogManufacturer1 };
            var catalogCar2 = new CatalogCar() { Model = "X6", Year = new DateTime(2022, 10, 11).ToUniversalTime(), Transmission = "Auto", Price = 120000M, Description = "It`s a very fast car", PictureFileName = "2.png", EngineDisplacement = 5.0, CatalogManufacturerId = 1, CatalogManufacturer = catalogManufacturer1 };
            var catalogCar3 = new CatalogCar() { Model = "A6", Year = new DateTime(2022, 11, 22).ToUniversalTime(), Transmission = "Auto", Price = 98000M, Description = "It`s a very fast car", PictureFileName = "3.png", EngineDisplacement = 3.0, CatalogManufacturerId = 3, CatalogManufacturer = catalogManufacturer3 };
            var catalogCar4 = new CatalogCar() { Model = "A7", Year = new DateTime(2022, 11, 22).ToUniversalTime(), Transmission = "Auto", Price = 123000M, Description = "It`s a very fast car", PictureFileName = "4.png", EngineDisplacement = 3.5, CatalogManufacturerId = 3, CatalogManufacturer = catalogManufacturer3 };
            var catalogCar5 = new CatalogCar() { Model = "C63 AMG", Year = new DateTime(2022, 11, 22).ToUniversalTime(), Transmission = "Auto", Price = 200000M, Description = "It`s a very fast car", PictureFileName = "5.png", EngineDisplacement = 5.5, CatalogManufacturerId = 2, CatalogManufacturer = catalogManufacturer2 };

            await context.CatalogManufacturers.AddRangeAsync(new List<CatalogManufacturer>() { catalogManufacturer1, catalogManufacturer2, catalogManufacturer3, catalogManufacturer4, catalogManufacturer5 });
            await context.CatalogCars.AddRangeAsync(new List<CatalogCar>() { catalogCar1, catalogCar2, catalogCar3, catalogCar4, catalogCar5 });

            await context.SaveChangesAsync();
        }
    }
}